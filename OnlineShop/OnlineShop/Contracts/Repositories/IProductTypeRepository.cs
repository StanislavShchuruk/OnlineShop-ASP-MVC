using System;
using System.Linq;

using OnlineShop.Models;

namespace OnlineShop.Contracts.Repositories
{
    public interface IProductTypeRepository : IDisposable
    {
        IQueryable<ProductType> ProductTypes { get; }
        void AddProductType(String productTypeName);
        void DeleteProductType(String productTypeName);
    }
}
