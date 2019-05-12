using AsusLaptop.DAL;
using AsusLaptop.Extensions;
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
            var Product = _context.Products.Include("OrderItems").ToList();
            return View(Product);
        }

        #region Products Create
        public ActionResult Create()
        {
            List<SelectListItem> categories =
                (from cat in _context.Categories.ToList()
                 select new SelectListItem
                 {
                     Text = cat.Name,
                     Value = cat.Id.ToString()
                 }).ToList();
            ViewBag.Categories = categories;
            return View();
        }
        //, PhotoL, PhotoM , PhotoS
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Status , Model , Price ,Discount, CategoryId, Dimensions , Weight , Display , Processor , Memory , Storage ,  Wireless , Ports , Colors , Graphic , PhotoL , PhotoM , PhotoS")]Product product)
        {
            List<SelectListItem> categories =
               (from cat in _context.Categories.ToList()
                select new SelectListItem
                {
                    Text = cat.Name,
                    Value = cat.Id.ToString()
                }).ToList();
            ViewBag.Categories = categories;

            if (!ModelState.IsValid) return View(product);

            var category = _context.Categories.Where(p => p.Id == product.CategoryId).FirstOrDefault();

            if (product == null)
            {
                ModelState.AddModelError("", "This product null");
                return View(product);
            }
            if (_context.Products.Any(p => p.Model == product.Model))
            {
                ModelState.AddModelError("Model", "This Model already exist");
               
                return View(product);
            }
            if (product.PhotoL == null)
            {
                ModelState.AddModelError("PhotoL", "Image large should be selected");

                return View(product);
            }
            if (product.PhotoM == null)
            {
                ModelState.AddModelError("PhotoM", "Image medium should be selected");

                return View(product);
            }
            if (product.PhotoS == null)
            {
                ModelState.AddModelError("PhotoS", "Image small  should be selected");

                return View(product);
            }
            if (!product.PhotoL.IsImage() && product.PhotoM.IsImage() && product.PhotoS.IsImage())
            {
                ModelState.AddModelError("PhotoM", "Photo type is not valid");
                ModelState.AddModelError("PhotoL", "Photo type is not valid");
                ModelState.AddModelError("PhotoS", "Photo type is not valid");
                return View(product);
            }
            

            product.CategoryId = category.Id;
            product.ImageL = product.PhotoL.SavePhoto("Public/img", "products");
            product.ImageM = product.PhotoM.SavePhoto("Public/img", "products");
            product.ImageS = product.PhotoS.SavePhoto("Public/img", "products");
            product.CreateAt = product.UpdateAt = DateTime.Now;
            product.Brand = "Asus";
            product.OperatingSystem = "Windows 10 Pro";
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index"); 
        }
        #endregion

        #region Products Edit

        #endregion

        #region Products Delete

        #endregion


    }
}