using AsusLaptop.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsusLaptop.Hepler
{
    public static class Helper
    {
        public static string GetFullname(string id)
        {
            return HttpContext.Current.GetOwinContext().GetUserManager<UserManagerApp>().FindById(id).Fullname;
        }

        public static string GetRoleName(string id)
        {
            return HttpContext.Current.GetOwinContext().GetUserManager<RoleManagerApp>().FindById(id).Name;
        }


        public static IEnumerable<RoleApp> GetRoles()
        {
            return HttpContext.Current.GetOwinContext().GetUserManager<RoleManagerApp>().Roles;
        }
    }
}