using Staff.Services;
using System.Collections.Generic;
using Staff.Models;
using Microsoft.AspNetCore.Components;
namespace Staff.Base{
    public class StaffBase : ComponentBase{
        [Inject]
        public IStaffService StaffService { get; set; }

        public IEnumerable<Employee> Staffs { get; set; }


        protected override async Task OnInitializedAsync()
        {
            Staffs = await StaffService.GetEmployees();
        }
        protected async Task<Employee> GetEmployee(int id){
            return await StaffService.GetEmployee(id);
        }

        protected async Task DeleteEmployee(int employeeId){
            await StaffService.DeleteEmployee(employeeId);
            Staffs = await StaffService.GetEmployees();
        }

        protected async Task AddEmployee(Employee employee){
            await StaffService.AddEmployee(employee);
            Staffs = await StaffService.GetEmployees();
        }
    }
}