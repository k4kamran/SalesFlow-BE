namespace HRManagementAPI.DTOs
{
    public class DesignationDto
    {
        public int Des_Code { get; set; }
        public string? Des_Name { get; set; }
        public string? Des_Description { get; set; }
        public string? Des_Grade { get; set; }
        public decimal Des_Start_Sal { get; set; }
        public decimal Des_Max_Sal { get; set; }
        public decimal Des_Vba { get; set; }
        public decimal Des_Fuel_Limit { get; set; }
    }

    public class CreateDesignationDto
    {
        public string? Des_Name { get; set; }
        public string? Des_Description { get; set; }
        public string? Des_Grade { get; set; }
        public decimal Des_Start_Sal { get; set; }
        public decimal Des_Max_Sal { get; set; }
        public decimal Des_Vba { get; set; }
        public decimal Des_Fuel_Limit { get; set; }
    }

    public class UpdateDesignationDto
    {
        public string? Des_Name { get; set; }
        public string? Des_Description { get; set; }
        public string? Des_Grade { get; set; }
        public decimal Des_Start_Sal { get; set; }
        public decimal Des_Max_Sal { get; set; }
        public decimal Des_Vba { get; set; }
        public decimal Des_Fuel_Limit { get; set; }
    }
}
