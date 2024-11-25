using StaffServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StaffServices.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly StaffsContext staffsContext;

        public EmployeeRepository(StaffsContext staffsContext)
        {
            this.staffsContext = staffsContext;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return staffsContext.Employees;
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            return (from employee in staffsContext.Employees
                    where employee.EmployeeId == employeeId
                    select employee).First();

        }

        public async Task<EmployeeDTO?> GetEmployeeDTO(int employeeId)
        {
            var employee = await staffsContext.Employees
                .Include(e => e.Department)
                .Include(e => e.Gender)
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

            if (employee == null) return null;

            return new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                DateOfBirth = employee.DateOfBirth,
                DepartmentId = employee.DepartmentId ?? 0,
                GenderId = employee.GenderId ?? 0,
                DepartmentName = employee.Department?.DepartmentName,
                GenderName = employee.Gender?.GenderDescription
            };
        }




        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await staffsContext.Employees.AddAsync(employee);
            await staffsContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await staffsContext.Employees
                    .FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId); if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.DateOfBirth = employee.DateOfBirth;
                result.GenderId = employee.GenderId;
                result.DepartmentId = employee.DepartmentId;

                await staffsContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

         public async Task<bool> DeleteEmployee(int id)
    {
        var result= await staffsContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId== id);
        if(result != null){
            staffsContext.Employees.Remove(result);
            await staffsContext.SaveChangesAsync();
            return true;
        }
        return false;
    }
    }
}