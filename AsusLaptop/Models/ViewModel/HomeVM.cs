using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsusLaptop.Models.ViewModel
{
    public class HomeVM
    {
        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<Banner> Banners { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}