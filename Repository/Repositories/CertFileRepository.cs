using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using DataAccess.Context;

namespace Repository.Repositories
{
    public class CertFileRepository : ICertFileRepository
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _connectionString;
        private readonly string _containerName;
        private readonly TrixTutorDBContext _context;
        public CertFileRepository(IConfiguration configuration, TrixTutorDBContext context)
        {
            _connectionString = configuration["AzureBlobStorage:ConnectionString"];
            _containerName = configuration["AzureBlobStorage:ContainerName"];
            _blobServiceClient = new BlobServiceClient(_connectionString);
            _context = context;
        }

        public async Task<string> SaveFile(string containerName, IFormFile file)
        {
            containerName = _containerName; // Ensure the container name is correct

            BlobContainerClient blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            await blobContainerClient.CreateIfNotExistsAsync(PublicAccessType.Blob);

            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(uniqueFileName);

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;
                await blobClient.UploadAsync(memoryStream, new BlobHttpHeaders { ContentType = file.ContentType });
            }

            return blobClient.Uri.AbsoluteUri;
        }
        public async Task<string> GetFileExtensionAsync(IFormFile file)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file), "File cannot be null");
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
            var allowedExtensions = new Dictionary<string, long>
            {
                { ".jpg", 10 * 1024 * 1024 },   // 10 MB
                { ".jpeg", 10 * 1024 * 1024 },  // 10 MB
                { ".png", 10 * 1024 * 1024 },   // 10 MB
                { ".mp4", 20L * 1024 * 1024 * 1024 },
                { ".pdf", 50 * 1024 * 1024 },   // 50 MB (adjust as needed)
                { ".docx", 20 * 1024 * 1024 },  // 20 MB (adjust as needed)
                { ".doc", 20 * 1024 * 1024 }    // 20 MB (adjust as needed)
                // Add other file types and their size limits here
            };

            // Check file extension
            if (!allowedExtensions.ContainsKey(fileExtension))
            {
                throw new InvalidOperationException("Unsupported file format.");
            }
            long fileSize = file.Length;
            if (fileSize > allowedExtensions[fileExtension])
            {
                throw new InvalidOperationException($"File size exceeds the maximum allowed ({allowedExtensions[fileExtension]} bytes).");
            }

            if (fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png")
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
                throw new Exception("File upload failed. The file does not exist in the container.");
            }

            return blobClient.Uri.AbsoluteUri;
        }

        public async Task DeleteFile(string containerName, string fileRoute)
        {
            BlobContainerClient blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(fileRoute);

            await blobClient.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
        }

        public async Task<string> EditFile(string containerName, IFormFile file, string existingFilePath)
        {
            await DeleteFile(containerName, existingFilePath);
            return await SaveFile(containerName, file);
        }
        public async Task<string> SaveFileFromUrl(string url)
        {
            // Validate and verify the URL
            if (!Uri.TryCreate(url, UriKind.Absolute, out Uri validatedUri))
            {
                throw new ArgumentException("Invalid URL.");
            }

            // Create a HttpClient to download the file
            using (HttpClient client = new HttpClient())
            {
                // Get the file name from the URL
                string fileName = Path.GetFileName(validatedUri.LocalPath);

                // Download the file content
                byte[] fileBytes = await client.GetByteArrayAsync(validatedUri);

                // Determine the file extension (if needed)
                string fileExtension = Path.GetExtension(fileName).ToLower();

                // Define allowed file extensions (if needed)
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".mp4", ".pdf", ".docx", ".doc" };

                // Check file extension (if needed)
                if (!Array.Exists(allowedExtensions, ext => ext == fileExtension))
                {
                    throw new InvalidOperationException("Unsupported file format.");
                }

                // Determine container name based on file extension (if needed)
                string containerName = DetermineContainerName(fileExtension);

                // Upload the file to Blob storage or your preferred storage
                string fileUrl = await UploadFileToStorage(containerName, fileName, fileBytes);

                return fileUrl;
            }
        }

        private async Task<string> UploadFileToStorage(string containerName, string fileName, byte[] fileBytes)
        {
            // Ensure the container name is correct
            BlobContainerClient blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            await blobContainerClient.CreateIfNotExistsAsync(PublicAccessType.Blob);

            // Generate a unique file name (if needed)
            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(fileName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(uniqueFileName);

            // Upload the file bytes
            using (var memoryStream = new MemoryStream(fileBytes))
            {
                await blobClient.UploadAsync(memoryStream, new BlobHttpHeaders { ContentType = GetContentType(fileName) });
            }

            // Return the URL of the uploaded file
            return blobClient.Uri.AbsoluteUri;
        }

        private string DetermineContainerName(string fileExtension)
        {
            // Determine container name based on file extension (customize as needed)
            if (fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png")
            {
                return "image";
            }
            else if (fileExtension == ".mp4")
            {
                return "video";
            }
            else if (fileExtension == ".pdf")
            {
                return "pdf";
            }
            else if (fileExtension == ".docx" || fileExtension == ".doc")
            {
                return "word";
            }

            // Default container name (customize as needed)
            return "files";
        }

        private string GetContentType(string fileName)
        {
            // Determine content type based on file extension (customize as needed)
            if (Path.GetExtension(fileName).ToLower() == ".pdf")
            {
                return "application/pdf";
            }
            else if (Path.GetExtension(fileName).ToLower() == ".docx" || Path.GetExtension(fileName).ToLower() == ".doc")
            {
                return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            }
            else
            {
                return "application/octet-stream"; // Default content type
            }
        }
    }
}
