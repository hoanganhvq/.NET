namespace Staff.Models;

public partial class EmployeeDTO
{
	public int EmployeeId { get; set; }
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;
	public string Email { get; set; } = null!;
	public DateTime DateOfBirth { get; set; }
	public int DepartmentId { get; set; }
	public int GenderId { get; set; }
	public string? DepartmentName { get; set; } // Chỉ lấy tên phòng ban
	public string? GenderName { get; set; } // Chỉ lấy tên giới tính
}