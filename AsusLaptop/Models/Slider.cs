using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace AsusLaptop.Models
{
    public class Slider
    {
        public int Id { get; set; }
        
        [StringLength(300)]
        public string Title { get; set; }

        [StringLength(300)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase Photo { get; set; }

        [NotMapped]
        public HttpPostedFileBase[] Photos { get; set; }
    }



}