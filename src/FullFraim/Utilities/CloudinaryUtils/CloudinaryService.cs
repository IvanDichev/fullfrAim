using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;

namespace Utilities.CloudinaryUtils
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Account account;
        private readonly Cloudinary cloudinary;

        public CloudinaryService(string CloudName, string ApiKey, string ApiSecret)
        {
            this.account = new Account(CloudName, ApiKey, ApiSecret);

            this.cloudinary = new Cloudinary(account);
        }

        public string UploadImage(IFormFile file, string extention = ".png")
        {
            string filePath = Guid.NewGuid().ToString();

            if (file == null)
            {
                throw new ArgumentNullException();
            }

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(filePath + extention, file.OpenReadStream()),
                Overwrite = true,
            };
            
            var uploadResult = this.cloudinary.Upload(uploadParams);

            if (uploadResult.Error != null)
            {
                throw new ArgumentException(); // couldn't upload image
            }

            return uploadResult.SecureUrl.AbsoluteUri;
        }
    }
}
