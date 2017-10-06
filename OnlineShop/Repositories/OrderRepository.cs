using System;
using System.Data.Entity;
using System.Linq;

using OnlineShop.Contracts.Repositories;
using OnlineShop.Models;
using OnlineShop.Models.Identity;
using OnlineShop.Models.Context;
using System.Collections.Generic;

namespace OnlineShop.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        ApplicationDbContext _context;

        public OrderRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IQueryable<Product> Products
        {
            get
            {
                return _context.Products;
            }
        }

        public IQueryable<AppUser> Users
        {
            get
            {
                return _context.Users;
            }
        }

        public AppUser GetUserByName(String name)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == name);
        }

        public Product GetProductById(Int32 id)
        {
            return _context.Products.Find(id);
        }

        public void AddOrder(String userName, Int32 productId)
        {
            AppUser user = this.GetUserByName(userName);
            if (user != null)
            {
                Product product = this.GetProductById(productId);
                if (product != null)
                {
                    user.Products.Add(product);
                    _context.Entry(user).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
        }

        public List<int> GetUserProductIdList(string userName)
        {
            AppUser user = this.GetUserByName(userName);
            return user.Products.Select(p => p.Id).ToList();
        }

        #region Disposing

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed) return;
            if (disposing)
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