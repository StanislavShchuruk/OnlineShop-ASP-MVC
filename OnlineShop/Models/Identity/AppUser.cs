using System;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

using OnlineShop.Models;

namespace OnlineShop.Models.Identity
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Products = new List<Product>();
        }

        public virtual ICollection<Product> Products { get; set; }
    }
}