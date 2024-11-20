using StaffServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace StaffServices.Repositories{

    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly StaffsContext staffsContext;

        public DepartmentRepository(StaffsContext staffsContext)
        {
            this.staffsContext = staffsContext;
        }

        public IEnumerable<Department> GetDepartments()
        {
            return staffsContext.Departments;
        }

        public Department GetDepartment(int departmentId)
        {
            return staffsContext.Departments.FirstOrDefault(d => d.DepartmentId == departmentId);
        }
    }
}