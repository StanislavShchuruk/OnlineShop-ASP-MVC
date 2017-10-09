using System;
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Owin;
using System.Data.Entity;
using System.Web.Mvc;

using OnlineShop.Models.Identity;
using OnlineShop.Models.Context;
using OnlineShop.Contracts.Repositories;
using OnlineShop.Repositories;

namespace OnlineShop
{
    public partial class Startup
    {
        private void ConfigureDependencyInjection(IAppBuilder app)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            RegisterComponents(builder);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
        }

        private void RegisterComponents(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>()
                .As<DbContext>().InstancePerRequest();
            builder.RegisterType<UserStore<AppUser>>()
                .As<IUserStore<AppUser>>().InstancePerRequest();
            builder.RegisterType<AppUserManager>()
                .As<UserManager<AppUser>>().InstancePerRequest();

            builder.RegisterType<ProductRepository>()
                .As<IProductRepository>().InstancePerRequest();
            builder.RegisterType<ProductTypeRepository>()
                .As<IProductTypeRepository>().InstancePerRequest();
            builder.RegisterType<BrandRepository>()
                .As<IBrandRepository>().InstancePerRequest();
            builder.RegisterType<OrderRepository>()
                .As<IOrderRepository>().InstancePerRequest();
        }
    }
}