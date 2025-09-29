using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG01.BusinessLogic.Services.Interfaces
{
    public interface IAttachmentService
    {
        // Upload
        public string Upload(IFormFile file, string folderName);
        // Delete
        public bool Delete(string filePath);
    }
}
