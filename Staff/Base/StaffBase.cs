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

        protected async Task DeleteEmployee(int employeeId){
            await StaffService.DeleteEmployee(employeeId);
            //Referesh to show list one more time
            Staffs = await StaffService.GetEmployees();
        }

        protected async Task AddEmployee(Employee employee){
            await StaffService.AddEmployee(employee);
            //Referesh to show list one more time
            Staffs = await StaffService.GetEmployees();
        }
    }
}