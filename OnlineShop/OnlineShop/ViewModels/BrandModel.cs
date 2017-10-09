using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels
{
    public class BrandModel
    {
        public Int32 Id { get; set; }
        [Required]
        public String Name { get; set; }
    }
}