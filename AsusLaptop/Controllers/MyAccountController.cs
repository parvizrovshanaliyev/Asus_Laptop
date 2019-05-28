using AsusLaptop.DAL;
using AsusLaptop.filterauth;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsusLaptop.Controllers
{
    [UserAuthenticate2]
    public class MyAccountController : Controller
    {
        private readonly AsusDbContext _context;

        public MyAccountController()
        {
            _context = new AsusDbContext();
        }
        // GET: MyAccount
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var order = _context.OrderItems.Include("Order").Include("Product").OrderByDescending(o => o.Order.Date).ToList();

                var UserorderList = order.Where(o => o.Order.UserAppId == User.Identity.GetUserId()).ToList();
                return View(UserorderList);

            }
            return RedirectToAction("Login", "MemberAcount");
        }
    }
}