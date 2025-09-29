 using DemoG01.BusinessLogic.DTOs;
using DemoG01.BusinessLogic.DTOs.Departments;

namespace DemoG01.BusinessLogic.Services.Interfaces
{
    public interface IDepartmentServices
    {
        int AddDepartment(CreatedDepartmentDto departmentDto);
        bool DeleteDepartment(int id);
        IEnumerable<DepartmentDto> AllDepartments { get; }

        DepartmentDetailsDto? GetDepartmentById(int id);
        int UpdateDepartment(UpdatedDepartmentDto departmentDto);
        IEnumerable<DepartmentDto> AllDepartments1 { get; }
    }
}
