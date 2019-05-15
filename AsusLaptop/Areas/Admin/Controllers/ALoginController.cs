using AsusLaptop.Areas.Admin.Models;
using AsusLaptop.DAL;
using AsusLaptop.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AsusLaptop.Areas.Admin.Controllers
{
    public class ALoginController : Controller
    {
        private readonly AsusDbContext _context;
        public ALoginController()
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

        // GET: Admin/AdminLogin
        [AllowAnonymous]
        public ActionResult Login(string returnURL)
        {
            ViewBag.url = returnURL;
            return View();
        }


        [AllowAnonymous,HttpPost,ValidateAntiForgeryToken]
        public  async Task<ActionResult> Login(AdminLogin admin,  string returnURL)
        
{
            if (ModelState.IsValid)
            {
                UserApp user = UserManagerApp.FindByEmail(admin.Email);

                if (user == null)
                {
                    ModelState.AddModelError("Email", "Email incorrect");
                    return View(admin);
                }

                UserApp currentUser = await UserManagerApp.FindAsync(user.UserName, admin.Password);

                if (currentUser == null)
                {
                    ModelState.AddModelError("Password", "Password incorrect");
                    return View(admin);
                }
                else
                {
                    
                    ClaimsIdentity identity = await  UserManagerApp.CreateIdentityAsync(currentUser, DefaultAuthenticationTypes.ApplicationCookie);
                    HttpContext.GetOwinContext().Authentication.SignOut();

                    
                    HttpContext.GetOwinContext().Authentication.SignIn(new AuthenticationProperties()
                    {
                        AllowRefresh=true,
                        IsPersistent = true,
                        ExpiresUtc = DateTime.UtcNow.AddHours(1)
                    }, identity);
                    //RemoveLogin(admin.RememberMe);


                }
                if (!string.IsNullOrEmpty(returnURL))
                {

                    return Redirect(returnURL);
                }
                else
                {
                    if (UserManagerApp.IsInRole(currentUser.Id, "admin"))
                    {
                        return RedirectToAction("Index", "Home", new { Area = "Admin" });
                    }

                }
                if (!string.IsNullOrEmpty(returnURL))
                {

                    return Redirect(returnURL);
                }
                else
                {
                    return RedirectToAction("Index", "Home", new { Area = "" });
                }
            }
            else
            {
                return View(admin);
            }
            
           
        }

        //private void RemoveLogin(bool RememberMe)
        //{
        //    if(RememberMe == false)
        //    {
               
        //        HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        //    }
        //}
        ///logout
        ///
        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        public ActionResult Logout(string returnURL)
        {
            //if (!string.IsNullOrEmpty(returnURL))
            //{
            //    HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            //    return Redirect(returnURL);
            //}
            //else
            //{
            //    var user = User.Identity.GetUserId();
            //    if (UserManagerApp.IsInRole(user, "admin"))
            //    {
            //        HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            //        return RedirectToAction("Index", "Home", new { Area = "Admin" });
            //    }

            //}
            //if (!string.IsNullOrEmpty(returnURL))
            //{
            //    HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            //    return Redirect(returnURL);
            //}
            //else
            //{
            //    HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            //    return RedirectToAction("Index", "Home", new { Area = "" });
            //}
            HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login");
        }
    }
}