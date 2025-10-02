using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagementAPI.Models
{
    [Table("DEPARTMENTS")]



    public class Department
    {
        [Key]
        public int Dep_Code { get; set; }

        public string? Dep_Name { get; set; }

        public string? Dep_Short_Name { get; set; }

        public string? Dep_Location { get; set; }

        public string? Dep_Number { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
