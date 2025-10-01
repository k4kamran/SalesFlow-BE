using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRManagementAPI.Data;
using HRManagementAPI.Models;

namespace HRManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UsersController(AppDbContext context) => _context = context;

        // 🔹 GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetUsers()
        {
            var users = await _context.USER_DETAILS
                .Select(u => new
                {
                    u.User_Code,
                    u.User_Name,
                    u.User_FirstName,
                    u.User_LastName,
                    u.User_Gender,
                    u.User_Email,
                    u.User_Mobile,
                    u.User_Designation,
                    u.User_Designation_Name,
                    u.User_Designation_Desc
                })
                .ToListAsync();

            return Ok(users);
        }

        // 🔹 POST: api/users
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            _context.USER_DETAILS.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsers), new { id = user.User_Code }, user);
        }
    }
}
