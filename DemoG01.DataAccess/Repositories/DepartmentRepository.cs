using DemoG01.DataAccess.Data.Contexts;
using DemoG01.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG01.DataAccess.Repositries
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DepartmentRepository(ApplicationDbContext dbContext) //1. Injection
                                                                    // Ask CLR for Creating ApplicationDbContext obj
        {
            _dbContext = dbContext;
        }
        // CRUD Operations
        // Get All
        public IEnumerable<Department> GetALL(bool withTracking = false)
        {
            if (withTracking)
            {
                return _dbContext.Departments.ToList();
            }
            else
            {
                return _dbContext.Departments.AsNoTracking().ToList();
            }
        }
        // Get By Id
        public Department? GetById(int id)
        {
            var department = _dbContext.Departments.Find(id);
            return department;
        }

        // Insert
        public int Add(Department department)
        {
            _dbContext.Departments.Add(department);
            return _dbContext.SaveChanges();
        }
        // Update
        public int Update(Department department)
        {
            _dbContext.Update(department);
            return _dbContext.SaveChanges();
        }
        // Remove
        public int Remove(Department department)
        {
            _dbContext.Departments.Remove(department);
            return _dbContext.SaveChanges();
        }
    }
}