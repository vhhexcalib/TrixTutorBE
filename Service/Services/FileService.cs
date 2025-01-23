using Microsoft.AspNetCore.Http;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
namespace Service.Services
{
    public class FileService : IFileService
    {

        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _connectionString;
        private readonly string _containerName;
        public FileService(BlobServiceClient blobServiceClient, string containerName)
        {
            _blobServiceClient = blobServiceClient;
            _containerName = containerName;
        }

        public async Task<string> GetFileExtensionAsync(IFormFile file)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file), "File không được null");
            }

            // Simulate an asynchronous operation (if needed)
            await Task.Delay(1);

            var fileExtension = Path.GetExtension(file.FileName).ToLower();
            return fileExtension;
        }

        public async Task<string> SaveFile(IFormFile file)
        {
            string containerName = null; // Ensure the container name is correct

            // Get the file extension asynchronously
            var fileExtension = await GetFileExtensionAsync(file);

            // Define allowed file extensions
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".mp4", ".pdf", ".docx", ".doc" };

            // Check file extension
            if (!Array.Exists(allowedExtensions, ext => ext == fileExtension))
            {
                throw new InvalidOperationException("Định dạng tệp không được hỗ trợ.");
            }

            if (fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == "png")
            {
                containerName = "image";
            }
            else if (fileExtension == ".mp4")
            {
                containerName = "video";
            }
            else if (fileExtension == ".pdf")
            {
                containerName = "pdf";
            }
            else if (fileExtension == ".docx" || fileExtension == ".doc")
            {
                containerName = "word";
            }

            BlobContainerClient blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            await blobContainerClient.CreateIfNotExistsAsync(PublicAccessType.Blob);

            var uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
            BlobClient blobClient = blobContainerClient.GetBlobClient(uniqueFileName);

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;
                await blobClient.UploadAsync(memoryStream, new BlobHttpHeaders { ContentType = file.ContentType });
            }

            // Confirm the file is in the container
            bool exists = await blobClient.ExistsAsync();
            if (!exists)
            {
                throw new Exception("Tải tệp lên không thành công. Tệp không tồn tại trong container.");
            }

            return blobClient.Uri.AbsoluteUri;
        }

    }

}
