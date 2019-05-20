﻿using AsusLaptop.DAL;
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
                return RedirectToAction("Index");
            }

            if (User.Identity.IsAuthenticated)
            {
                UserApp user = await UserManagerApp.FindByIdAsync(User.Identity.GetUserId());
                user.PhoneNumber = PhoneNumber;
                _context.SaveChanges();
                Order order = new Order()
                {
                    UserAppId = user.Id,
                    Status = false,
                    Date = DateTime.Now,
                    AcceptedDate = DateTime.Now
                };
                _context.Orders.Add(order);
                _context.SaveChanges();
                if(user.Carts.Count() != 0)
                {
                    var products = _context.Carts.Where(p => p.UserAppId == user.Id);

                    foreach (var item in products)
                    {
                        _context.OrderItems.Add(new OrderItem
                        {
                            OrderId = order.Id,
                            ProductId =item.ProductId,
                            Discount=item.Product.Discount,
                            Price=item.Product.Price,
                            ImageS=item.Product.ImageS
                        });
                        _context.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Login", "MemberAccount");
            }

            return View(PhoneNumber);
        }
    }
}