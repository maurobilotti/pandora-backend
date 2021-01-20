using Pandora.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pandora.Services.Interfaces
{
    public interface ICityService
    {
        Task<List<City>> GetCities();
        Task<City> GetCity(int id);
        Task<bool> DeleteCity(int id);
        Task<City> SaveCity(City city);
        Task<City> UpdateCity(int id, City newCity);
    }
}