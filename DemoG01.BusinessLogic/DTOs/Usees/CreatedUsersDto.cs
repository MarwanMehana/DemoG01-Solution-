using System;

namespace DemoG01.BusinessLogic.DTOs
{
    public class CreatedUserDto
    {
        public string UserName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public int RoleId { get; set; }

        public DateTime DateOfCreation { get; set; } = DateTime.UtcNow;
    }
}
