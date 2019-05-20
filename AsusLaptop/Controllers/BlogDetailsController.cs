using AsusLaptop.DAL;
using AsusLaptop.Models;
using AsusLaptop.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsusLaptop.Controllers
{
    public class BlogDetailsController : Controller
    {
        private readonly AsusDbContext _context;

        public BlogDetailsController()
        {
            _context = new AsusDbContext();
        }
        // GET: BlogDetails
        public ActionResult Index(int? id)
        {
            if (id == null) RedirectToAction("Index", "Home");

            Blog blog = _context.Blogs.Find(id);

            if (blog == null) RedirectToAction("Index", "Home");

            var vm = new BlogVM()
            {
                Blog = blog,
                BlogDesc = _context.Blogs.Where(p => p.Status == true).OrderByDescending(b => b.CreateAt).Take(3).ToList()
            };

            return View(vm);
        }
    }
}