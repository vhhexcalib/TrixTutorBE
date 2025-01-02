using Microsoft.AspNetCore.Http;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CertFileService : ICertFileService
    {
        private readonly ICertFileRepository _certFileRepository;
        public CertFileService(ICertFileRepository certFileRepository)
        {
            _certFileRepository = certFileRepository;
        }

        public Task DeleteFile(string containerName, string fileRoute)
        {
            return _certFileRepository.DeleteFile(containerName, fileRoute);
        }

        public Task<string> EditFile(string containerName, IFormFile file, string existingFilePath)
        {
            return _certFileRepository.EditFile(containerName, file, existingFilePath);
        }

        public Task<string> SaveFile(string containerName, IFormFile file)
        {
            return _certFileRepository.SaveFile(containerName, file);
        }

        public Task<string> SaveFileCourse(IFormFile file) => _certFileRepository.SaveFile(file);
        public Task<string> SaveFileStepURL(string url) => _certFileRepository.SaveFileFromUrl(url);
    }
}
