﻿using EmployeeDirectory.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace EmployeeDirectory.Persistence.Services
{
    /// <inheritdoc/>
    public class FileUploader : IFileUploader
    {
        public IFormFile File { get; set; } = null!;
        public string AbsolutePath { get; set; } = string.Empty;
        public string WebRootPath { get; set; } = string.Empty;

        public async Task<string> UploadFileAsync()
        {
            var fileExtension = Path.GetExtension(File.FileName);
            var fileNameHash = Guid.NewGuid().ToString();
            var fullName = fileNameHash + fileExtension;
            string path = Path.Combine(AbsolutePath, fullName);

            Directory.CreateDirectory(Path.Combine(WebRootPath, AbsolutePath));

            using (var fileStream = new FileStream(Path.Combine(WebRootPath, path), FileMode.Create))
            {
                await File.CopyToAsync(fileStream);
            }

            return fullName;
        }
    }
}
