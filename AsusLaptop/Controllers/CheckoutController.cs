using AsusLaptop.DAL;
using AsusLaptop.filterauth;
using AsusLaptop.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AsusLaptop.Controllers
{
    [UserAuthenticate]
    public class CheckoutController : Controller
    {
        // GET: Checkout
        private readonly AsusDbContext _context;
        private Order _order;
        public UserManagerApp UserManagerApp
        {
            get
            {
                IOwinContext context = HttpContext.GetOwinContext();

                return context.GetUserManager<UserManagerApp>();
            }
        }

        public RoleManagerApp RoleManagerApp { get { return HttpContext.GetOwinContext().GetUserManager<RoleManagerApp>(); } }

        public CheckoutController()
        {
            _context = new AsusDbContext();
            _order = new Order();
        }
        
        public ActionResult Index()
        {
            List<Product> carts = new List<Product>();
            int currentid = 0;
            Product currentProduct = null;
            bool isvalidId = false;
            if (Request.Cookies["carts"] != null && Request.Cookies["carts"].Value != "")
            {
                string[] cartId = Request.Cookies["carts"].Value.Split('+');
                foreach (string item in cartId)
                {
                    isvalidId = int.TryParse(item, out currentid);
                    if (isvalidId)
                    {
                        currentProduct = _context.Products.FirstOrDefault(ad => ad.Id == currentid && ad.Status == true);
                        if (currentProduct != null)
                        {
                            carts.Add(currentProduct);
                        }
                    }
                }
            }
            return View(carts);
        }

        public ActionResult CreateOrder()
        {
            return View();
        }

        
        [HttpPost,ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateOrder(string PhoneNumber)
        {
            if (!ModelState.IsValid) return View(PhoneNumber);
            if (string.IsNullOrEmpty(PhoneNumber))
            {
                ModelState.AddModelError("PhoneNumber", "Phonenumber required");
                return RedirectToAction("Index");
            }

            if (User.Identity.IsAuthenticated)
            {
                UserApp user = await UserManagerApp.FindByIdAsync(User.Identity.GetUserId());
                user.PhoneNumber = PhoneNumber;
                IdentityResult result = await UserManagerApp.UpdateAsync(user);
                _context.SaveChanges();
               
                //await _context.SaveChangesAsync();
                if (user.Carts.Count() != 0)
                {
                    Order order = new Order()
                    {
                        UserAppId = user.Id,
                        Status = false,
                        Date = DateTime.Now,
                        AcceptedDate = DateTime.Now
                    };
                    var products = _context.Carts.Include("Product").Where(p => p.UserAppId == user.Id).ToList();
                    List<OrderItem> orderItems = new List<OrderItem>();
                    foreach (var item in products)
                    {
                        OrderItem orderItem = new OrderItem
                        {
                           
                            ProductId = item.ProductId,
                            Discount = item.Product.Discount,
                            Price = (item.Product.Price - (item.Product.Price * item.Product.Discount / 100)),
                            ImageS = item.Product.ImageS,
                            
                        };
                        orderItems.Add(orderItem);
                    }
                    order.OrderItems = orderItems;
                    _context.Orders.Add(order);
                    await _context.SaveChangesAsync();
                    _order = order;
                    SendOrderConfirm(user.Email);
                    foreach (var item in products)
                    {
                        //var productCart = _context.Carts.FirstOrDefault(p => p.ProductId == item.ProductId && p.UserAppId == item.UserAppId);
                        if (products != null)
                        {
                            _context.Carts.Remove(item);

                        }
                        if (Request.Cookies["carts"].Value.Contains("+" + item.ProductId.ToString() + "+"))
                        {
                            var cookie = Request.Cookies["carts"].Value;
                            Request.Cookies["carts"].Value = cookie.Replace(item.ProductId + "+", "");

                            Response.Cookies.Add(Request.Cookies["carts"]);
                        }
                    }
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index","MyAccount");
                }
                else
                {
                    return RedirectToAction("Index", "Shop");
                }
            }
            else
            {
                return RedirectToAction("Login", "MemberAccount");
            }

            //return View(PhoneNumber);
        }


        #region Send Confirm Email User
        private void SendOrderConfirm(string email)
        {
            //var body = "<h1>Invite to Asus.com</h1><h3>Message:</h3><h4 class='btn btn-primary'><a style='color:red' href='{0}'>Activate Asus.com Profile</a></h4>";
            //
            //< a style = 'color:red' href = '{0}' > My Account </ a > //<h1>Asus.com</h1>
            //var body = "<div class="card">< div class="card-header">Header</div><div class="card-body">Content</div> <div class="card-footer">Footer</div></div>";

            //"<table><thead><tr><th colspan='2'>Products</th><th>Total</th></tr></thead><tbody><tr></tr></tbody></table>";
            var body = " <div style='padding: 3%;background: #e9e8e882;'><h4>Salam :) </h4><p><b>Sifarisiniz qeyde alindi.En qisa zamanda qeyd etdiyiniz mobile nomreden sizinle elaqe saxlanilacaq.<br />Sifarisiniz tesdiqlendiyi teqdirde tesdiq haqqinda email alacaqsiniz</b> </p><br /><p><b>Tesekkurler<br />Asus</b></p><a style='color:#CC2121;border: 1px solid #CC2121;width: 100%;text-align: center;align-items: center;display: inline-flex;justify-content: center;position: relative;z-index: 0;-webkit-font-smoothing: antialiased;font-family: 'Google Sans',Roboto,RobotoDraft,Helvetica,Arial,sans-serif;font-size: .875rem;letter-spacing: .25px;background: none;border-radius: 4px;box-sizing: border-box;cursor: pointer;font-weight: 500;height: 36px;min-width: 80px;outline: none;text-decoration: none;' href='{0}'>Etrafli melumat ucun hesabiniza kecid edin</a> </div>";
            var DisplayEmail = "Asus.com";
            var message = new MailMessage();
            message.To.Add(new MailAddress(email));  // replace with valid value 
            message.From = new MailAddress("resetlifewithcode@gmail.com", DisplayEmail);  // replace with valid value
            message.Subject = "Asus.com";
            message.Body = string.Format(body, "http://parvizrovshan-001-site1.etempurl.com/MyAccount");
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
        //private string CreateBody()
        //{
        //    string body = string.Empty;
        //    using(StreamReader reader = new StreamReader(Server.MapPath("~/Views/EmailBody/Ebody.html")))
        //    {
        //        body = reader.ReadToEnd();
        //    }

            
        //    //body = body.Replace("{User}",_order.UserApp.Fullname.ToString());
        //    body = body.Replace("{No}", _order.Id.ToString());
        //    body = body.Replace("{0}", "http://localhost:50007/MyAccount");
        //    body = body.Replace("{pCount}", _order.OrderItems.Count().ToString());
            
        //    return body;
        //}

    }
}