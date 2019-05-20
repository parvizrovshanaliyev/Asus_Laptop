using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsusLaptop.Models
{
    public class LoginUser
    {
        [StringLength(100), EmailAddress, Required]
        public string Email { get; set; }

        [StringLength(100), Required, MinLength(6)]
        public string Password { get; set; }

        [Display(Name = "Remmember me?")]
        public bool RememberMe { get; set; }
    }
}