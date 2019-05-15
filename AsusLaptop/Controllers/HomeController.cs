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
                Banners = _context.Banners
            };
            return View(vm);
        }

        
    }
}