using System;
using System.Linq;
using System.Web.Mvc;

using OnlineShop.Contracts.Repositories;
using OnlineShop.Models;
using OnlineShop.ViewModels;
using System.Collections.Generic;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult ProductEditing(Int32? id = null)
        {
            if (id == null)
            {
                ViewBag.Title = "Добавление товара";
                return View(new ProductModel());
            }
            else
            {
                Product product = _repository.GetProduct((Int32)id);
                ProductModel model = ProductToProductModel(product);
                ViewBag.Title = "Редактирование товара";
                return View(model);
            }
        }

        [HttpPost]
        public JsonResult GetProducts()
        {
            List<Product> products = _repository.Products.ToList();
            List<ProductModel> models = new List<ProductModel>();
            foreach(Product product in products)
            {
                models.Add( ProductToProductModel(product) );
            }
            return Json(new { data = models });
        }

        [HttpPost]
        public RedirectResult AddProduct(String product_type, String brand,
                       String Name, String image_name, Int32 Price, Int32 Quantity)
        {
            if (ModelState.IsValid)
            {
                _repository.AddProduct(product_type, brand, Name, image_name, Price, Quantity);
                return Redirect("~/Home/Index");
            }
            return Redirect("~/Product/ProductEditing");
        }

        [HttpPost]
        public RedirectResult EditProduct(Int32 id, String product_type, String brand,
                       String name, String image_name, Int32 price, Int32 quantity)
        {
            _repository.EditProduct(id, product_type, brand, name, image_name, price, quantity);
            return Redirect("~/Home/Index");
        }

        [HttpPost]
        public void DeleteProduct(Int32 productId)
        {
            _repository.DeleteProduct(productId);
        }

        private ProductModel ProductToProductModel(Product product)
        {
            ProductModel model = new ProductModel()
            {
                Id = product.Id,
                Name = product.Name,
                ProductType = new ProductTypeModel()
                {
                    Id = product.ProductType.Id,
                    Name = product.ProductType.Name
                },
                Brand = new BrandModel()
                {
                    Id = product.Brand.Id,
                    Name = product.Brand.Name
                },
                Image = product.Image,
                Price = product.Price,
                Quantity = product.Quantity
            };
            return model;
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }
    }
}