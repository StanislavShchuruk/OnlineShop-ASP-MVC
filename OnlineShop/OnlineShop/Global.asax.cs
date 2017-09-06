using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;

using OnlineShop.Models;

namespace OnlineShop
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Database.SetInitializer(new GoodsDBInitialiser());
            //Database.SetInitializer<AppIdentityContext>(new IdentityDbInitialiser());
  //          Database.SetInitializer<ApplicationDbContext>(new AppDbInitialiser());
            Database.SetInitializer(new AppDbInitialiser());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
