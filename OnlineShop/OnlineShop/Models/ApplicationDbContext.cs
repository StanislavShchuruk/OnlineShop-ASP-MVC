using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OnlineShop.Models
{
    public class ApplicationDbContext : IdentityDbContext<AppUser> , IProductsDbContext
    {
        static ApplicationDbContext()
        {

        }

        public ApplicationDbContext() : base("ApplicationDb")
        {
            if (!Database.Exists())
            {
                Database.Initialize(true);
            }
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasMany(p => p.Users)
                .WithMany(u => u.Products)
                .Map(t => t.MapLeftKey("product_id")
                .MapRightKey("user_id")
                .ToTable("Orders"));
        }
    }
}