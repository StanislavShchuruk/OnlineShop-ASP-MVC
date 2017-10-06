using System;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

namespace OnlineShop
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            // настраиваем контекст и менеджер
            //app.CreatePerOwinContext<ApplicationDbContext>(ApplicationDbContext.Create);
            //app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
            //app.CreatePerOwinContext<AppRoleManager>(AppRoleManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }

    }
}