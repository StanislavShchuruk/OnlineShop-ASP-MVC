using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly IProductsDbContext _context;

        public ProductTypeRepository(IProductsDbContext context)
        {
            _context = context;
        }

        public IQueryable<ProductType> ProductTypes
        {
            get { return _context.ProductTypes; }
        }

        public void AddProductType(String productTypeName)
        {
            ProductType productType = new ProductType() { Name = productTypeName };
            _context.ProductTypes.Add(productType);
            _context.SaveChanges();
        }

        public void DeleteProductType(String productTypeName)
        {
            Boolean isUsed = (_context.Products.Where(p => p.ProductType.Name == productTypeName).Count() > 0);
            if (isUsed == false)
            {
                ProductType productType = _context.ProductTypes.Where(pt => pt.Name == productTypeName).First();
                _context.ProductTypes.Remove(productType);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Недопустимая операция: ошибка при удалении типа товаров \'" + productTypeName +
                                "\'. В базе данных содержаться товары использующие удаляемый тип товаров.");
            }
        }
    }
}