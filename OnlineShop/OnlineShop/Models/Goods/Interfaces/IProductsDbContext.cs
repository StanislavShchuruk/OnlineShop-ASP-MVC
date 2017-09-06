using System.Data.Entity;

namespace OnlineShop.Models
{
    public interface IProductsDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<ProductType> ProductTypes { get; set; }
        DbSet<Brand> Brands { get; set; }

        void SaveChanges();
    }
}
