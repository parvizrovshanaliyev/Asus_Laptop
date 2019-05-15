using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsusLaptop.Models
{
    public class Register
    {
        [StringLength(100), EmailAddress, Required]
        public string Email { get; set; }

        [StringLength(100), Required]
        public string Fullname { get; set; }

        [StringLength(100), Required]
        public string UserName { get; set; }
    }
}