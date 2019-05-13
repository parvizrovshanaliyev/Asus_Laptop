using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AsusLaptop.Models
{
    public class Imgsmultiple
    {
        public int Id { get; set; }

       

        [StringLength(300)]
        [DisplayName("Product Image")]
        public string Image { get; set; }

        [NotMapped]
        [DisplayName("Product Image")]
        public HttpPostedFileBase[] Photos { get; set; }
    }
}