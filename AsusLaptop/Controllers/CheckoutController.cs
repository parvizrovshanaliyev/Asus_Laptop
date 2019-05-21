using AsusLaptop.DAL;
using AsusLaptop.filterauth;
using AsusLaptop.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
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
                            ImageS = item.Product.ImageS
                        };
                        orderItems.Add(orderItem);
                    }
                    order.OrderItems = orderItems;
                    _context.Orders.Add(order);
                    await _context.SaveChangesAsync();

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
                    return RedirectToAction("Index");
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


       

    }
}