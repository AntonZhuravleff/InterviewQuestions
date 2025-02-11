using Microsoft.AspNetCore.Http;
using TechQuestions.Application.Interfaces;
using TechQuestions.Web.Interfaces;

namespace TechQuestions.Web.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public FileUploadService(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<string> UploadImageAsync(IFormFile image, string relativeUplaodPath)
        {
            var fileExtension = Path.GetExtension(image.FileName);
            var allowedExtensions = new List<string>() { ".png", ".jpg", ".jpeg" };

            if (!allowedExtensions.Contains(fileExtension.ToLower()))
            {
                throw new ArgumentException("File is not image");
            }

            return await UploadFileAsync(image, relativeUplaodPath);
        }

        public async Task<string> UploadFileAsync(IFormFile file, string relativeToWebUploadPath)
        {
            var uniqueFileName = GetUniqueFileName(file.FileName);
            var uploadPath = Path.Combine(_hostingEnvironment.WebRootPath, relativeToWebUploadPath);
            var filePath = Path.Combine(uploadPath, uniqueFileName);

            using (var stream = File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }

            return filePath;
        }

        protected string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
    }
}
