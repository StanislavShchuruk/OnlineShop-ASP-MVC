using System;
using System.Linq;

using OnlineShop.Contracts.Repositories;
using OnlineShop.Models;
using OnlineShop.Models.Context;

namespace OnlineShop.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private ApplicationDbContext _context;

        public BrandRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IQueryable<Brand> Brands
        {
            get { return _context.Brands; }
        }

        public void AddBrand(String brandName)
        {
            Brand brand = new Brand() { Name = brandName };
            _context.Brands.Add(brand);
            _context.SaveChanges();
        }

        public void DeleteBrand(String brandName)
        {
            Boolean isUsed = (_context.Products.Where(p => p.Brand.Name == brandName).Count() > 0);
            if (isUsed == false)
            {
                Brand brand = _context.Brands.Where(b => b.Name == brandName).First();
                _context.Brands.Remove(brand);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Недопустимая операция: ошибка при удалении бренда \'" + brandName +
                        "\'. В базе данных содержаться товары использующие удаляемый бренд.");
            }

        }

        #region Disposing

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed) return;
            if(disposing)
            {
                _context.Dispose();
                _context = null;
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}