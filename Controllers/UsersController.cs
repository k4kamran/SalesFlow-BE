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

[HttpGet]
public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
{
    var users = await _context.USER_DETAILS
        .Include(u => u.Company_Model)
        .Include(u => u.Department_Model)
        .Select(u => new UserDto
        {
            User_Code = u.User_Code,
            User_Name = u.User_Name,
            User_FirstName = u.User_FirstName,
            User_LastName = u.User_LastName,
            User_Gender = u.User_Gender,
            User_Email = u.User_Email,
            User_Mobile = u.User_Mobile,
            User_Designation = u.User_Designation,
            User_Designation_Name = u.User_Designation_Name,
            User_Designation_Desc = u.User_Designation_Desc,
            Company_Code = u.Company_Code,
            Company_Name = u.Company_Model.Company_Name,
            dep_code = u.dep_code,
            dep_name = u.Department_Model.Dep_Name,
            dep_short_name = u.Department_Model.Dep_Short_Name
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
