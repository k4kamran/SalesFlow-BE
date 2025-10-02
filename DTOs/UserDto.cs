public class UserDto
{
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

    public int Company_Code { get; set; }
    public string? Company_Name { get; set; }

    public int dep_code { get; set; }
    public string? dep_name { get; set; }
    public string? dep_short_name { get; set; }
}
public class UserCreateDto
{
    public string? User_Name { get; set; }
    public string? User_FirstName { get; set; }
    public string? User_LastName { get; set; }
    public string? User_Gender { get; set; }
    public string? User_Email { get; set; }
    public string? User_Mobile { get; set; }
    public int? User_Designation { get; set; }
    public string? User_Designation_Name { get; set; }
    public string? User_Designation_Desc { get; set; }

    public int Company_Code { get; set; }
    public int dep_code { get; set; }
}