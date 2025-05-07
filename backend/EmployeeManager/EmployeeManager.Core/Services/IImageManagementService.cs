
using Microsoft.AspNetCore.Http;

namespace EmployeeManager.Core.Services
{
    public interface IImageManagementService
    {
        Task<string> AddImageAsync(IFormFile file,string src);
        void DeleteImageAsync(string src);
    }
}
