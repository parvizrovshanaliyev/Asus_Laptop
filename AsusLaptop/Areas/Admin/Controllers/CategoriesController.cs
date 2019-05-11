using AsusLaptop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsusLaptop.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly AsusDbContext _context;

        public CategoriesController()
        {
            _context = new AsusDbContext();
        }
        // GET: Admin/Categories
        public ActionResult Index()
        {
            return View(_context.Categories.ToList());
        }
    }
}