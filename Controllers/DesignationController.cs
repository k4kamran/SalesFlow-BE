using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRManagementAPI.Data;
using HRManagementAPI.Models;

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

        // 🔹 GET ALL
        // GET: api/designations/get-all-designations
        [HttpGet("get-all-designations")]
        public async Task<ActionResult<IEnumerable<Designation>>> GetDesignations()
        {
            return await _context.Designations.ToListAsync();
        }

        // 🔹 GET BY ID
        // GET: api/designations/get-designation/{id}
        [HttpGet("get-designation/{id}")]
        public async Task<ActionResult<Designation>> GetDesignation(int id)
        {
            var designation = await _context.Designations
                .FirstOrDefaultAsync(d => d.Des_Code == id);

            if (designation == null)
            {
                return NotFound(new { message = "Designation not found" });
            }

            return designation;
        }

        // 🔹 CREATE
        // POST: api/designations/create-designation
        [HttpPost("create-designation")]
        public async Task<ActionResult<Designation>> CreateDesignation(Designation designation)
        {
            _context.Designations.Add(designation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDesignation), new { id = designation.Des_Code }, designation);
        }

        // 🔹 UPDATE
        // PUT: api/designations/update-designation/{id}
        [HttpPut("update-designation/{id}")]
        public async Task<IActionResult> UpdateDesignation(int id, Designation designation)
        {
            if (id != designation.Des_Code)
            {
                return BadRequest(new { message = "Designation ID mismatch" });
            }

            _context.Entry(designation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Designations.Any(d => d.Des_Code == id))
                {
                    return NotFound(new { message = "Designation not found" });
                }
                else
                {
                    throw;
                }
            }

            return Ok(new { message = "Designation updated successfully" });
        }

        // 🔹 DELETE
        // DELETE: api/designations/delete-designation/{id}
        [HttpDelete("delete-designation/{id}")]
        public async Task<IActionResult> DeleteDesignation(int id)
        {
            var designation = await _context.Designations.FindAsync(id);
            if (designation == null)
            {
                return NotFound(new { message = "Designation not found" });
            }

            _context.Designations.Remove(designation);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Designation deleted successfully" });
        }
    }
}
