using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _repository;

        public OrderController(IOrderRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public void AddIntoBasket(Int32? productId)
        {
            if ((productId != null) && (User.Identity.IsAuthenticated))
            {
                _repository.AddOrder(User.Identity.Name, (Int32)productId);
            }
        }

        [HttpPost]
        public JsonResult GetCurrentUserProductsIdList()
        {
            List<int> productIdList = new List<int>();
            AppUser currentUser = _repository.GetUserByName(User.Identity.Name);
            if (currentUser != null)
            {
                productIdList = currentUser.Products.Select(p => p.Id).ToList();
            }
            return Json(new { data = productIdList });
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }
    }
}