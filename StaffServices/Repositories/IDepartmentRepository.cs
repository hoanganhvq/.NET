using StaffServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StaffServices.Repositories
{
    public  interface IDepartmentRepository
    {
       IEnumerable<Department> GetDepartments();
        Department GetDepartment(int departmentId);
     }
}