using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace DemoG01.BusinessLogic.DTOs
{
    public class RoleDetailsDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime DateOfCreation { get; set; }

        public DateTime? LastUpdate { get; set; }
    }
}
