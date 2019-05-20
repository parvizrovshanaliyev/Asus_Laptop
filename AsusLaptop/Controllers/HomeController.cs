using AsusLaptop.DAL;
using AsusLaptop.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsusLaptop.Controllers
{
    public class HomeController : Controller
    {
        private readonly AsusDbContext _context;

        public HomeController()
        {
            _context = new AsusDbContext();
        }

        public ActionResult Index()
        {
            var vm = new HomeVM()
            {
                Sliders = _context.Sliders,
                Banners = _context.Banners,
                Blogs = _context.Blogs.Where(p=>p.Status==true).OrderByDescending(b=>b.CreateAt).Take(3).ToList(),
                Products = _context.Products.Where(s => s.IsNew == true && s.Discount != 0 && s.Status==true).OrderByDescending(t => t.Id).Take(3).ToList(),
                ProductsNews = _context.Products.Where(s => s.IsNew && s.Discount == 0 && s.Status == true).OrderByDescending(t => t.Id).Take(3).ToList(),
                ProductsDiscount = _context.Products.Where(s => s.Discount != 0 && s.IsNew == false && s.Status == true).OrderByDescending(t => t.Id).Take(3).ToList(),
            };
            return View(vm);
        }

        
    }
}