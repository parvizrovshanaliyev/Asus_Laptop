using AsusLaptop.DAL;
using AsusLaptop.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsusLaptop.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        private readonly AsusDbContext _context;

        public CartController()
        {
            _context = new AsusDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }

        //[Authorize]
        public ActionResult AddToCart(int? id )
        {

            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Product product = _context.Products.FirstOrDefault(p => p.Id == id);





            //if (quantity == null)
            //{

            //    return RedirectToAction("Index", "Home");
            //}
            
            if(product != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    _context.Carts.Add(new Cart
                    {
                        ProductId = (int)id,
                        UserAppId = User.Identity.GetUserId()
                    });
                    _context.SaveChanges();
                }

                if (Request.Cookies["carts"] == null)
                {
                    HttpCookie cookie = new HttpCookie("carts")
                    {
                        Value = "+" + id.ToString() + "+",
                        Expires = DateTime.Now.AddMinutes(10)
                    };

                    Response.Cookies.Add(cookie);
                }
                else
                {
                    if(!Request.Cookies["carts"].Value.Contains("+" + id.ToString() + "+"))
                    {
                        Request.Cookies["carts"].Value += id.ToString() + "+";
                       
                        Response.Cookies.Add(Request.Cookies["carts"]);
                        //return Json(new
                        //{
                        //    status = 204
                        //});
                    }
                    else
                    {
                        return Json(new
                        {
                            status = 204
                        });
                    }
                }
                return Json(new
                {
                    name = product.Model.Replace(" ", "-"),
                    category = product.Category.Name.Replace(" ", "-"),
                    image = product.ImageS,
                    price = product.Price.ToString("##.##"),
                    status = 200

                });
            }
            else
            {
                return Json(new
                {
                    status = 500,
                    error = "",
                    data = ""

                });
            }
        }
    }
}