using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsusLaptop.Models
{
    public class Cart
    {
        public int Id { get; set; }

        [Required]
        public string UserAppId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Count { get; set; }

        [Column(TypeName = "money")]
        [Required]
        public decimal Total { get; set; }

        public virtual UserApp UserApp { get; set; }
        public virtual Product Product { get; set; }
    }
}