using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ICertFileService
    {
        Task<string> SaveFile(string containerName, IFormFile file);
        Task DeleteFile(string containerName, string FileRoute);
        Task<string> EditFile(string containerName, IFormFile file, string path);
        public Task<string> SaveFileCourse(IFormFile file);
        public Task<string> SaveFileStepURL(string url);
    }
}
