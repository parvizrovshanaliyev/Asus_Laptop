using System;
using System.Threading.Tasks;
using AsusLaptop.DAL;
using AsusLaptop.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AsusLaptop.App_Start.OwinStartup))]

namespace AsusLaptop.App_Start
{
    public class OwinStartup
    {
       

        public void Configuration(IAppBuilder app)
        {

            app.CreatePerOwinContext<AsusDbContext>(() => new AsusDbContext());

            app.CreatePerOwinContext<UserManagerApp>(UserManagerApp.Create);

            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions()
            {
                ExpireTimeSpan = TimeSpan.FromMinutes(1),
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                //Provider = new CookieAuthenticationProvider
                //{
                //    // Enables the application to validate the security stamp when the user logs in.
                //    // This is a security feature which is used when you change a password or add an external login to your account.  
                //    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<UserManagerApp, UserApp>(
                //        validateInterval: TimeSpan.FromMinutes(30),
                //        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                //}
            });

            app.CreatePerOwinContext<RoleManagerApp>(RoleManagerApp.Create);

            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
