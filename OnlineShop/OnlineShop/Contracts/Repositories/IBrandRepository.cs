using System;
using System.Linq;

using OnlineShop.Models;

namespace OnlineShop.Contracts.Repositories
{
    public interface IBrandRepository : IDisposable
    {
        IQueryable<Brand> Brands { get; }
        void AddBrand(String brandName);
        void DeleteBrand(String brandName);
    }
}
