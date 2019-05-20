using AsusLaptop.DAL;
using AsusLaptop.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}