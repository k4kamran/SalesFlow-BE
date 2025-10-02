using System.ComponentModel.DataAnnotations;

namespace HRManagementAPI.Models
{
    public class Designation
    {
        [Key]                                  // ✅ Primary Key
        public int Des_Code { get; set; }       // Unique integer code (PK)
        public string? Des_Name { get; set; }
        public string? Des_Description { get; set; }   // Description
        public string? Des_Grade { get; set; }         // Grade
        public decimal Des_Start_Sal { get; set; }    // Start Salary
        public decimal Des_Max_Sal { get; set; }      // Max Salary
        public decimal Des_Vba { get; set; }             // VBA Applicable
        public decimal Des_Fuel_Limit { get; set; }       // Fuel Limit
        public ICollection<User>? Users { get; set; }
    }
}
