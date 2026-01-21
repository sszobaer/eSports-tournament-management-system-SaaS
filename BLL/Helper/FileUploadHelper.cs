using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Helper
{
    public static class FileUploadHelper
    {
        public static async Task<string?> SaveOrganizationLogoAsync(
            IFormFile? file,
            string rootPath,
            string folderName)
        {
            if (file == null)
                return null;

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var directoryPath = Path.Combine(rootPath, folderName);

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            var filePath = Path.Combine(directoryPath, fileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            return $"/{folderName}/{fileName}";
        }
    }

}
