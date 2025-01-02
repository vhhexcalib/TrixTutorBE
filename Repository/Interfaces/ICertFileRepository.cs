using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ICertFileRepository
    {
        Task<string> SaveFile(string containerName, IFormFile file);
        Task DeleteFile(string containerName, string fileRoute);
        Task<string> EditFile(string containerName, IFormFile file, string existingFilePath);
        public Task<string> SaveFile(IFormFile file);
        public Task<string> SaveFileFromUrl(string url);
    }
}
