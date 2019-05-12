using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AsusLaptop.Models
{
    public class Product
    {
        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
            Carts = new HashSet<Cart>();
        }
        public int Id { get; set; }

        public bool Status { get; set; }

        [StringLength(50)]
        public string Brand { get; set; }

        [StringLength(50), Required]
        public string Model { get; set; }

        [DisplayName("Category")]
        [Required(ErrorMessage = "Select Category")]
        public int CategoryId { get; set; }

        [Column(TypeName = "money")]
        [Required]
        public decimal Price { get; set; }

        public string Colors { get; set; }

        
        public byte Discount { get; set; }

        [ StringLength(100)]
        [DisplayName("Operating System")]
        public string OperatingSystem { get; set; }

        [Required(ErrorMessage = "Display required"), StringLength(100)]
        public string Display { get; set; }

        [Required(ErrorMessage = "Graphic required"), StringLength(100)]
        public string Graphic { get; set; }

        [Required(ErrorMessage = "Processor required"), StringLength(100)]
        public string Processor { get; set; }

        [Required(ErrorMessage = "Memory required"), StringLength(100)]
        public string Memory { get; set; }

        [Required(ErrorMessage = "Storage required"), StringLength(100)]
        public string Storage { get; set; }

        [Required(ErrorMessage = "Wireless required"), StringLength(100)]
        public string Wireless { get; set; }

        [Required(ErrorMessage = "Dimensions required"), StringLength(100)]
        public string Dimensions { get; set; }

        [Required(ErrorMessage = "Ports required"), StringLength(300)]
        public string Ports { get; set; }

        [Required(ErrorMessage = "Weight required"), StringLength(100)]
        public string Weight { get; set; }

        [StringLength(300)]
        [DisplayName("Image Large")]
        public string ImageL { get; set; }

        [StringLength(300)]
        [DisplayName("Image Medium")]
        public string ImageM { get; set; }

        [StringLength(300)]
        [DisplayName("Image Small")]
        public string ImageS { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        [NotMapped]
        [DisplayName("Image Large")]
        public HttpPostedFileBase PhotoL { get; set; }

        [NotMapped]
        [DisplayName("Image Medium")]
        public HttpPostedFileBase PhotoM { get; set; }

        [NotMapped]
        [DisplayName("Image Small")]
        public HttpPostedFileBase PhotoS { get; set; }



        public virtual Category Category { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }


    }

   
}