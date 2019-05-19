using AsusLaptop.DAL;
using AsusLaptop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsusLaptop.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
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


        #region Create categories
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="Name, Status")]Category category)
        {
            if (!ModelState.IsValid) return View(category);

            if (category == null)
            {
                ModelState.AddModelError("", "This category null");
                return View(category);
            }
            if(_context.Categories.Any(c=>c.Name == category.Name))
            {
                ModelState.AddModelError("Name", "This category already exists");
                return View(category);
            }
           
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        #endregion

        #region Edit categories
        public ActionResult Edit(int? id)
        {
            if(id==null) return HttpNotFound("Id not null");
            var category = _context.Categories.Find(id);
            if(category == null) return HttpNotFound("This category not Exist");
            return View(category);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="Id , Name , Status")]Category category)
        {
            if (!ModelState.IsValid) return View(category);
            if (category == null) return HttpNotFound("This category not Exist");
            if(_context.Categories.FirstOrDefault(c=>c.Name== category.Name && c.Id != category.Id) != null)
            {
                ModelState.AddModelError("Name", "This category name already taken");
                return View(category);
            }
            Category categoryDb = _context.Categories.Find(category.Id);
            categoryDb.Status = category.Status;
            categoryDb.Name = category.Name;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete categories
        public ActionResult Delete(int? id)
        {
            if (id == null) return HttpNotFound("Id not null");
            var category = _context.Categories.Find(id);
            if (category == null) return HttpNotFound("This category not Exist");
            //if (category.Products.Any())
            //{
            //    return HttpNotFound("this category has product");

            //}
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        #endregion
    }
}