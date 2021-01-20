using Microsoft.AspNetCore.Mvc;
using Pandora.Models.Entities;
using Pandora.Services.Interfaces;
using System.Threading.Tasks;

namespace Pandora.Controllers
{
    [Route("api/city")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private ICityService cityService;

        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var citys = await cityService.GetCities();
            return new OkObjectResult(citys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var city = await cityService.GetCity(id);

            if (city == null)
                return new NotFoundObjectResult($"Id: {id} not found");

            return new OkObjectResult(city);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] City city)
        {
            var result = await cityService.SaveCity(city);

            return new OkObjectResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] City city)
        {
            var oldDepartment = await cityService.GetCity(id);

            if (oldDepartment == null)
                return new NotFoundObjectResult($"Id: {id} not found");

            var result = await cityService.UpdateCity(id, city);

            return new OkObjectResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var city = await cityService.GetCity(id);

            if (city == null)
                return new NotFoundObjectResult($"Id: {id} not found");

            var result = await cityService.DeleteCity(id);

            return new OkObjectResult(result);
        }
    }
}
