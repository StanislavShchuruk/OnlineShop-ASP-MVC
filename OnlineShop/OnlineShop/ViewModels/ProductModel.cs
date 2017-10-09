using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels
{
    public class ProductModel
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
        public ProductTypeModel ProductType { get; set; }
        public BrandModel Brand { get; set; }

        public ProductModel()
        {
            this.ProductType = new ProductTypeModel();
            this.Brand = new BrandModel();
        }
    }
}