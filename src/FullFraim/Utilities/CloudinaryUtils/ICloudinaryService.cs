﻿using Microsoft.AspNetCore.Http;
using System.IO;

namespace Utilities.CloudinaryUtils
{
    public interface ICloudinaryService
    {
        string UploadImage(IFormFile file, string extention = ".png");
        string UploadImage(MemoryStream file, string extention = ".png");
    }
}
