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
                Token =user.Id.ToString()

            };

            IdentityResult result = await UserManagerApp.CreateAsync(userdb);

            if (result.Succeeded)
            {
                SendConfirm(userdb.Email, userdb.Token);
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

        #region confirm user account
        public ActionResult Confirm(string token)
        {
            UserApp userdb = UserManagerApp.Users.FirstOrDefault(user=>user.Id == token);

           //var getUser = (from user in UserManagerApp.Users
           //               where user.Id == token
           //               select user).AsQueryable();

              
            if (userdb == null) return View();
            return View(model:userdb.Token);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<ActionResult> Confirm(UserApp user, string Password)
        {
            if (!ModelState.IsValid) return View();

            UserApp userdb =UserManagerApp.Users.FirstOrDefault(ue => ue.Id == user.Id);

            if (userdb == null) return  HttpNotFound("User not found");

            if (string.IsNullOrEmpty(user.UserName))
            {
                ModelState.AddModelError("Username", "UserName not null");
                return View(user);
            }
            if (UserManagerApp.Users.Any(u => u.UserName == user.UserName))
            {
                ModelState.AddModelError("Username", "UserName is already taken");
                return View();
            }
            if (string.IsNullOrEmpty(Password))
            {
                ModelState.AddModelError("Password", "Password not null");
                return View();
            }
            userdb.Fullname = user.Fullname;
            userdb.UserName = user.UserName;
            userdb.PasswordHash = UserManagerApp.PasswordHasher.HashPassword(Password);
            userdb.Token = null;
            userdb.Status = true;
            userdb.EmailConfirmed = true;
            IdentityResult resulte = await UserManagerApp.UpdateAsync(userdb);

            if (resulte.Succeeded) { return RedirectToAction("index"); } //logine gonder sonra

            resulte.Errors.ToList().ForEach(e => ModelState.AddModelError("", e));

            return View();
            
        }

        #endregion
        #region Send Confirm Email User

        private void SendConfirm(string email, string token)
        {

            var body = "<h1>Invite to Asus.com</h1><h3>Message:</h3><h4 class='btn btn-primary'><a style='color:red' href='{0}'>Activate Asus.com Profile</a></h4>";
            var message = new MailMessage();
            message.To.Add(new MailAddress(email));  // replace with valid value 
            message.From = new MailAddress("resetlifewithcode@gmail.com");  // replace with valid value
            message.Subject = " Invite to Asus.com ";
            message.Body = string.Format(body, "http://localhost:50007/Admin/Users/confirm?token=" + token);
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "resetlifewithcode@gmail.com",  // replace with valid value
                    Password = "varint=str321123"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(message);
            }

        }
        #endregion
    }
}