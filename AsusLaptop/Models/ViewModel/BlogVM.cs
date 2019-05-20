using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsusLaptop.Models.ViewModel
{
    public class BlogVM
    {
        public Blog Blog { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }
        public IEnumerable<Blog> BlogDesc { get; set; }
    }
}