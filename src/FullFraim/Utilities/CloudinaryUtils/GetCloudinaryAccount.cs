using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Utilities.CloudinaryUtils
{
    public class GetCloudinary
    {
        private readonly IConfiguration config;
        private readonly Account account;
        private readonly Cloudinary cloudinary;

        public GetCloudinary(IConfiguration config)
        {
            this.config = config;

            this.account = new Account(
                this.config["Cloudinary:CloudName"],
                this.config["Cloudinary:ApiKey"],
                this.config["Cloudinary:ApiSecret"]);

            this.cloudinary = new Cloudinary(account);
        }

        public async Task<string> UploadFileAs(IFormFile file, string extention = ".png")
        {
            string filePath = Guid.NewGuid().ToString();

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(filePath + extention, file.OpenReadStream()),
                Overwrite = true,
            };

            var uploadResult = await this.cloudinary.UploadAsync(uploadParams);

            return uploadResult.SecureUrl.AbsoluteUri;
        }
    }
}
