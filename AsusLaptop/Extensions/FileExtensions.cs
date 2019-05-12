using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AsusLaptop.Extensions
{
    public static class FileExtensions
    {

        public static bool IsImage(this HttpPostedFileBase file)
        {
            return  file.ContentType == "image/jpg" ||
                    file.ContentType == "image/jpeg"||
                    file.ContentType == "image/png"||
                    file.ContentType == "image/gif";
        }




        public static string SavePhoto(this HttpPostedFileBase image,string mainFolder, string subfolder)
        {
            string newFileName = subfolder + @"/" + Guid.NewGuid().ToString() + Path.GetFileName(image.FileName);
            string fullPath = Path.Combine(HttpContext.Current.Server.MapPath($"~/{mainFolder}"), newFileName);
            //WebImage imageR = new WebImage(image.InputStream);
            //imageR.Resize(800, 600, false,true);

            //imageR.Save(fullPath);
            image.SaveAs(fullPath);
            return newFileName;
        }
    }
}