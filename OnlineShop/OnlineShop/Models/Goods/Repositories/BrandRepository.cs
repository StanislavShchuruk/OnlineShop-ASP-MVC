using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class BrandRepository : IBrandRepository
    {
        private readonly IProductsDbContext _context;

        public BrandRepository(IProductsDbContext context)
        {
            _context = context;
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
    }
}