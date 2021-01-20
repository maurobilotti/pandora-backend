using Microsoft.EntityFrameworkCore;
using Pandora.Models;
using Pandora.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pandora.Services
{
    public class DepartmentService : IDepartmentService
    {
        private PandoraDbContext dbContext;

        public DepartmentService(PandoraDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #region Service Methods
        public async Task<List<Department>> GetDepartments()
        {
            return await this.dbContext.Departments
                        .Include(x => x.City)
                        .ToListAsync();
        }

        public async Task<Department> GetDepartment(int id)
        {
            return await this.dbContext.Departments
                .Include(x => x.City)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Department> SaveDepartment(Department department)
        {            
            this.dbContext.Departments.Add(department);

            if (department.City != null)
            {
                this.dbContext.Entry(department.City).State = EntityState.Unchanged;
            }

            await dbContext.SaveChangesAsync();

            return department;
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            var result = true;
            try
            {
                var department = await this.dbContext.Departments.SingleOrDefaultAsync(x => x.Id == id);
                this.dbContext.Entry(department.City).State = EntityState.Unchanged;
                this.dbContext.Departments.Remove(department);

                await dbContext.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                result = false;
            }

            return result;
        }

        public async Task<Department> UpdateDepartment(int id, Department newDepartment)
        {
            var oldDepartment = await this.dbContext.Departments.SingleOrDefaultAsync(x => x.Id == id);

            if (oldDepartment != null)
            {
                if (oldDepartment.City != null)
                {
                    this.dbContext.Entry(oldDepartment.City).State = EntityState.Modified;
                }

                oldDepartment.Name = newDepartment.Name;
                oldDepartment.City = newDepartment.City;

                await dbContext.SaveChangesAsync();
            }

            return oldDepartment;
        }
        #endregion
    }
}
