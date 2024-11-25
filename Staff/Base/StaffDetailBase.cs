using Staff.Components;
using Staff.Services;
using Staff.Models;
using Microsoft.AspNetCore.Components;

namespace Staff.Base{
    public class StaffDetailBase :ComponentBase{
        public EmployeeDTO staff { get; set; }  = new EmployeeDTO();
        [Inject]
        public IStaffService StaffService { get; set; }

        [Parameter]
        public string Id { get; set; }
        protected override async Task OnInitializedAsync(){
            Id = Id ?? "1";
            staff = await StaffService.GetEmployeeDTO(int.Parse(Id));
        }
        public async Task DeleteStaff(int id){
            await StaffService.DeleteEmployee(id);
            //Navigate to the list page or show a success message
            // NavigationManager.NavigateTo("/staff");
        }

 
    }
}