using AsusLaptop.Hepler;
using AsusLaptop.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AsusLaptop.Areas.Admin.Controllers
{
    public class RoleToUserController : Controller
    {
        public UserManagerApp UserManagerApp
        {
            get
            {
                IOwinContext context = HttpContext.GetOwinContext();

                return context.GetUserManager<UserManagerApp>();
            }
        }

        public RoleManagerApp RoleManagerApp { get { return HttpContext.GetOwinContext().GetUserManager<RoleManagerApp>(); } }
        // GET: Admin/RoleToUser
        public ActionResult Index()
        {
            return View(UserManagerApp.Users.ToList());
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Index(IEnumerable<string> RoleNames, string userId)
        {
            IEnumerable<String> rolenames = RoleNames ?? new List<string>();

            IEnumerable<string> selectedRoles = rolenames;
            IEnumerable<string> UnselectedRoles = Helper.GetRoles().Select(a => a.Name).Except(rolenames); //secilmemis olan role names goturdum
                                                                                                          
            //selected role
            foreach (var rolename in selectedRoles.ToList())
            {
                if (!UserManagerApp.IsInRole(userId, rolename))
                {
                    UserManagerApp.AddToRole(userId, rolename);
                }
            }

            ///un selected role
            foreach (var rolename in UnselectedRoles.ToList())
            {
                if (UserManagerApp.IsInRole(userId, rolename))
                {
                    UserManagerApp.RemoveFromRole(userId, rolename);
                }
            }
            return RedirectToAction("Index");
        }
    }
}