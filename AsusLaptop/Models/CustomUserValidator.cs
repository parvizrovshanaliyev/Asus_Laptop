using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AsusLaptop.Models
{
    public class CustomUserValidator : UserValidator<UserApp>
    {
        public CustomUserValidator(UserManager<UserApp, string> manager) : base(manager)
        {
        }

        //public override async Task<IdentityResult> ValidateAsync(UserApp item)
        //{
        //    IdentityResult result = await base.ValidateAsync(item);

        //    var errors = result.Errors.ToList();

        //    if (!item.Email.EndsWith("@gmail.com"))
        //    {
        //        errors.Add("Email gmail.com ile bitmelidir!!");
        //        return new IdentityResult(errors);

        //    }
        //    return result;
        //}
    }
}