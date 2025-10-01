using Microsoft.EntityFrameworkCore;
using HRManagementAPI.Models;

namespace HRManagementAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<User> USER_DETAILS { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Company> Companies { get; set; }


    }
}
