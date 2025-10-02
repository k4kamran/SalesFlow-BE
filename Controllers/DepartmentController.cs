using Microsoft.AspNetCore.Mvc;
using HRManagementAPI.Models;
using HRManagementAPI.Data;
using HRManagementAPI.DTOs;

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

        // GET: api/departments/get-all
        [HttpGet("get-all")]
        public IActionResult GetDepartments()
        {
            var departments = _context.Departments
                .Select(d => new DepartmentDto
                {
                    Dep_Code = d.Dep_Code,
                    Dep_Name = d.Dep_Name,
                    Dep_Short_Name = d.Dep_Short_Name,
                    Dep_Location = d.Dep_Location,
                    Dep_Number = d.Dep_Number
                })
                .ToList();

            return Ok(departments);
        }

        // GET: api/departments/get/{id}
        [HttpGet("get/{id}")]
        public IActionResult GetDepartment(int id)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
                return NotFound();

            var dto = new DepartmentDto
            {
                Dep_Code = department.Dep_Code,
                Dep_Name = department.Dep_Name,
                Dep_Short_Name = department.Dep_Short_Name,
                Dep_Location = department.Dep_Location,
                Dep_Number = department.Dep_Number
            };

            return Ok(dto);
        }

        // POST: api/departments/create
        [HttpPost("create")]
        public IActionResult CreateDepartment([FromBody] CreateDepartmentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var department = new Department
            {
                Dep_Name = dto.Dep_Name,
                Dep_Short_Name = dto.Dep_Short_Name,
                Dep_Location = dto.Dep_Location,
                Dep_Number = dto.Dep_Number
            };

            _context.Departments.Add(department);
            _context.SaveChanges();

            var resultDto = new DepartmentDto
            {
                Dep_Code = department.Dep_Code,
                Dep_Name = department.Dep_Name,
                Dep_Short_Name = department.Dep_Short_Name,
                Dep_Location = department.Dep_Location,
                Dep_Number = department.Dep_Number
            };

            return CreatedAtAction(nameof(GetDepartment), new { id = department.Dep_Code }, resultDto);
        }

        // PUT: api/departments/update/{id}
        [HttpPut("update/{id}")]
        public IActionResult UpdateDepartment(int id, [FromBody] UpdateDepartmentDto dto)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
                return NotFound();

            department.Dep_Name = dto.Dep_Name;
            department.Dep_Short_Name = dto.Dep_Short_Name;
            department.Dep_Location = dto.Dep_Location;
            department.Dep_Number = dto.Dep_Number;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/departments/delete/{id}
        [HttpDelete("delete/{id}")]
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
