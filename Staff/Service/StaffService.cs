using Staff.Models;

namespace Staff.Services{
    public class StaffService : IStaffService{
        private readonly HttpClient httpClient;

        public StaffService (HttpClient httpClient){
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Employee>>  GetEmployees(){
            return await httpClient.GetFromJsonAsync<Employee[]>("api/Employee");
        }

        public async Task<Employee> GetEmployee(int employeeId){
           return  await httpClient.GetFromJsonAsync<Employee>($"api/Employee/{employeeId}");
            
        }

        public async Task<HttpResponseMessage> AddEmployee(Employee employee){
            return await httpClient.PostAsJsonAsync<Employee>("api/Employee", employee);
        }

        public async Task<HttpResponseMessage> UpdateEmployee(Employee employee){
            return await httpClient.PutAsJsonAsync<Employee>($"api/Employee/{employee.EmployeeId}", employee);
        }
        public async Task<HttpResponseMessage> DeleteEmployee(int EmployeeId){
            var respone   = await httpClient.DeleteAsync($"api/Employee/{EmployeeId}");
            try{
                if(respone.IsSuccessStatusCode){
                    Console.WriteLine("Delete Successfully");
                }  else{
                    Console.WriteLine("Failed to delete");
                }
            } catch(Exception ex){
                Console.WriteLine(ex);
                
            }
            return respone;
        }


    }
}