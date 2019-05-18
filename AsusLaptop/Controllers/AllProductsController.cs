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
                else if (orderBy == "4GB")
                {
                    products = products.Where(x => x.Memory.Contains("4GB")).ToList();
                    //ViewBag.sort = 3;
                }
                else if (orderBy == "8GB")
                {
                    products = products.Where(x => x.Memory.Contains("8GB")).ToList();
                    //ViewBag.sort = 3;
                }
                else if (orderBy == "16GB")
                {
                    products = products.Where(x => x.Memory.Contains("8GB")).ToList();
                    //ViewBag.sort = 3;
                }
                else if (orderBy == "32GB")
                {
                    products = products.Where(x => x.Memory.Contains("8GB")).ToList();
                    //ViewBag.sort = 3;
                }
                else if (orderBy == "256GB")
                {
                    products = products.Where(x => x.Storage.Contains("256GB")).ToList();
                    //ViewBag.sort = 3;
                }
                else if (orderBy == "512GB")
                {
                    products = products.Where(x => x.Storage.Contains("512GB")).ToList();
                    //ViewBag.sort = 3;
                }
                else if (orderBy == "1TB")
                {
                    products = products.Where(x => x.Storage.Contains("1TB")).ToList();
                    //ViewBag.sort = 3;
                }
            }
            return View(products.ToList());
        }
    }
}