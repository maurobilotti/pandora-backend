using Microsoft.EntityFrameworkCore;
using Pandora.Models;
using Pandora.Models.Entities;
using Pandora.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pandora.Services
{
    public class CityService : ICityService
    {
        private PandoraDbContext dbContext;

        public CityService(PandoraDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #region Service Methods
        public async Task<List<City>> GetCities()
        {
            return await this.dbContext.Cities.ToListAsync();
        }

        public async Task<City> GetCity(int id)
        {
            return await this.dbContext.Cities.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<City> SaveCity(City city)
        {
            this.dbContext.Cities.Add(city);

            await dbContext.SaveChangesAsync();

            return city;
        }

        public async Task<bool> DeleteCity(int id)
        {
            var result = true;
            try
            {
                var city = await this.dbContext.Cities.SingleOrDefaultAsync(x => x.Id == id);
                this.dbContext.Cities.Remove(city);

                await dbContext.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                result = false;
            }

            return result;
        }

        public async Task<City> UpdateCity(int id, City newCity)
        {
            var oldCity = await this.dbContext.Cities.SingleOrDefaultAsync(x => x.Id == id);

            if (oldCity != null)
            {
                oldCity.Name = newCity.Name;
                await dbContext.SaveChangesAsync();
            }

            return oldCity;
        }
        #endregion
    }
}
