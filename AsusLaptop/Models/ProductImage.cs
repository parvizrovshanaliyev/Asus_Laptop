using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AsusLaptop.Models
{
    public class ProductImage
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Product required")]
        public int ProductId { get; set; }

        [StringLength(300)]
        [DisplayName("Product Image" )]
        public string Image { get; set; }

        [NotMapped]
        [DisplayName("Product Images")]
        public HttpPostedFileBase[] ProductImages { get; set; }

        public virtual Product Product { get; set; }
    }
}