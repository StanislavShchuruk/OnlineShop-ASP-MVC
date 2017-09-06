using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class Product
    {
        public Int32 Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public Int32 Price { get; set; }
        [Required]
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