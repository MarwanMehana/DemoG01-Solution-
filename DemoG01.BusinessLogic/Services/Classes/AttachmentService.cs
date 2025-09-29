using DemoG01.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG01.BusinessLogic.Services.Classes
{
    public class AttachmentService : IAttachmentService
    {
        List<string> allowedExtensions = new List<string>();
        const int maxSize = 2 * 1024 * 1024;

        public string? Upload(IFormFile file, string folderName)
        {
            // 1. Check Extension
            var extension = Path.GetExtension(file.FileName);
            if (!allowedExtensions.Contains(extension))
            {
                return null;
            }

            // 2. Check Size
            if (file.Length > maxSize || file.Length == 0)
            {
                return null;
            }
            // 3. Get Located Folder Path
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", folderName);
            // 4. Get File Name (make file name unique)
            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            // 5. Get File Path
            var filePath = Path.Combine(folderPath, fileName);
            // 6. Create File Stream
            using FileStream fs = new FileStream(filePath, FileMode.Create);
            // 7. Copy File
            file.CopyTo(fs);
            // 8. Return file name
            return fileName;
        }
        public bool Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            return false;
        }
    }
}