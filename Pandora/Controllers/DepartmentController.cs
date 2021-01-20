using Microsoft.AspNetCore.Mvc;
using Pandora.Models.Entities;
using Pandora.Services;
using System.Threading.Tasks;

namespace Pandora.Controllers
{
    [Route("api/department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private IDepartmentService departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var departments = await departmentService.GetDepartments();
            return new OkObjectResult(departments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var department = await departmentService.GetDepartment(id);

            if (department == null)
                return new NotFoundObjectResult($"Id: {id} not found");

            return new OkObjectResult(department);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Department department)
        {
            var result = await departmentService.SaveDepartment(department);

            return new OkObjectResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Department department)
        {
            var oldDepartment = await departmentService.GetDepartment(id);

            if (oldDepartment == null)
                return new NotFoundObjectResult($"Id: {id} not found");

            var result = await departmentService.UpdateDepartment(id, department);

            return new OkObjectResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var department = await departmentService.GetDepartment(id);

            if (department == null)
                return new NotFoundObjectResult($"Id: {id} not found");

            var result = await departmentService.DeleteDepartment(id);

            return new OkObjectResult(result);
        }
    }
}
