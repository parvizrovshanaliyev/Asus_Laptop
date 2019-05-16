using AsusLaptop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsusLaptop.Controllers
{
    public class ProductController : Controller
    {
        private readonly AsusDbContext _context;

        public ProductController()
        {
            _context = new AsusDbContext();
        }
        // GET: ProductDetails
        [Route("Product/{title}/{id}")]
        public ActionResult Detail(string title,int id)
        {
            var product = _context.Products.Where(p => p.Id == id).FirstOrDefault();
            return View(product);
        }
    }
}