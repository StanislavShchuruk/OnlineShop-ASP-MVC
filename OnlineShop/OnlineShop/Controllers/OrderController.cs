using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    public class OrderController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly IProductRepository _productRepository;

        public OrderController(UserManager<AppUser> userManager, IProductRepository productRepository)
        {
            _userManager = userManager;
            _productRepository = productRepository;
        }

        [HttpPost]
        public void AddIntoBasket(Int32? productId)
        {
            AppUser currentUser = _userManager.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            if (currentUser != null)
            {
                Product product = _productRepository.Products.Where(p => p.Id == productId).FirstOrDefault();
                if (product != null)
                {
                    currentUser.Products.Add(product);
                    _userManager.Update(currentUser);
                }
            }
        }

        [HttpPost]
        public JsonResult GetCurrentUserProductsIdList()
        {
            List<int> productIdList = new List<int>();
            AppUser currentUser = _userManager.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            if(currentUser != null)
            {
                productIdList = currentUser.Products.Select(p => p.Id).ToList();
            }
            return Json(new { data = productIdList });
        }
    }
}