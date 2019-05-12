using AsusLaptop.DAL;
using AsusLaptop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsusLaptop.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AsusDbContext _context;

        public ProductsController()
        {
            _context = new AsusDbContext();
        }
        // GET: Admin/Products
        public ActionResult Index()
        {
            var Product = _context.Products.Include("OrderItems").Include("Category").OrderByDescending(c => c.CategoryId).ToList();
            return View(Product);
        }

        #region Products Create
        public ActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }
        #endregion

        #region Products Edit

        #endregion

        #region Products Delete

        #endregion


    }
}