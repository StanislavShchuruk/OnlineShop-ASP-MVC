using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OnlineShop.Models;

namespace OnlineShop.Models
{
    public interface IBrandRepository : IDisposable
    {
        IQueryable<Brand> Brands { get; }
        void AddBrand(String brandName);
        void DeleteBrand(String brandName);
    }
}
