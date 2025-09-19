using DemoG01.DataAccess.Data.Contexts;
using DemoG01.DataAccess.Models.Departments;
using DemoG01.DataAccess.Models.Employees;
using DemoG01.DataAccess.Repositories.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG01.DataAccess.Repositories.Employees
{
    internal class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}