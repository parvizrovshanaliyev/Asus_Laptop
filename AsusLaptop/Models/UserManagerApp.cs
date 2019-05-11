using AsusLaptop.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsusLaptop.Models
{
    public class UserManagerApp : UserManager<UserApp>
    {
        public UserManagerApp(IUserStore<UserApp> store) : base(store)
        {
        }


        public static UserManagerApp Create(IdentityFactoryOptions<UserManagerApp> identityFactoryOptions, IOwinContext owinContext)
        {
            AsusDbContext context = owinContext.Get<AsusDbContext>();
            UserManagerApp user = new UserManagerApp(new UserStore<UserApp>(context));


            PasswordValidator pass = new PasswordValidator
            {
                RequiredLength = 6,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true
            };

            //user.UserLockoutEnabledByDefault = true;
            //user.MaxFailedAccessAttemptsBeforeLockout = 3;

            // Configure user lockout defaults
            //user.UserLockoutEnabledByDefault = true;
            //user.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(1);
            //user.MaxFailedAccessAttemptsBeforeLockout = 5;
            //pass.RequireNonLetterOrDigit = true; //passwordde her reqemden basqa simvol olmasi ucun

            CustomUserValidator userValidator = new CustomUserValidator(user)
            {
                RequireUniqueEmail = true,
                AllowOnlyAlphanumericUserNames = true
                
            };

            user.PasswordValidator = pass;
            user.UserValidator = userValidator;
            return user;
        }
    }
}