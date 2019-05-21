using AsusLaptop.DAL;
using AsusLaptop.Extensions;
using AsusLaptop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static AsusLaptop.Utilities.Utilities;

namespace AsusLaptop.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class BannersController : Controller
    {
        private readonly AsusDbContext _context;

        public BannersController()
        {
            _context = new AsusDbContext();
        }
        // GET: Admin/Banners
        public ActionResult Index()
        {
            return View(_context.Banners.ToList());
        }

        #region create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase Photo)
        {
            if (!ModelState.IsValid) return View();

            if (Photo == null)
            {
                ModelState.AddModelError("Photo", "ProductImages should be selected");
                return View();
            }
            if (!Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Photo type is not valid");
                return View();
            }
            Banner banner = new Banner
            {
                Image = Photo.SavePhoto("Public/images", "banner")
            };
            _context.Banners.Add(banner);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        #endregion


        #region edit
        public ActionResult Edit(int? id)
        {
            if (id == null) return HttpNotFound("id null");
            Banner banner = _context.Banners.Find(id);
            if (banner == null) return HttpNotFound("This banner not exist");
            return View(banner);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Photo")]Banner banner)
        {
            if (!ModelState.IsValid) return View(banner);
            if (banner == null) return HttpNotFound("This banner not exist");
            Banner bannerdb = _context.Banners.Find(banner.Id);
            if (bannerdb == null) return HttpNotFound("This banner database not exist");
            if (banner.Photo != null)
            {
                if (!banner.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "image  type is not valid");
                    banner.Photo = bannerdb.Photo;
                    return View(banner);
                }
                RemoveImg("Public/images", bannerdb.Image);
                bannerdb.Image = banner.Photo.SavePhoto("Public/images", "banner");
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion


    }
}