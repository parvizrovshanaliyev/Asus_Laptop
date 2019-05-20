using AsusLaptop.DAL;
using AsusLaptop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsusLaptop.Controllers
{
    public class CompareController : Controller
    {
        private readonly AsusDbContext _context;

        public CompareController()
        {
            _context = new AsusDbContext();
        }
        // GET: Compare
        public ActionResult Index(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index", "Shop");
            }

            string[] productsId = id.Split(',');
            List<Product> products = new List<Product>();
            int currentid = 0;
            bool isvalidId = false;
            Product currentProduct = null;
            foreach (var product in productsId)
            {
                isvalidId= int.TryParse(product, out currentid);
                if (isvalidId)
                {
                    currentProduct = _context.Products.FirstOrDefault(ad => ad.Id == currentid && ad.Status == true);
                    if (currentProduct != null)
                    {
                        products.Add(currentProduct);
                    }
                }
            }
            return View(products);
        }


        //public ActionResult AddCompare(string id)
        //{

        //    if (!string.IsNullOrEmpty(id))
        //    {

        //    }   
            
        //        return Json(new
        //        {
        //            status = 500,
        //            error = "",
        //            data = ""

        //        });
            
        //}
    }
}