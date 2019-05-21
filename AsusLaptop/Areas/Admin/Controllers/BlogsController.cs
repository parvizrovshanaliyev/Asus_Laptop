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
    [Authorize(Roles = "admin")]
    public class BlogsController : Controller
    {
        private readonly AsusDbContext _context;

        public BlogsController()
        {
            _context = new AsusDbContext();
        }
        // GET: Admin/Blogs
        public ActionResult Index()
        {
            return View(_context.Blogs.ToList());
        }


        #region Blogs Create
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Status ,Name, Title, Description, PhotoL ,  PhotoSmall")]Blog blog)
        {

            if (!ModelState.IsValid) return View(blog);

            if (blog == null)
            {
                ModelState.AddModelError("", "This blog null");
                return View(blog);
            }
            if (_context.Blogs.Any(p => p.Name == blog.Name))
            {
                ModelState.AddModelError("Name", "This Name already exist");

                return View(blog);
            }
            if (blog.PhotoL == null)
            {
                ModelState.AddModelError("PhotoL", "Image large should be selected");

                return View(blog);
            }

            if (blog.PhotoSmall == null)
            {
                ModelState.AddModelError("PhotoSmall", "Image small  should be selected");

                return View(blog);
            }
            if (!blog.PhotoL.IsImage() && blog.PhotoSmall.IsImage())
            {

                ModelState.AddModelError("PhotoL", "PhotoL type is not valid");
                ModelState.AddModelError("PhotoSmall", "PhotoSmall type is not valid");
                return View(blog);
            }


            blog.ImageL = blog.PhotoL.SavePhoto("Public/images", "blog");
            blog.ImageS = blog.PhotoSmall.SavePhoto("Public/images", "blog");
            blog.CreateAt = blog.UpdateAt = DateTime.Now;
            _context.Blogs.Add(blog);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion


        #region Blogs Edit
        public ActionResult Edit(int? id)
        {
            if (id == null) return HttpNotFound("Id null");
            var blog = _context.Blogs.Find(id);
            if (blog == null) return HttpNotFound("blog null");
            

            return View(blog);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = " Id ,Status ,Name, Title, Description, PhotoL ,  PhotoSmall ")] Blog blog)
        {
            if (blog == null) return HttpNotFound("This product not exist");

            if (_context.Blogs.FirstOrDefault(p => p.Name == blog.Name && p.Id != blog.Id) != null)
            {
                ModelState.AddModelError("Model", "This Model already exist");
            }
            Blog blogdb = _context.Blogs.Find(blog.Id);
            
            if (blog.PhotoL != null && blog.PhotoSmall != null)
            {
                if (!blog.PhotoL.IsImage() && blog.PhotoSmall.IsImage())
                {
                    ModelState.AddModelError("PhotoL", "image large type is not valid");
                    ModelState.AddModelError("PhotoSmall", "image small type is not valid");
                    blog.PhotoL = blogdb.PhotoL;
                    blog.PhotoSmall = blogdb.PhotoSmall;
                    return View(blog);
                }
                RemoveImg("Public/images", blogdb.ImageL);
                RemoveImg("Public/images", blogdb.ImageS);
                blogdb.ImageL = blog.PhotoL.SavePhoto("Public/images", "blog");
                blogdb.ImageS = blog.PhotoSmall.SavePhoto("Public/images", "blog");

            }
           
            blogdb.Name = blog.Name;
            blogdb.Status = blog.Status;
            blogdb.Title = blog.Title;
            blogdb.Description = blog.Description;
            blogdb.UpdateAt = DateTime.Now;
            _context.Entry(blogdb).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion


        #region Blogs Delete
        public ActionResult Delete(int? id)
        {
            if (id == null) return HttpNotFound("id not null");

            Blog blog = _context.Blogs.FirstOrDefault(p => p.Id == id);

            if (blog == null) return HttpNotFound("blog null");

            _context.Blogs.Remove(blog);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        #endregion


        #region details
        public ActionResult Details(int? id)
        {
            if (id == null) return HttpNotFound("id not null");

            Blog blog = _context.Blogs.FirstOrDefault(p => p.Id == id);
            if (blog == null) return HttpNotFound("blog null");

            return View(blog);
        }
        #endregion
    }
}