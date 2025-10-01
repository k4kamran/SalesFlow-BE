using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagementAPI.Models
{
    [Table("COMPANIES")]
    public class Company
    {
        [Key]
        public int Company_Code { get; set; }

    
        public string? Company_Name { get; set; }
    }
}
