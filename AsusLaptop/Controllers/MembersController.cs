using AsusLaptop.DAL;
using AsusLaptop.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AsusLaptop.Controllers
{
    public class MembersController : Controller
    {
        private readonly AsusDbContext _context;
        public MembersController()
        {
            _context = new AsusDbContext();
        }

        public UserManagerApp UserManagerApp
        {
            get
            {
                IOwinContext context = HttpContext.GetOwinContext();

                return context.GetUserManager<UserManagerApp>();
            }
        }

        public RoleManagerApp RoleManagerApp { get { return HttpContext.GetOwinContext().GetUserManager<RoleManagerApp>(); } }

        #region
        [Route("Register/Register")]
        public ActionResult Register()
        {
            return View();
        }
        //[HttpPost, ValidateAntiForgeryToken]
        //public async Task<ActionResult> Register(UserApp user)
        //{
        //    if (!ModelState.IsValid) return View(user);
        //    if (user == null)
        //    {
        //        ModelState.AddModelError("Email", "Email Write Please");
        //        return View();
        //    }
        //    if (UserManagerApp.Users.Any(u => u.Email == user.Email))
        //    {
        //        ModelState.AddModelError("Email", "Email already taken");
        //        return View(user);
        //    }
        //    UserApp userdb = new UserApp()
        //    {
        //        Fullname=user.Fullname,
        //        Email = user.Email,
        //        UserName = user.UserName,
        //        Status = false,
        //        Token = user.Id
        //    };
        //    _context.SaveChanges();
        //    IdentityResult result = await UserManagerApp.CreateAsync(userdb);
        //    //SendConfirm(userdb.Email, userdb.Token.ToString());
        //    _context.SaveChanges();
        //    if (result.Succeeded)
        //    {

        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        foreach (var item in result.Errors.ToList())
        //        {
        //            ModelState.AddModelError(" ", item);

        //        }
        //        return View(user);

        //    }
        //}
        #endregion
    }
}