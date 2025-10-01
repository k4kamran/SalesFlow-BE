using Microsoft.AspNetCore.Mvc;
using HRManagementAPI.Models;
using HRManagementAPI.Data;

namespace HRManagementAPI.Controllers
{
    [Route("api/departments")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartmentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/departments
        [HttpGet]
        public IActionResult GetDepartments()
        {
            var departments = _context.Departments.ToList();
            return Ok(departments);
        }

        // GET: api/departments/5
        [HttpGet("{Dep_code}")]
        public IActionResult GetDepartment(int id)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
                return NotFound();

            return Ok(department);
        }

        // POST: api/departments
        [HttpPost]
        public IActionResult CreateDepartment([FromBody] Department department)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Departments.Add(department);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetDepartment), new { id = department.Dep_Code }, department);
        }

        // PUT: api/departments/5
        [HttpPut("{id}")]
        public IActionResult UpdateDepartment(int id, [FromBody] Department department)
        {
            if (id != department.Dep_Code)
                return BadRequest();

            var existingDepartment = _context.Departments.Find(id);
            if (existingDepartment == null)
                return NotFound();

            existingDepartment.Dep_Code = department.Dep_Code;
            existingDepartment.Dep_Name = department.Dep_Name;
            existingDepartment.Dep_Short_Name = department.Dep_Short_Name;
            existingDepartment.Dep_Location = department.Dep_Location;
            existingDepartment.Dep_Number = department.Dep_Number;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/departments/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
                return NotFound();

            _context.Departments.Remove(department);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
