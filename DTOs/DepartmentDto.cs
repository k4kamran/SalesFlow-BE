namespace HRManagementAPI.DTOs
{
    public class DepartmentDto
    {
        public int Dep_Code { get; set; }
        public string? Dep_Name { get; set; }
        public string? Dep_Short_Name { get; set; }
        public string? Dep_Location { get; set; }
        public string? Dep_Number { get; set; }
    }

    public class CreateDepartmentDto
    {
        public string? Dep_Name { get; set; }
        public string? Dep_Short_Name { get; set; }
        public string? Dep_Location { get; set; }
        public string? Dep_Number { get; set; }
    }

    public class UpdateDepartmentDto
    {
        public string? Dep_Name { get; set; }
        public string? Dep_Short_Name { get; set; }
        public string? Dep_Location { get; set; }
        public string? Dep_Number { get; set; }
    }
}
