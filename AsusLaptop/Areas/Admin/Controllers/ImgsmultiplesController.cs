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
    public class ImgsmultiplesController : Controller
    {
        private readonly AsusDbContext _context;

        public ImgsmultiplesController()
        {
            _context = new AsusDbContext();
        }
        // GET: Admin/Imgsmultiples
        public ActionResult Index()
        {
            return View(_context.Imgsmultiples.ToList());
        }
        public ActionResult UploadFiles()
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult UploadFiles(HttpPostedFileBase[] Photos)
        {
            //Ensure model state is valid  
            if (ModelState.IsValid)
            {   //iterating through multiple file collection   
                foreach (HttpPostedFileBase photo in Photos)
                {
                    //Checking file is available to save.  
                    if (photo != null)
                    {
                        if (photo.IsImage())
                        {
                            Imgsmultiple imgsmultiple = new Imgsmultiple
                            {
                                Image = photo.SavePhoto("Public/img", "multiple")
                            };
                            _context.Imgsmultiples.Add(imgsmultiple);
                            ViewBag.UploadStatus = Photos.Count().ToString() + " files uploaded successfully.";
                            _context.SaveChanges();
                            return RedirectToAction("index");
                        }
                        ModelState.AddModelError("Photos", "Photo type is not valid");
                        return View();
                        //assigning file uploaded status to ViewBag for showing message to user.  
                    }
                    ModelState.AddModelError("Photos", "should be selected");
                    return View();

                }
               
            }
           
            return View();
            
            
            //if (Photos == null)
            //{
            //    ModelState.AddModelError("Photos", "should be selected");
            //    return View();
            //}
            //if (!ModelState.IsValid) return HttpNotFound("photo null");

            //foreach (var image in Photos)
            //{

            //    //if (!image.IsImage())
            //    //{
            //    //    ModelState.AddModelError("Photos", "Photo type is not valid");

            //    //}
            //    Imgsmultiple imgsmultiple = new Imgsmultiple
            //    {
            //        Image = image.SavePhoto("Public/img", "multiple")
            //    };
            //    _context.Imgsmultiples.Add(imgsmultiple);
            //    _context.SaveChanges();
            //}
            //return RedirectToAction("index");
            //if (ModelState.IsValid)
            //{
            //    foreach (var image in Photos)
            //    {
            //        if (image==null)
            //        {
            //            ModelState.AddModelError("Photos", "should be selected");

            //        }
            //        if (!image.IsImage())
            //        {
            //            ModelState.AddModelError("Photos", "Photo type is not valid");

            //        }
            //        Imgsmultiple imgsmultiple = new Imgsmultiple
            //        {
            //            Image = image.SavePhoto("Public/img", "multiple")
            //        };
            //        _context.Imgsmultiples.Add(imgsmultiple);
            //        _context.SaveChanges();
            //    }
            //    return RedirectToAction("index");
            //}
            //ModelState.AddModelError("Photos", "should be selected");
            //return View();
        }
    }
}