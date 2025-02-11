using System.IO;

namespace TechQuestions.Web.Interfaces
{
    public interface IFileUploadService
    {
        Task<string> UploadImageAsync(IFormFile image, string relativeUplaodPath);
        Task<string> UploadFileAsync(IFormFile file, string relativeUplaodPath);
    }
}
