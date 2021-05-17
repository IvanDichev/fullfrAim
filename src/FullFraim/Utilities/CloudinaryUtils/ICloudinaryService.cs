using Microsoft.AspNetCore.Http;

namespace Utilities.CloudinaryUtils
{
    public interface ICloudinaryService
    {
        string UploadImage(IFormFile file, string extention = ".png");
    }
}
