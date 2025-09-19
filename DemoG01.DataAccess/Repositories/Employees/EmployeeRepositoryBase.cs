using DemoG01.DataAccess.Models.Employees;

namespace DemoG01.DataAccess.Repositories.Employees
{
    internal class EmployeeRepositoryBase
    {
        // Get By Id
        public Employee? GetById(int id, Employee? employee, Employee? employee, Employee? employee)
        {
            var employee = _dbContext.Departments.Find(id);
            return employee;
        }
    }
}