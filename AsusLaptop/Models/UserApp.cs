using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsusLaptop.Models
{
    public class UserApp:IdentityUser
    {
       public UserApp()
        {
            Orders = new HashSet<Order>();
            Carts = new HashSet<Cart>();
        }



        public bool Status { get; set; }

        [StringLength(50)]
        public string Fullname { get; set; }

        public string Token { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }

    }
}