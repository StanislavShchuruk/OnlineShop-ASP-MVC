using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OnlineShop.Models;

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
                return View(new Product());
            }
            else
            {
                Product model = _repository.GetProduct((Int32)id);
                ViewBag.Title = "Редактирование товара";
                return View(model);
            }
        }

        [HttpPost]
        public JsonResult GetProducts()
        {
            return Json(new { data = _repository.Products.ToList() });
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
    }
}