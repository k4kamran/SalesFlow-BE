using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRManagementAPI.Data;
using HRManagementAPI.Models;
using HRManagementAPI.DTOs;

namespace HRManagementAPI.Controllers
{
    [ApiController]
    [Route("api/designations")]
    public class DesignationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DesignationsController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ GET ALL
        [HttpGet("get-all")]
        public async Task<ActionResult<IEnumerable<DesignationDto>>> GetDesignations()
        {
            var designations = await _context.Designations
                .Select(d => new DesignationDto
                {
                    Des_Code = d.Des_Code,
                    Des_Name = d.Des_Name,
                    Des_Description = d.Des_Description,
                    Des_Grade = d.Des_Grade,
                    Des_Start_Sal = d.Des_Start_Sal,
                    Des_Max_Sal = d.Des_Max_Sal,
                    Des_Vba = d.Des_Vba,
                    Des_Fuel_Limit = d.Des_Fuel_Limit
                })
                .ToListAsync();

            return Ok(designations);
        }

        // ✅ GET BY ID
        [HttpGet("get/{id}")]
        public async Task<ActionResult<DesignationDto>> GetDesignation(int id)
        {
            var d = await _context.Designations.FindAsync(id);
            if (d == null)
                return NotFound(new { message = "Designation not found" });

            var dto = new DesignationDto
            {
                Des_Code = d.Des_Code,
                Des_Name = d.Des_Name,
                Des_Description = d.Des_Description,
                Des_Grade = d.Des_Grade,
                Des_Start_Sal = d.Des_Start_Sal,
                Des_Max_Sal = d.Des_Max_Sal,
                Des_Vba = d.Des_Vba,
                Des_Fuel_Limit = d.Des_Fuel_Limit
            };

            return Ok(dto);
        }

        // ✅ CREATE
        [HttpPost("create")]
        public async Task<ActionResult<DesignationDto>> CreateDesignation(CreateDesignationDto dto)
        {
            var designation = new Designation
            {
                Des_Name = dto.Des_Name,
                Des_Description = dto.Des_Description,
                Des_Grade = dto.Des_Grade,
                Des_Start_Sal = dto.Des_Start_Sal,
                Des_Max_Sal = dto.Des_Max_Sal,
                Des_Vba = dto.Des_Vba,
                Des_Fuel_Limit = dto.Des_Fuel_Limit
            };

            _context.Designations.Add(designation);
            await _context.SaveChangesAsync();

            var responseDto = new DesignationDto
            {
                Des_Code = designation.Des_Code,
                Des_Name = designation.Des_Name,
                Des_Description = designation.Des_Description,
                Des_Grade = designation.Des_Grade,
                Des_Start_Sal = designation.Des_Start_Sal,
                Des_Max_Sal = designation.Des_Max_Sal,
                Des_Vba = designation.Des_Vba,
                Des_Fuel_Limit = designation.Des_Fuel_Limit
            };

            return CreatedAtAction(nameof(GetDesignation), new { id = designation.Des_Code }, responseDto);
        }

        // ✅ UPDATE
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateDesignation(int id, UpdateDesignationDto dto)
        {
            var designation = await _context.Designations.FindAsync(id);
            if (designation == null)
                return NotFound(new { message = "Designation not found" });

            designation.Des_Name = dto.Des_Name;
            designation.Des_Description = dto.Des_Description;
            designation.Des_Grade = dto.Des_Grade;
            designation.Des_Start_Sal = dto.Des_Start_Sal;
            designation.Des_Max_Sal = dto.Des_Max_Sal;
            designation.Des_Vba = dto.Des_Vba;
            designation.Des_Fuel_Limit = dto.Des_Fuel_Limit;

            await _context.SaveChangesAsync();

            return Ok(new { message = "Designation updated successfully" });
        }

        // ✅ DELETE
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteDesignation(int id)
        {
            var designation = await _context.Designations.FindAsync(id);
            if (designation == null)
                return NotFound(new { message = "Designation not found" });

            _context.Designations.Remove(designation);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Designation deleted successfully" });
        }
    }
}
