using System;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace OnlineShop.Models
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