using DLL.Model;
using DLL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CourseUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentsController(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await _repository.GetAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync(Department department)
        {
            return Ok(await _repository.InsertAsync(department));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Department department)
        {
            var departmentUpdate = await _repository.UpdateAsync(id, department);
            if (departmentUpdate == null)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var department = await _repository.Delete(id);
            if (department == null)
                return NotFound();
            return NoContent();
        }
    }
}
