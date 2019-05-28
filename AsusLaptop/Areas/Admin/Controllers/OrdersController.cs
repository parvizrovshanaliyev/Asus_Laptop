using AsusLaptop.DAL;
using AsusLaptop.Models;
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
using System.Web.Mvc;

namespace AsusLaptop.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class OrdersController : Controller
    {
        private readonly AsusDbContext _context;

        public OrdersController()
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

        // GET: Admin/Orders
        public ActionResult Index()
        {
            //var order=_context.Orders.Include("UserApp").Include("Order").OrderByDescending(o => o.Date).ToList();
            var order = _context.OrderItems.Include("Order").Include("Product").OrderByDescending(o => o.Order.Date).ToList();

            return View(order);
        }


        #region orderlist
        public ActionResult Orderlist()
        {
            var order=_context.Orders.Include("UserApp").Include("OrderItems").OrderByDescending(o => o.Date).ToList();

            return View(order);
        }
        #endregion

        #region orderlist
        public ActionResult Edit(int? id)
        {
            if (id == null) return HttpNotFound("Id null");

            var order = _context.Orders.Find(id);

            if (order == null) return HttpNotFound("order null");
            return View(order);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? Id, bool Status, string Adress)
        {
            

            if (Id == null) return HttpNotFound("Id null");

            var order = _context.Orders.Find(Id);

            if (order == null) return HttpNotFound("order null");

            if (!ModelState.IsValid) return View(order);
            order.Status = Status;
            order.AcceptedDate = DateTime.Now;
            if (!string.IsNullOrEmpty(Adress))
            {
                    UserApp user = await UserManagerApp.FindByIdAsync(order.UserAppId);

                    user.Adress = Adress;
                    _context.SaveChanges();
                     SendOrderConfirm(order.UserApp.Email);
                    return RedirectToAction("Orderlist");
                
            }
            else
            {
                ModelState.AddModelError("Adress", "Adress required");
                return View(order);
            }
            
        }
        #endregion


        #region details
        public ActionResult Details(int? id)
        { if (id == null) return HttpNotFound("Id null");

            var order = _context.Orders.Find(id);

            if (order == null) return HttpNotFound("order null");
            return View(order);
        }
        #endregion

        #region Send Confirm Email User
        private void SendOrderConfirm(string email)
        {
            //var body = "<h1>Invite to Asus.com</h1><h3>Message:</h3><h4 class='btn btn-primary'><a style='color:red' href='{0}'>Activate Asus.com Profile</a></h4>";
            //
            //< a style = 'color:red' href = '{0}' > My Account </ a > //<h1>Asus.com</h1>
            //var body = "<div class="card">< div class="card-header">Header</div><div class="card-body">Content</div> <div class="card-footer">Footer</div></div>";

            //"<table><thead><tr><th colspan='2'>Products</th><th>Total</th></tr></thead><tbody><tr></tr></tbody></table>";
            var body = " <div style='padding: 3%;background: #e9e8e882;'><h4>Salam :) </h4><p><b>Sifarisiniz tesdiqlendi<br />Sifarisiniz en qisa zamanda unvaniniza catdirilacaq </b> </p><br /><p><b>Tesekkurler<br />Asus</b></p><a style='color:#CC2121;border: 1px solid #CC2121;width: 100%;text-align: center;align-items: center;display: inline-flex;justify-content: center;position: relative;z-index: 0;-webkit-font-smoothing: antialiased;font-family: 'Google Sans',Roboto,RobotoDraft,Helvetica,Arial,sans-serif;font-size: .875rem;letter-spacing: .25px;background: none;border-radius: 4px;box-sizing: border-box;cursor: pointer;font-weight: 500;height: 36px;min-width: 80px;outline: none;text-decoration: none;' href='{0}'>Etrafli melumat ucun hesabiniza kecid edin</a> </div>";
            var DisplayEmail = "Asus.com";
            var message = new MailMessage();
            message.To.Add(new MailAddress(email));  // replace with valid value 
            message.From = new MailAddress("resetlifewithcode@gmail.com", DisplayEmail);  // replace with valid value
            message.Subject = "Asus.com";
            message.Body = string.Format(body, "http://localhost:50007/MyAccount");
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "resetlifewithcode@gmail.com",  // replace with valid value
                    Password = ConfigurationManager.AppSettings["EmailPass"] //"varint=str321123"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(message);
                Response.Write("alert('email sent..');");
            }

        }
        #endregion
    }
}