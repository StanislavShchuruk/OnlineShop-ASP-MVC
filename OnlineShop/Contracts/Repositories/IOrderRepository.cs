using System;
using System.Collections.Generic;
using System.Linq;

using OnlineShop.Models;
using OnlineShop.Models.Identity;

namespace OnlineShop.Contracts.Repositories
{
    public interface IOrderRepository : IDisposable
    {
        IQueryable<AppUser> Users { get; }
        IQueryable<Product> Products { get; }

        AppUser GetUserByName(String name);
        Product GetProductById(Int32 id);

        void AddOrder(String userName, Int32 productId);
        List<Int32> GetUserProductIdList(String userName);
    }
}
