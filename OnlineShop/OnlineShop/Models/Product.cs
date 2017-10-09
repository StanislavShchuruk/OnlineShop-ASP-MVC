using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using OnlineShop.Models.Identity;

namespace OnlineShop.Models
{
    public class Product
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public Int32 Price { get; set; }
        public Int32 Quantity { get; set; }
        public String Description { get; set; }
        public String Image { get; set; }
        public ProductType ProductType { get; set; }
        public Brand Brand { get; set; }

        public virtual ICollection<AppUser> Users { get; set; }

        public Product()
        {
            this.Users = new List<AppUser>();
            this.ProductType = new ProductType();
            this.Brand = new Brand();
        }
    }
}