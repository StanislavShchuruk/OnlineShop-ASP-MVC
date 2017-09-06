using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using Autofac.Integration.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Reflection;
using System.Web.Mvc;

using OnlineShop.Models;

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
            builder.RegisterType<ApplicationDbContext>().As<DbContext>().InstancePerRequest();
            builder.RegisterType<UserStore<AppUser>>().As<IUserStore<AppUser>>().InstancePerRequest();
            builder.RegisterType<AppUserManager>().As<UserManager<AppUser>>().InstancePerRequest();

            builder.RegisterType<ProductRepository>()
                .As<IProductRepository>()
                .WithParameter("context", new ApplicationDbContext()).InstancePerRequest();
            builder.RegisterType<ProductTypeRepository>()
                .As<IProductTypeRepository>()
                .WithParameter("context", new ApplicationDbContext()).InstancePerRequest();
            builder.RegisterType<BrandRepository>()
                .As<IBrandRepository>()
                .WithParameter("context", new ApplicationDbContext()).InstancePerRequest();

        }
    }
}