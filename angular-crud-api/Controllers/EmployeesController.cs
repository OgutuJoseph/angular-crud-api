using angular_crud_api.Data;
using angular_crud_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace angular_crud_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly AngularCrudDbContext _angularCrudDbContext;

        public EmployeesController(AngularCrudDbContext angularCrudDbContext)
        {
            _angularCrudDbContext = angularCrudDbContext;
        }

        [HttpGet]
        public async Task <IActionResult> GetAllEmployees()
        {
            var employees = await _angularCrudDbContext.Employees.ToListAsync();

            return Ok(employees);
        }

        [HttpPost]
        public async Task <IActionResult> AddEmployee([FromBody] Employee employeeRequest)
        {
            employeeRequest.Id = Guid.NewGuid();

            await _angularCrudDbContext.Employees.AddAsync(employeeRequest);
            await _angularCrudDbContext.SaveChangesAsync();

            return Ok(employeeRequest);
        }
    }
}
