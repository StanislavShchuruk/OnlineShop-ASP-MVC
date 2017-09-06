using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OnlineShop.Models;

namespace OnlineShop.Models
{
    public interface IProductTypeRepository
    {
        IQueryable<ProductType> ProductTypes { get; }
        void AddProductType(String productTypeName);
        void DeleteProductType(String productTypeName);
    }
}
