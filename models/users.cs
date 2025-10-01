using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagementAPI.Models
{
    [Table("USER_DETAILS")] 
    public class User
    {
        [Key]
        public int? User_Code { get; set; }
        public string? User_Name { get; set; }
        public string? User_FirstName { get; set; }
        public string? User_LastName { get; set; }
        public string? User_Gender { get; set; }
        public string? User_Email { get; set; }
        public string? User_Mobile { get; set; }
        public int? User_Designation { get; set; }
        public string? User_Designation_Name { get; set; }
        public string? User_Designation_Desc { get; set; }
    }
}
