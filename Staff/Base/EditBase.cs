using Staff.Models;
using Staff.Services;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;

namespace Staff.Base
{
    public class EditBase : ComponentBase
    {
        public Employee staff { get; set; } = new Employee();

        [Inject]
        public IStaffService staffService { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            staff = await staffService.GetEmployee(int.Parse(Id)); 
        }

        public async Task UpdateStaff()
        {
            await staffService.UpdateEmployee(staff);
        }
    }
}
