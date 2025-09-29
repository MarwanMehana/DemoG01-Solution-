using DemoG01.DataAccess.Data.Contexts;
using DemoG01.DataAccess.Repositories.Departments;
using DemoG01.DataAccess.Repositories.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG01.DataAccess.Repositories.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private Lazy<IDepartmentRepository> _departmentRepository;
        private Lazy<IEmployeeRepository> _employeeRepository;
        private readonly ApplicationDbContext _dbcontext;

        public UnitOfWork(IDepartmentRepository departmentRepository,
    IEmployeeRepository employeeRepository,
    ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
            _departmentRepository = new Lazy<IDepartmentRepository>(() => new DepartmentRepository(_dbcontext));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(_dbcontext));
        }

        public IEmployeeRepository EmployeeRepository => _employeeRepository.Value;

        public IDepartmentRepository DepartmentRepository => _departmentRepository.Value;

        public int SaveChanges()
        {
            return _dbcontext.SaveChanges();
        }

        public IEnumerable<object> GetALL()
        {
            throw new NotImplementedException();
        }
    }
}