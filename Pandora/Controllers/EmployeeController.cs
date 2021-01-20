using Microsoft.AspNetCore.Mvc;
using Pandora.Models.Entities;
using Pandora.Services.Interfaces;
using System.Threading.Tasks;

namespace Pandora.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = await employeeService.GetEmployees();
            return new OkObjectResult(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await employeeService.GetEmployee(id);

            if (employee == null)
                return new NotFoundObjectResult($"Id: {id} not found");

            return new OkObjectResult(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee employee)
        {
            var result = await employeeService.SaveEmployee(employee);

            return new OkObjectResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Employee employee)
        {
            var oldEmployee = await employeeService.GetEmployee(id);

            if (oldEmployee == null)
                return new NotFoundObjectResult($"Id: {id} not found");

            var result = await employeeService.UpdateEmployee(id, employee);

            return new OkObjectResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await employeeService.GetEmployee(id);

            if (employee == null)
                return new NotFoundObjectResult($"Id: {id} not found");

            var result = await employeeService.DeleteEmployee(id);

            return new OkObjectResult(result);
        }
    }
}
