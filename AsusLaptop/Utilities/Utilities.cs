using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AsusLaptop.Utilities
{
    public static class Utilities
    {
        public static void RemoveImage(string mainFolder, string image)
        {
            string path = Path.Combine(HttpContext.Current.Server.MapPath($"~/{mainFolder}"), image);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}