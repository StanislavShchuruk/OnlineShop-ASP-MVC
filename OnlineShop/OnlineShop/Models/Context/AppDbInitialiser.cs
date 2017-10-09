using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Linq;

using OnlineShop.Models.Identity;

namespace OnlineShop.Models.Context
{
    public class AppDbInitialiser : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext db)
        {
            AppUserManager userManager = new AppUserManager(new UserStore<AppUser>(db));
            AppRoleManager roleManager = new AppRoleManager(new RoleStore<AppRole>(db));

            AppRole role1 = new AppRole { Name = "admin" };
            AppRole role2 = new AppRole { Name = "user" };

            roleManager.Create(role1);
            roleManager.Create(role2);

            AppUser admin = new AppUser { Email = "admin@mail.com", UserName = "admin" };
            String password = "Pass_1";
            IdentityResult result = userManager.Create(admin, password);

            if (result.Succeeded)
            {
                userManager.AddToRole(admin.Id, role1.Name);
            }

            db.Products.Add(new Product()
            {
                Name = "Samsung UE49KU6400UXUA",
                Brand = new Brand() { Name = "Samsung" },
                Price = 28999,
                Quantity = 10,
                Image = "samsung_ue49ku6400uxua_images_1728402596.jpg",
                ProductType = new ProductType() { Name = "TV" }
            });

            db.SaveChanges();

            base.Seed(db);
        }
    }
}