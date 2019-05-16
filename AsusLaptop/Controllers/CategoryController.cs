using AsusLaptop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsusLaptop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AsusDbContext _context;

        public CategoryController()
        {
            _context = new AsusDbContext();
        }
        //GET: Category
       [Route("Category/{name}/{id}")]
        public ActionResult Index(string name, int id)
        {
            var data = _context.Products.Where(p => p.Status == true && p.CategoryId == id).ToList();
            ViewBag.category = _context.Categories.Where(c => c.Id == id).FirstOrDefault();
            return View(data);
        }
    }
}