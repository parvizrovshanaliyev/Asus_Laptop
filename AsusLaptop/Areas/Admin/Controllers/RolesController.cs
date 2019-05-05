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
    public class RolesController : Controller
    {
        
        //public RolesController()
        //{
        //}

        public UserManagerApp UserManagerApp
        {
            get
            {
                IOwinContext context = HttpContext.GetOwinContext();

                return context.GetUserManager<UserManagerApp>();
            }
        }

        public RoleManagerApp RoleManagerApp { get { return HttpContext.GetOwinContext().GetUserManager<RoleManagerApp>(); } }


        #region Roles Index page
        // GET: Admin/Roles
        public ActionResult Index()
        {
            return View(RoleManagerApp.Roles);
        }
        #endregion


        #region Roles Create
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RoleApp role)
        {
            if (role == null) return HttpNotFound("Role Null");

            if (RoleManagerApp.Roles.Any(r => r.Name == role.Name))
            {

                ModelState.AddModelError("", "This role already taken");
            }

            IdentityResult result = await RoleManagerApp.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors.ToList())
                {
                    ModelState.AddModelError(" ", item);
                }
            }
            return View(role);
        }
        #endregion

        #region Roles Delete

        public async Task<ActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return HttpNotFound("role id null");

            RoleApp role = await RoleManagerApp.FindByIdAsync(id);

            if (role == null) return HttpNotFound("this role not found");

            if (role.Users.Any())
            {
                return HttpNotFound("this role has user");
            }

            IdentityResult result = await RoleManagerApp.DeleteAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");

            }
            return View();
        }
        
        #endregion
    }
}