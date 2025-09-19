using DemoG01.DataAccess.Models.Departments;
using DemoG01.DataAccess.Models.Employees;
using DemoG01.DataAccess.Repositories.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG01.DataAccess.Repositories.Employees
{
    public interface IEmployeeRepository: IGenericRepository<Employee>
    {
       
    }
}
