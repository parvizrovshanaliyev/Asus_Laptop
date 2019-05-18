using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AsusLaptop.Models
{
    public class Blog
    {
        public int Id { get; set; }

        public bool Status { get; set; }

        [StringLength(50), Required]
        public string Name { get; set; }

        [StringLength(200), Required]
        public string Title { get; set; }


        [StringLength(300), Required]
        public string Description { get; set; }

        [StringLength(300)]
        [DisplayName("Image Large")]
        public string ImageL { get; set; }


        [StringLength(300)]
        [DisplayName("Image Small")]
        public string ImageS { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        [NotMapped]
        [DisplayName("Image Large")]
        public HttpPostedFileBase PhotoL { get; set; }


        [NotMapped]
        [DisplayName("Image Small")]
        public HttpPostedFileBase PhotoSmall { get; set; }

    }
}