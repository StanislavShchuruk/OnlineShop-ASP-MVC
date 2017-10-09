using System;
using System.Linq;
using System.Web.Mvc;

using OnlineShop.Contracts.Repositories;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    public class ProductTypeController : Controller
    {
        private readonly IProductTypeRepository _repository;

        public ProductTypeController(IProductTypeRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public JsonResult GetProductTypes()
        {
            return Json(new { data = _repository.ProductTypes.ToList() });
        }

        [HttpPost]
        public void AddProductType(String productTypeName)
        {
            _repository.AddProductType(productTypeName);
        }

        [HttpPost]
        public String DeleteProductType(String productTypeName)
        {
            try
            {
                _repository.DeleteProductType(productTypeName);
                return "{ \"isSuccess\" : true }";
            }
            catch (Exception ex)
            {
                return "{ \"isSuccess\" : false," +
                         "\"error_message\" : \"" + ex.Message + "\" }";
            }
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }
    }
}