using AsusLaptop.DAL;
using AsusLaptop.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        //[Route("Register/Register")]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(Register user)
        {
            if (!ModelState.IsValid) return View(user);
            if (user == null) return HttpNotFound("user null");
            if (UserManagerApp.Users.Any(u => u.Email == user.Email))
            {
                ModelState.AddModelError("Email", "Email already taken");
                return View(user);
            }
            if (user.UserName == null)
            {
                ModelState.AddModelError("UserName", "UserName Required !!! not null");
                return View(user);
            }
            if (UserManagerApp.Users.Any(u => u.UserName == user.UserName))
            {
                ModelState.AddModelError("UserName", "UserName already taken");
                return View(user);
            }
            UserApp userdb = new UserApp()
            {
                Fullname = user.Fullname,
                Email = user.Email,
                UserName = user.UserName,
                Status = false
            };
            _context.SaveChanges();
            userdb.Token = userdb.Id;
            IdentityResult result = await UserManagerApp.CreateAsync(userdb);
            SendConfirm(userdb.Email, userdb.Token.ToString());
            _context.SaveChanges();
            if (result.Succeeded)
            {

                return RedirectToAction("Login","MemberAccount");
            }
            else
            {
                foreach (var item in result.Errors.ToList())
                {
                    ModelState.AddModelError(" ", item);

                }
                return View(user);

            }
        }
        #endregion

        #region forgot password
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPass user)
        {
            if(user == null)
            {
                ModelState.AddModelError("Email", "Email required");
                return View(user);
            }
            UserApp userDb = UserManagerApp.FindByEmail(user.Email);
            if(userDb == null)
            {
                ModelState.AddModelError("Email", "Email not exist");
                return View(user);
            }
            userDb.Token = userDb.Id;
            IdentityResult result = await UserManagerApp.UpdateAsync(userDb);
            SendConfirm(userDb.Email, userDb.Token.ToString());
            await _context.SaveChangesAsync();
            if (result.Succeeded)
            {

                return RedirectToAction("Login", "MemberAccount");
            }
            else
            {
                foreach (var item in result.Errors.ToList())
                {
                    ModelState.AddModelError(" ", item);

                }
                return View(user);

            }
        }
        #endregion 

        #region Send Confirm Email User
        private void SendConfirm(string email, string token)
        {
            var body = " <div style='padding: 3%;background: #e9e8e882;'><h4>Salam :) </h4><p><b>Hesabinizi tesdiqlemek ucun asagdaki linke daxil olaraq sifrenizi daxil edin</b> </p><br /><p><b>Tesekkurler<br />Asus</b></p><a style='color:#CC2121;border: 1px solid #CC2121;width: 100%;text-align: center;align-items: center;display: inline-flex;justify-content: center;position: relative;z-index: 0;-webkit-font-smoothing: antialiased;font-family: 'Google Sans',Roboto,RobotoDraft,Helvetica,Arial,sans-serif;font-size: .875rem;letter-spacing: .25px;background: none;border-radius: 4px;box-sizing: border-box;cursor: pointer;font-weight: 500;height: 36px;min-width: 80px;outline: none;text-decoration: none;' href='{0}'>Hesabinizi tesdiqleyin</a> </div>";

            //var body = "<h1>Invite to Asus.com</h1><h3>Message:</h3><h4 class='btn btn-primary'><a style='color:red' href='{0}'>Activate Asus.com Profile</a></h4>";
            var message = new MailMessage();
            var DisplayEmail = "Asus.com";
            message.To.Add(new MailAddress(email));  // replace with valid value 
            message.From = new MailAddress("resetlifewithcode@gmail.com", DisplayEmail);  // replace with valid value
            message.Subject = " Invite to Asus.com ";
            message.Body = string.Format(body, "http://parvizrovshan-001-site1.etempurl.com/Register/confirm?token=" + token);
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "resetlifewithcode@gmail.com",  // replace with valid value
                    Password = ConfigurationManager.AppSettings["EmailPass"]   // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(message);
            }

        }
        #endregion

        #region
        public ActionResult Confirm(string token)
        {
            if (string.IsNullOrEmpty(token)) return HttpNotFound("id not found");


            UserApp user = UserManagerApp.Users.FirstOrDefault(u => u.Token == token);

            if (user == null) return HttpNotFound("User not found");
            return View(user);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Confirm(string id,  string Password)
        {

            if (string.IsNullOrEmpty(id)) return HttpNotFound("id not found");


            UserApp user = await UserManagerApp.FindByIdAsync(id);
            if (!ModelState.IsValid) return View(user);

            if (user == null) return HttpNotFound("User not found");
            
            if (string.IsNullOrEmpty(Password))
            {
                ModelState.AddModelError("Password", "Password not null");
                return View(user);
            }
            
            user.PasswordHash = UserManagerApp.PasswordHasher.HashPassword(Password);
            user.Token = null;
            user.Status = true;

            user.EmailConfirmed = true;
            UserManagerApp.AddToRole(user.Id, "member");
            IdentityResult result = await UserManagerApp.UpdateAsync(user);
            _context.SaveChanges();
            if (result.Succeeded)
            {

                return RedirectToAction("Login", "MemberAccount");

            }
            else
            {
                foreach (var item in result.Errors.ToList())
                {
                    ModelState.AddModelError(" ", item);

                }
                return View(user);

            }


        }

#endregion
    }
}