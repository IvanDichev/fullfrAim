using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Utilities.CloudinaryUtils
{
    public interface ICloudinaryService
    {
        Task<string> UploadImage(IFormFile file, string extention = ".png");
    }
}
