using AsusLaptop.DAL;
using AsusLaptop.Extensions;
using AsusLaptop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using static AsusLaptop.Utilities.Utilities;

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
        //, PhotoL, PhotoM , PhotoSmall
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Status , IsNew , Model , Price ,Discount, CategoryId, Dimensions , Weight , Display , Processor , Memory , Storage ,  Wireless , Ports , Colors , Graphic , PhotoL , PhotoM, PhotoSmall")]Product product, HttpPostedFileBase[] ProductImages)
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

            List<ProductImage> productImages = new List<ProductImage>();

            foreach (HttpPostedFileBase photo in ProductImages)
            {
                //Checking file is available to save.  
                if (photo == null)
                {
                    ModelState.AddModelError("ProductImages", "ProductImages should be selected");
                    return View(product);
                }
                if (!photo.IsImage())
                {
                    ModelState.AddModelError("PhotoSmall", "Photo type is not valid");
                    return View(product);
                }
                ProductImage productImage = new ProductImage
                {
                    Image = photo.SavePhoto("Public/img", "productsMultiples")
                };
                productImages.Add(productImage);

            }
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
            if (product.PhotoSmall == null)
            {
                ModelState.AddModelError("PhotoSmall", "Image small  should be selected");

                return View(product);
            }
            if (!product.PhotoL.IsImage() && product.PhotoM.IsImage() && product.PhotoSmall.IsImage())
            {
                ModelState.AddModelError("PhotoM", "PhotoM type is not valid");
                ModelState.AddModelError("PhotoL", "PhotoL type is not valid");
                ModelState.AddModelError("PhotoSmall", "PhotoSmall type is not valid");
                return View(product);
            }

            product.ProductImages = productImages;
            product.CategoryId = category.Id;
            product.ImageL = product.PhotoL.SavePhoto("Public/img", "products");
            product.ImageM = product.PhotoM.SavePhoto("Public/img", "products");
            product.ImageS = product.PhotoSmall.SavePhoto("Public/img", "products");
            product.CreateAt = product.UpdateAt = DateTime.Now;
            product.Brand = "Asus";
            product.OperatingSystem = "Windows 10 Pro";
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index"); 
        }
        #endregion

        #region Products Edit
        public ActionResult Edit(int? id)
        {
            if (id == null) return HttpNotFound("Id null");
            var product = _context.Products.Find(id);
            if (product == null) return HttpNotFound("product null");
            List<SelectListItem> categories =
               (from cat in _context.Categories.ToList()
                select new SelectListItem
                {
                    Text = cat.Name,
                    Value = cat.Id.ToString()
                }).ToList();
            ViewBag.Categories = categories;

            return View(product);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = " Id ,Status , IsNew , Model , Price ,Discount, CategoryId, Dimensions , Weight , Display , Processor , Memory , Storage ,  Wireless , Ports , Colors , Graphic , PhotoL , PhotoM , PhotoSmall")]Product product, HttpPostedFileBase[] ProductImages)
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

            if (product == null) return HttpNotFound("This product not exist");

            if (_context.Products.FirstOrDefault(p=>p.Model == product.Model && p.Id != product.Id) != null)
            {
                ModelState.AddModelError("Model", "This Model already exist");
            }
            Product productdb = _context.Products.Find(product.Id);
            foreach (HttpPostedFileBase photo in ProductImages)
            {
                
                if (photo != null && photo.IsImage()){

                    ProductImage productImage = new ProductImage
                    {
                        
                        ProductId = productdb.Id,
                        Image = photo.SavePhoto("Public/img", "productsMultiples")
                    };
                    _context.Entry(productImage).State = EntityState.Added;
                }
            }
            if (product.PhotoL !=null && product.PhotoL!=null && product.PhotoSmall != null)
            {
                if (!product.PhotoL.IsImage() && product.PhotoM.IsImage() && product.PhotoSmall.IsImage())
                {
                    ModelState.AddModelError("PhotoL", "image large type is not valid");
                    ModelState.AddModelError("PhotoM", "image medium type is not valid");
                    ModelState.AddModelError("PhotoSmall", "image small type is not valid");
                    product.PhotoL = productdb.PhotoL;
                    product.PhotoM = productdb.PhotoM;
                    product.PhotoSmall = productdb.PhotoSmall;
                    return View(product);
                }
                RemoveImg("Public/img", productdb.ImageL);
                RemoveImg("Public/img", productdb.ImageM);
                RemoveImg("Public/img", productdb.ImageS);
                productdb.ImageL = product.PhotoL.SavePhoto("Public/img", "products");
                productdb.ImageM = product.PhotoM.SavePhoto("Public/img", "products");
                productdb.ImageS = product.PhotoSmall.SavePhoto("Public/img", "products");

            }
            product.CategoryId = category.Id;
            productdb.Model = product.Model;
            productdb.Status = product.Status;
            productdb.IsNew = product.IsNew;
            productdb.Processor = product.Processor;
            productdb.Display = product.Display;
            productdb.Graphic = product.Graphic;
            productdb.Dimensions = product.Dimensions;
            productdb.Memory = product.Memory;
            productdb.Price = product.Price;
            productdb.Discount = product.Discount;
            productdb.Weight = product.Weight;
            productdb.Storage = product.Storage;
            productdb.Wireless = product.Wireless;
            productdb.Colors = product.Colors;
            productdb.Ports = product.Ports;
            productdb.UpdateAt = DateTime.Now;
            _context.Entry(productdb).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        #region Products Delete
        public ActionResult Delete(int? id)
        {
            if (id == null) return HttpNotFound("id not null");

            Product product = _context.Products.Include("OrderItems").FirstOrDefault(p => p.Id == id);

            if (product == null) return HttpNotFound("product null");

            if (product.OrderItems.Count() != 0) return HttpNotFound("this product have orders");
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion


        #region details
        public ActionResult Details(int? id)
        {
            if (id == null) return HttpNotFound("Id null");
            var product = _context.Products.Find(id);
            if (product == null) return HttpNotFound("Service Item yok la");
            List<SelectListItem> categories =
               (from cat in _context.Categories.ToList()
                select new SelectListItem
                {
                    Text = cat.Name,
                    Value = cat.Id.ToString()
                }).ToList();
            ViewBag.Categories = categories;

            return View(product);
        }
        #endregion

        [HttpPost]
        public JsonResult DeleteFile(int? id)
        {
            if (id==null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Result = "Error" });
            }
            try
            {
                ProductImage productImage = _context.ProductImages.Find(id);
                
                if (productImage == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //Remove from database
                _context.ProductImages.Remove(productImage);

                _context.SaveChanges();

                //Delete file from the file system
                //var path = Path.Combine(Server.MapPath("~/App_Data/Upload/"), fileDetail.Id + fileDetail.Extension);
                //if (System.IO.File.Exists(path))
                //{
                //    System.IO.File.Delete(path);
                //}
                RemoveImg("Public/img", productImage.Image);
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

    }
}