using System;
using System.Linq;

using OnlineShop.Models;

namespace OnlineShop.Contracts.Repositories
{
    public interface IProductRepository : IDisposable
    {
        IQueryable<Product> Products { get; }
        Product GetProduct(Int32 id);
        void AddProduct(String productType, String brand,
                       String name, String imageName, Int32 price, Int32 quantity);
        void EditProduct(Int32 id, String productType, String brand,
                       String name, String imageName, Int32 price, Int32 quantity);
        void EditProduct(Product product);
        void DeleteProduct(Int32 id);
    }
}
