using AsusLaptop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsusLaptop.Areas.Admin.Controllers
{
    public class OrdersController : Controller
    {
        private readonly AsusDbContext _context;

        public OrdersController()
        {
            _context = new AsusDbContext();
        }
        // GET: Admin/Orders
        public ActionResult Index()
        {
            //var order=_context.Orders.Include("UserApp").Include("Order").OrderByDescending(o => o.Date).ToList();
            var order = _context.OrderItems.Include("Order").Include("Product").OrderByDescending(o => o.Order.Date).ToList();

            return View(order);
        }
    }
}