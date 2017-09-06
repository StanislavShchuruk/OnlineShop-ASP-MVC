using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
        Product GetProduct(Int32 id);
        void AddProduct(String productType, String brand,
                       String name, String imageName, Int32 price, Int32 quantity);
        void EditProduct(Int32 id, String productType, String brand,
                       String name, String imageName, Int32 price, Int32 quantity);
        void DeleteProduct(Int32 id);
    }
}
