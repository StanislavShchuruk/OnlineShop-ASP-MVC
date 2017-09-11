using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandRepository _repository;

        public BrandController(IBrandRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public JsonResult GetBrands()
        {
            return Json(new { data = _repository.Brands.ToList() });
        }

        [HttpPost]
        public void AddBrand(string brandName)
        {
            _repository.AddBrand(brandName);
        }

        [HttpPost]
        public String DeleteBrand(string brandName)
        {
            try
            {
                _repository.DeleteBrand(brandName);
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