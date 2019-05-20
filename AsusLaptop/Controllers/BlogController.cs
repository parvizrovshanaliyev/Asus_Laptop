using AsusLaptop.DAL;
using AsusLaptop.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsusLaptop.Controllers
{
    public class BlogController : Controller
    {
        private readonly AsusDbContext _context;

        public BlogController()
        {
            _context = new AsusDbContext();
        }
        // GET: Blog
        public ActionResult Index()
        {
            var vm = new BlogVM()
            {
               Blogs=_context.Blogs.Where(p => p.Status == true).OrderByDescending(b => b.CreateAt).ToList(),
               BlogDesc = _context.Blogs.Where(p => p.Status == true).OrderByDescending(b => b.CreateAt).Take(3).ToList()
            };
            return View(vm);
        }
    }
}