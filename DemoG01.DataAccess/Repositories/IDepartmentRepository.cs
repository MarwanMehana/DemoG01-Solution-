using DemoG01.DataAccess.Models;

namespace DemoG01.DataAccess.Repositries
{
    public interface IDepartmentRepository
    {
        int Add(Department department);
        IEnumerable<Department> GetALL(bool withTracking = false);
        Department? GetById(int id);
        int Remove(Department department);
        int Update(Department department);
    }
}