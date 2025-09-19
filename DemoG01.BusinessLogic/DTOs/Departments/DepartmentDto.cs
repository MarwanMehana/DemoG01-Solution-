using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG01.BusinessLogic.DataTransferObjects
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public DateOnly DateofCreation { get; set; }
    }
}
