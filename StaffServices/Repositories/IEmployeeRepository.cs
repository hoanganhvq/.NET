using StaffServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StaffServices.Repositories
{
	public interface IEmployeeRepository
	{
		Task<IEnumerable<Employee>> GetEmployees();
		Task<Employee> GetEmployee(int employeeId);
		Task<EmployeeDTO> GetEmployeeDTO(int employeeId);
		Task<Employee> AddEmployee(Employee employee);
		Task<Employee> UpdateEmployee(Employee employee);
		Task<bool> DeleteEmployee(int employeeId);

	}
}
