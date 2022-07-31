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

        [HttpPost]
        public async Task<IActionResult> Insert(Department department)
        {
            return Ok(await _repository.Insert(department));
        }
    }
}
