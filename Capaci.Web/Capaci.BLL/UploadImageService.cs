using Capaci.BLL.interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capaci.BLL
{
    public class UploadImageService : IUploadImageService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UploadImageService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public void DeleteImage(string backgroundPathId)
        {
            try
            {
                string path = Path.Combine(_webHostEnvironment.WebRootPath, "video") + "\\" + backgroundPathId;
                if (System.IO.File.Exists(path))
                {
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    System.IO.File.Delete(path);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Upload(IFormFile file)
        {
            if (file == null)
                return string.Empty;

            string uniqueFileName = null;
            try
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "video");
                uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);            
                file.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            catch (Exception)
            {

                throw;
            }

            return uniqueFileName;
        }
    }
}
