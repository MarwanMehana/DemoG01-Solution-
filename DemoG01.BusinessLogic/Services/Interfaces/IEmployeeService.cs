using DemoG01.BusinessLogic.DTOs;
using DemoG01.BusinessLogic.DTOs.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG01.BusinessLogic.Services.Interfaces
{
    public interface IEmployeeService
    {
        string? AllRoles { get; }
        string? AllUsers { get; }

        int AddRole(CreatedRoleDto dto);
        int AddUser(CreatedUserDto dto);
        int CreateEmployee(CreatedEmployeeDto employeeDto);
        bool DeleteEmployee(int value);
        bool DeleteRole(int id);
        bool DeleteUser(int id);
        string? GetAllEmployees();
        string? GetAllEmployees(string? employeeSearchName);
        string? GetEmployeeById(int value);
        string? GetRoleById(int value);
        string? GetUserById(int value);
        void LogError();
        void LogError(string message);
        int UpdateEmployee(UpdatedEmployeeDto employeeDto);
        bool UpdateRole(UpdatedRoleDto dto);
        bool UpdateUser(UpdatedUserDto dto);

        public interface IEmployeeService
        {
            IEnumerable<EmployeeDto> GetAllEmployees(string? EmployeeSearchName,bool withTracking = false);
            EmployeeDetailsDto? GetEmployeeById(int id);
            int CreateEmployee(CreatedEmployeeDto employeeDto);
            int UpdateEmployee(EmployeeDto employeeDto);
            bool DeleteEmployee(int id);
        }
    }
}
