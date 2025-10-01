using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG01.BusinessLogic.DTOs
{
    public class UpdatedUserDto
    {
        public int Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? Password { get; set; } 

        public int RoleId { get; set; }

        public DateTime DateOfUpdate { get; set; } = DateTime.UtcNow;
    }
}