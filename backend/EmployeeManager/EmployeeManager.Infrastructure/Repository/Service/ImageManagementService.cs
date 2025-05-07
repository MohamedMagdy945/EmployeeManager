
using EmployeeManager.Core.DTO;
using EmployeeManager.Core.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;

namespace EmployeeManager.Infrastructure.Repository.Service
{
    internal class ImageManagementService : IImageManagementService
    {
        private readonly IFileProvider _fileProvider;
        public ImageManagementService(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }

        public async Task<string> AddImageAsync(IFormFile file, string src)
        {
            if (file == null || file.Length == 0)
            {
                return "/Images/EmployeePersonalImage/defaultImage.jpg";
            }

            var ImageDirectory = Path.Combine("wwwroot", "Images", src);

            if (!Directory.Exists(ImageDirectory))
                Directory.CreateDirectory(ImageDirectory);

            var ImageName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            var ImageSrc = $"/Images/{src}/{ImageName}";
            var root = Path.Combine(ImageDirectory, ImageName);

            using (var stream = new FileStream(root, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
           
            return ImageSrc;
        }

        public void DeleteImageAsync(string src)
        {
            var info = _fileProvider.GetFileInfo(src);
            var root =info.PhysicalPath;

            File.Delete(root);
        }
    }
}
