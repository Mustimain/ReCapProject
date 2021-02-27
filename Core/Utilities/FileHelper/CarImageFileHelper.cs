using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileHelper
{
    public class CarImageFileHelper
    {
        public static string Add(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName).ToUpper();


            var newGUID = Guid.NewGuid().ToString("N") + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + extension;
            var directory = Directory.GetCurrentDirectory() + "\\wwwroot";

            var path = directory + @"\Images";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string imagePath;

            using (FileStream fileStream = File.Create( path + "\\" + newGUID))
            {
                file.CopyToAsync(fileStream);
                imagePath = (path + "\\" + newGUID);
                fileStream.Flush();   
                
            }

            return imagePath.Replace("\\","/");

        }

        public static void Update(IFormFile file, string oldPath)
        {
            string extension = Path.GetExtension(file.FileName).ToUpper();
            using (FileStream fileStream = File.Open(oldPath,FileMode.Open))
            {
                file.CopyToAsync(fileStream);
                fileStream.Flush();
            }


        }

        public static void Delete(string path)
        {
            File.Delete(path);

        }

    }
}
