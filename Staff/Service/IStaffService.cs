using Staff.Models;

namespace Staff.Services{
    public interface IStaffService{
        Task<IEnumerable<Employee>>  GetEmployees();
        Task <Employee> GetEmployee(int employeeId);

        Task<HttpResponseMessage> AddEmployee(Employee employee);

       Task <HttpResponseMessage> DeleteEmployee(int employeeId);
    Task<HttpResponseMessage> UpdateEmployee(Employee employee);
    }
}