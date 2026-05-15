using EMSapi.Data;
using EMSapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMSapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EMSController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EMSController(ApplicationDbContext context)
        {
            _context = context;

        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            return await _context.Employees.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null) return NotFound();
            return employee;

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int Id, Employee employee)
        {

            if (Id != employee.Id)
            {
                return BadRequest();
            }
            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Employees.Any(e => e.Id == employee.Id))
                {
                    return NotFound();
                }
                throw;
            }
            return NoContent();



            
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee (int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool EmployeeExists(object id)
        {
            throw new NotImplementedException();
        }
    }
}
