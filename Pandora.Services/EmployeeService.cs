using Microsoft.EntityFrameworkCore;
using Pandora.Models;
using Pandora.Models.Entities;
using Pandora.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pandora.Services
{
    public class EmployeeService : IEmployeeService
    {
        private PandoraDbContext dbContext;

        public EmployeeService(PandoraDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #region Service Methods

        public async Task<List<Employee>> GetEmployees()
        {
            return await this.dbContext.Employees
                        .Include(x => x.Department)
                            .ThenInclude(x => x.City)
                        .ToListAsync();
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await this.dbContext.Employees
                .Include(x => x.Department)
                            .ThenInclude(x => x.City)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Employee> SaveEmployee(Employee employee)
        {
            this.dbContext.Employees.Add(employee);

            if (employee.Department != null)
            {
                this.dbContext.Entry(employee.Department).State = EntityState.Unchanged;
                if(employee.Department.City != null)
                    this.dbContext.Entry(employee.Department.City).State = EntityState.Unchanged;
            }

            await dbContext.SaveChangesAsync();

            return employee;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var result = true;
            try
            {
                var employee = await this.dbContext.Employees.SingleOrDefaultAsync(x => x.Id == id);

                if (employee.Department != null)
                {
                    this.dbContext.Entry(employee.Department).State = EntityState.Unchanged;
                    if (employee.Department.City != null)
                        this.dbContext.Entry(employee.Department.City).State = EntityState.Unchanged;
                }

                this.dbContext.Employees.Remove(employee);

                await dbContext.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                result = false;
            }

            return result;
        }

        public async Task<Employee> UpdateEmployee(int id, Employee newEmployee)
        {
            var oldEmployee = await this.dbContext.Employees.SingleOrDefaultAsync(x => x.Id == id);

            if (oldEmployee != null)
            {
                if (oldEmployee.Department != null)
                {
                    this.dbContext.Entry(oldEmployee.Department).State = EntityState.Modified;
                }                

                oldEmployee.FirstName = newEmployee.FirstName;
                oldEmployee.LastName = newEmployee.LastName;
                oldEmployee.PhoneNumber = newEmployee.PhoneNumber;
                oldEmployee.Salary = newEmployee.Salary;
                oldEmployee.Role = newEmployee.Role;
                oldEmployee.Department = newEmployee.Department;

                await dbContext.SaveChangesAsync();
            }

            return oldEmployee;
        }
        #endregion
    }
}
