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
        

        public bool Status { get; set; }


        [StringLength(50)]
        public string Fullname { get; set; }

       
        public string Token { get; set; }
    }
}