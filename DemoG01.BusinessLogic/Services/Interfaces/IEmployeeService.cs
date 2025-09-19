using DemoG01.BusinessLogic.DTOs.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG01.BusinessLogic.Services.Interfaces
{
    internal interface IEmployeeService
    {
        int UpdateEmployee(UpdatedEmployeeDto employeeDto);

        public interface IEmployeeService
        {
            IEnumerable<EmployeeDto> GetAllEmployees(bool withTracking = false);
            EmployeeDetailsDto? GetEmployeeById(int id);
            int CreateEmployee(CreatedEmployeeDto employeeDto);
            int UpdateEmployee(EmployeeDto employeeDto);
            bool DeleteEmployee(int id);
        }
    }
}
