using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OnlineShop.Models.Identity
{
    public class AppUserManager : UserManager<AppUser>
    {


        public AppUserManager(IUserStore<AppUser> store)
               : base(store)
        {
            
        }

        //public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options,
        //                                              IOwinContext context)
        //{
        //    var db = context.Get<ApplicationDbContext>();
        //    AppUserManager manager = new AppUserManager(new UserStore<AppUser>(db));
        //    return manager;
        //}
    }
}