using Pandora.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pandora.Services
{
    public interface IDepartmentService
    {
        Task<Department> GetDepartment(int id);
        Task<List<Department>> GetDepartments();
        Task<bool> DeleteDepartment(int id);
        Task<Department> SaveDepartment(Department department);
        Task<Department> UpdateDepartment(int id, Department newDepartment);
    }
}