using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public interface IOrderRepository : IDisposable
    {
        IQueryable<AppUser> Users { get; }
        IQueryable<Product> Products { get; }

        AppUser GetUserByName(String name);
        Product GetProductById(Int32 id);

        void AddOrder(String userName, Int32 productId);
    }
}
