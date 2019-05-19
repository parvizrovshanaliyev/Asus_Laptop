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
    public class SlidersController : Controller
    {
        private readonly AsusDbContext _context;

        public SlidersController()
        {
            _context = new AsusDbContext();
        }
        // GET: Admin/Sliders
        public ActionResult Index()
        {
            return View(_context.Sliders.ToList());
        }

        #region create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase[] Photos)
        {
            if (!ModelState.IsValid) return View();

            foreach (HttpPostedFileBase photo in Photos)
            {
                //Checking file is available to save.  
                if (photo == null)
                {
                    ModelState.AddModelError("ProductImages", "ProductImages should be selected");
                    return View();
                }
                if (!photo.IsImage())
                {
                    ModelState.AddModelError("PhotoSmall", "Photo type is not valid");
                    return View();
                }
                Slider slider = new Slider
                {
                    Image = photo.SavePhoto("Public/img", "slider")
                };
                _context.Sliders.Add(slider);

            }
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        #endregion

        #region edit
        public ActionResult Edit(int? id)
        {
            if (id == null) return HttpNotFound("id null");
            Slider slider = _context.Sliders.Find(id);
            if (slider == null) return HttpNotFound("This slider not exist");
            return View(slider);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Edit ([Bind(Include ="Id, Photo")]Slider slider)
        {
            if (!ModelState.IsValid) return View(slider);
            if (slider == null) return HttpNotFound("This slider not exist");
            Slider sliderdb = _context.Sliders.Find(slider.Id);
            if (sliderdb == null) return HttpNotFound("This product not exist");
            if (slider.Photo !=null)
            {
                if (!slider.Photo.IsImage() )
                {
                    ModelState.AddModelError("Photo", "image  type is not valid");
                    slider.Photo = sliderdb.Photo;
                    return View(slider);
                }
                RemoveImg("Public/img", sliderdb.Image);
                sliderdb.Image = slider.Photo.SavePhoto("Public/img", "slider");
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
    }
}