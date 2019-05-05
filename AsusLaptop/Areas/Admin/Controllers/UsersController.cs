using AsusLaptop.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AsusLaptop.Areas.Admin.Controllers
{
    public class UsersController : Controller
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
        // GET: Admin/Users
        public ActionResult Index()
        {
            return View(UserManagerApp.Users.ToList());
        }


        #region Create User
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserApp user)
        {
            if (!ModelState.IsValid) return View(user);
            if (user == null)
            {
                ModelState.AddModelError("Email", "Email Write Please");
                return View();
            }
            if (UserManagerApp.Users.Any(u => u.Email == user.Email))
            {
                ModelState.AddModelError("Email", "Email already taken");
                return View(user);
            }
            UserApp userdb = new UserApp()
            {
                Email = user.Email,
                UserName= user.Email,
                Status = false,
                Token = Crypto.Hash(user.Email + user.SecurityStamp).ToString()

                
            };

            IdentityResult result = await UserManagerApp.CreateAsync(userdb);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors.ToList())
                {
                    ModelState.AddModelError("Email", item);

                }
                return View(user);

            }

           
        }
        #endregion
    }
}