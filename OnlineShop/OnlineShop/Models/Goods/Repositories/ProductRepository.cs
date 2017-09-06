﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductsDbContext _context;

        public ProductRepository(IProductsDbContext context)
        {
            _context = context;
        }

        public IQueryable<Product> Products
        {
            get { return _context.Products; }
        }

        public Product GetProduct(Int32 id)
        {
            return _context.Products.Where(p => p.Id == id).Single();
        }

        public void AddProduct(String productType, String brand, String name, String imageName, Int32 price, Int32 quantity)
        {
            Product product = new Product();
            product.Name = name;
            product.Image = imageName;
            product.Price = price;
            product.Quantity = quantity;
            product.ProductType = _context.ProductTypes.Where(pt => (pt.Name == productType)).Single();
            product.Brand = _context.Brands.Where(b => (b.Name == brand)).Single();
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void EditProduct(Int32 id, String productType, String brand, String name, String imageName, Int32 price, Int32 quantity)
        {
            Product product = _context.Products.Where(p => p.Id == id).Single();
            product.Name = name;
            product.Image = imageName;
            product.Price = price;
            product.Quantity = quantity;
            product.ProductType = _context.ProductTypes.Where(pt => (pt.Name == productType)).Single();
            product.Brand = _context.Brands.Where(b => (b.Name == brand)).Single();
            _context.SaveChanges();
        }

        public void DeleteProduct(Int32 id)
        {
            Product product = GetProduct(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}