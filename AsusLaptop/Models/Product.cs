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

        [StringLength(50), Required]
        public string Brand { get; set; }

        [StringLength(50), Required]
        public string Model { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [Column(TypeName = "money")]
        [Required]
        public decimal Price { get; set; }

        public string Colors { get; set; }

        
        [Required]
        public byte Discount { get; set; }

        [Required,StringLength(100)]
        [DisplayName("Operating System")]
        public string OperatingSystem  { get; set; }

        [Required,StringLength(100)]
        public string Display { get; set; }

        [Required,StringLength(100)]
        public string Processor { get; set; }

        [Required,StringLength(100)]
        public string Memory { get; set; }

        [Required,StringLength(100)]
        public string Storage { get; set; }

        [Required,StringLength(100)]
        public string Wireless { get; set; }

        [Required,StringLength(100)]
        public string Dimensions { get; set; }

        [Required,StringLength(100)]
        public string Ports { get; set; }

        [Required,StringLength(100)]
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
        public HttpPostedFileBase PhotoL { get; set; }

        [NotMapped]
        public HttpPostedFileBase PhotoM { get; set; }

        [NotMapped]
        public HttpPostedFileBase PhotoS { get; set; }



        public virtual Category Category { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }


    }

   
}