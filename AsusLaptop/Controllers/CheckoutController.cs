using AsusLaptop.DAL;
using AsusLaptop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsusLaptop.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        private readonly AsusDbContext _context;

        public CheckoutController()
        {
            _context = new AsusDbContext();
        }
        public ActionResult Index()
        {
            List<Product> carts = new List<Product>();
            int currentid = 0;
            Product currentProduct = null;
            bool isvalidId = false;
            if (Request.Cookies["carts"] != null && Request.Cookies["carts"].Value != "")
            {
                string[] cartId = Request.Cookies["carts"].Value.Split('+');
                foreach (string item in cartId)
                {
                    isvalidId = int.TryParse(item, out currentid);
                    if (isvalidId)
                    {
                        currentProduct = _context.Products.FirstOrDefault(ad => ad.Id == currentid && ad.Status == true);
                        if (currentProduct != null)
                        {
                            carts.Add(currentProduct);
                        }
                    }
                }
            }
            return View(carts);
        }
    }
}