using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AsusLaptop.Models
{
    public class Product
    {
        public int Id { get; set; }

        public bool Status { get; set; }

        [StringLength(50), Required]
        public string Brand { get; set; }

        [StringLength(50), Required]
        public string Model { get; set; }


        public int CategoryId { get; set; }

        [Column(TypeName = "money")]
        [Required]
        public decimal Price { get; set; }

        public string Colors { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public byte Discount { get; set; }



        [StringLength(300)]
        public string ImageL { get; set; }


        [StringLength(300)]
        public string ImageM { get; set; }

        [StringLength(300)]
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

    }

    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public bool Status { get; set; }

        [StringLength(50), Required]
        public string Name { get; set; }



        public virtual ICollection<Product> Products { get; set; }

    }

    public class Slider
    {
        public int Id { get; set; }
        
        [StringLength(300)]
        public string Title { get; set; }

        [StringLength(300)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase Photo { get; set; }
    }

    public class Banner
    {
        public int Id { get; set; }
        
        [StringLength(300)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase Photo { get; set; }
    }



}