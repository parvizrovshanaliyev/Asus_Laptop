using AsusLaptop.Areas.Admin.Models;
using AsusLaptop.DAL;
using AsusLaptop.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AsusLaptop.Controllers
{
    public class MemberAccountController : Controller
    {
        private readonly AsusDbContext _context;
        public MemberAccountController()
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


        [AllowAnonymous]
        // GET: MemberAccount
        public ActionResult Login(string returnURL)
        {

            ViewBag.url = returnURL;
            return View();
        }


        [AllowAnonymous, HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginUser userI, string returnURL)

        {
            if (ModelState.IsValid)
            {
                UserApp user = UserManagerApp.FindByEmail(userI.Email);

                if (user == null)
                {
                    ModelState.AddModelError("Email", "Email incorrect");
                    return View(userI);
                }

                UserApp currentUser = await UserManagerApp.FindAsync(user.UserName, userI.Password);

                if (currentUser == null)
                {
                    ModelState.AddModelError("Password", "Password incorrect");
                    return View(userI);
                }
                else
                {

                    ClaimsIdentity identity = await UserManagerApp.CreateIdentityAsync(currentUser, DefaultAuthenticationTypes.ApplicationCookie);
                    HttpContext.GetOwinContext().Authentication.SignOut();


                    HttpContext.GetOwinContext().Authentication.SignIn(new AuthenticationProperties()
                    {
                        AllowRefresh = true,
                        IsPersistent = true,
                        ExpiresUtc = DateTime.UtcNow.AddHours(2)
                    }, identity);
                    //RemoveLogin(admin.RememberMe);


                }
                if (_context.Carts.Any(x => x.UserAppId == currentUser.Id))
                {
                    foreach (var item in _context.Carts.Where(x => x.UserAppId == currentUser.Id))
                    {
                        if (Request.Cookies["carts"] == null)
                        {
                            HttpCookie cookie = new HttpCookie("carts")
                            {
                                Value = "+" + item.ProductId.ToString() + "+",
                                Expires = DateTime.Now.AddDays(10)
                            };

                            Response.Cookies.Add(cookie);
                        }
                        else
                        {
                            if (!Request.Cookies["carts"].Value.Contains("+" + item.ProductId.ToString() + "+"))
                            {
                                Request.Cookies["carts"].Value += item.ProductId.ToString() + "+";

                                Response.Cookies.Add(Request.Cookies["carts"]);
                            }
                        }
                    }
                }
                if (UserManagerApp.IsInRole(currentUser.Id, "member"))
                {
                    if (!string.IsNullOrEmpty(returnURL))
                    {
                        return Redirect(returnURL);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(userI);
                }

                

                //if (!string.IsNullOrEmpty(returnURL))
                //{
                //    return Redirect(returnURL);
                //}
                //return RedirectToAction("Index", "Home", new { Area = "" });


            }
            else
            {
                return View(userI);
            }


        }

        

    }
}