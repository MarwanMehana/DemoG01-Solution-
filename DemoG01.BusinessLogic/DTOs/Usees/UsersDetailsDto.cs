using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG01.BusinessLogic.DTOs
{
    public class UserDetailsDto
    {
        public int Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string RoleName { get; set; } = string.Empty;

        public DateTime DateOfCreation { get; set; }

        public DateTime? LastLogin { get; set; }   
    }
}
