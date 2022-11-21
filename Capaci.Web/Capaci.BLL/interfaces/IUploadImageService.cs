using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capaci.BLL.interfaces
{
    public interface IUploadImageService
    {
        string Upload(IFormFile file);
        void DeleteImage(string backgroundPathId);
    }
}
