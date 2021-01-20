using Pandora.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pandora.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee> GetEmployee(int id);
        Task<List<Employee>> GetEmployees();
        Task<Employee> SaveEmployee(Employee employee);
        Task<bool> DeleteEmployee(int id);
        Task<Employee> UpdateEmployee(int id, Employee newEmployee);
    }
}