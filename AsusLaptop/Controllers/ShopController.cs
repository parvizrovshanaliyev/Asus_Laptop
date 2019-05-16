using AsusLaptop.DAL;
using AsusLaptop.Models;
using AsusLaptop.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace AsusLaptop.Controllers
{
    public class ShopController : Controller
    {
        private readonly AsusDbContext _context;

        public ShopController()
        {
            _context = new AsusDbContext();
        }

        // GET: Shop
        public ActionResult Index()
        {
            ViewBag.TotalCount = _context.Products.Count();
            return View(_context.Products.OrderByDescending(s => s.Id).Take(6).ToList());
        }

        #region ScrollMore
        public ActionResult ScrollMore(int skipCount)
        {
            var products = _context.Products
                .OrderByDescending(s => s.Id)
                .Skip(skipCount)
                .Take(6)
                .ToList(); /* Partial view olmadan istifade edilir cunki virtual navigation problem yaradir   .Select(s => new { s.Id, FullName = s.Name + " " + s.Surname, s.Group.Name })*/
            return PartialView("_Products", products);
        }
        #endregion
       
    }
}