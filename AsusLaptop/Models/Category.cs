using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AsusLaptop.Models
{
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



}