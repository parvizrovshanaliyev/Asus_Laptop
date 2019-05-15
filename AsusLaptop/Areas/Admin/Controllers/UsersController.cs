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

namespace AsusLaptop.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private readonly AsusDbContext _context;
        public UsersController()
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
                Token=user.Id
            };
            _context.SaveChanges();
            IdentityResult result = await UserManagerApp.CreateAsync(userdb);
            SendConfirm(userdb.Email, userdb.Token.ToString());
            _context.SaveChanges();
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
                return View(user);

            }
        }
        #endregion

        #region confirm user account
        public  ActionResult Confirm(string token)
        {
            if (string.IsNullOrEmpty(token)) return HttpNotFound("id not found");
            

            UserApp user = UserManagerApp.Users.FirstOrDefault(u => u.Token == token);

            if (user == null) return HttpNotFound("User not found");
            return View(user);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<ActionResult> Confirm(string id , string Fullname,string UserName, string Password)
        {

            if (string.IsNullOrEmpty(id)) return HttpNotFound("id not found");
           

            UserApp user = await UserManagerApp.FindByIdAsync(id);
            if (!ModelState.IsValid) return View(user);

            if (user == null) return  HttpNotFound("User not found");

            //if (string.IsNullOrEmpty(UserName))
            //{
            //    ModelState.AddModelError("Username", "UserName not null");
            //    return View(user);
            //}
            if (string.IsNullOrEmpty(Fullname))
            {
                ModelState.AddModelError("Fullname", "Fullname not null");
                return View(user);
            }
            if (UserManagerApp.Users.Any(u => u.UserName == UserName))
            {
                ModelState.AddModelError("UserName", "UserName is already taken");
                return View(user);
            }
            if (string.IsNullOrEmpty(Password))
            {
                ModelState.AddModelError("Password", "Password not null");
                return View(user);
            }
            user.Fullname = Fullname;
            user.UserName = UserName;
            user.PasswordHash = UserManagerApp.PasswordHasher.HashPassword(Password);
            user.Token = null;
            user.Status = true;
            
            user.EmailConfirmed = true;
            IdentityResult result = await UserManagerApp.UpdateAsync(user);
            _context.SaveChanges();
            if (result.Succeeded)
            {
               
                return RedirectToAction("Login", "ALogin");

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

            var body = "<h1>Invite to Asus.com</h1><h3>Message:</h3><h4 class='btn btn-primary'><a style='color:red' href='{0}'>Activate Asus.com Profile</a></h4>";
            var message = new MailMessage();
            message.To.Add(new MailAddress(email));  // replace with valid value 
            message.From = new MailAddress("resetlifewithcode@gmail.com");  // replace with valid value
            message.Subject = " Invite to Asus.com ";
            message.Body = string.Format(body, "http://localhost:50007/Admin/Users/confirm?token="+token);
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