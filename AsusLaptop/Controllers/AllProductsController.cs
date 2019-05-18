using AsusLaptop.DAL;
using AsusLaptop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsusLaptop.Controllers
{
    public class AllProductsController : Controller
    {
        private readonly AsusDbContext _context;

        public AllProductsController()
        {
            _context = new AsusDbContext();
        }
        // GET: AllProducts
        public ActionResult Filter( string orderBy)
        {
            List<Product> products = _context.Products.Where(p => p.Status == true).ToList();

            if (!string.IsNullOrEmpty(orderBy))
            {
                
                if (orderBy == "cheap")
                {
                    products = products.OrderBy(x => x.Price).ToList();
                    //ViewBag.sort = 2;

                }
                else if (orderBy == "exp")
                {
                    products = products.OrderByDescending(x => x.Price).ToList();
                    //ViewBag.sort = 3;
                }
            }
            return View(products.ToList());
        }
    }
}