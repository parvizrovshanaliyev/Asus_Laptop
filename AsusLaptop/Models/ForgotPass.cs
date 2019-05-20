using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsusLaptop.Models
{
    public class ForgotPass
    {
        [StringLength(100), EmailAddress, Required(ErrorMessage = "EmailAddress required")]
        public string Email { get; set; }
    }
}