using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsusLaptop.Models
{
    public class RoleApp : IdentityRole
    {
        public RoleApp()
        {
        }

        public RoleApp(string roleName) : base(roleName)
        {
        }
    }
}