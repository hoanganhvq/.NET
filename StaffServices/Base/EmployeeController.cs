using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StaffServices.Models;
using StaffServices.Repositories;
[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository employeeRepository;

    public EmployeeController(IEmployeeRepository employeeRepository)
    {
        this.employeeRepository = employeeRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployees()
    {
        try
        {
            Console.WriteLine("GetAllEmployees endpoint was called.");
            var employees = await employeeRepository.GetEmployees();
            return Ok(employees);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
        }
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<Employee>> GetEmployee(int id)
    {
        try
        {
            var result = await employeeRepository.GetEmployee(id);
            if (result == null)
                return NotFound();
            return result;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database");
        }
    }

    [HttpPost]
    public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
    {
        try
        {
            if(employee == null)
            {
                return BadRequest();
            }
            var createEmployee = await employeeRepository.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = createEmployee.EmployeeId }, createEmployee);
        } catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database");
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
    {
        try
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest("EmployeeId mismatch");
            }
            var employeeToUpdate = await employeeRepository.GetEmployee(id);

            if (employeeToUpdate == null)
            {
                return NotFound($"Employee with Id = {id} not found");

            }
            return await employeeRepository.UpdateEmployee(employee);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error updated data");
        }
       
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> DeleteEmployee(int id)
    {
        try
        {
            var employeeToDelete = await employeeRepository.GetEmployee(id);

            if (employeeToDelete == null)
            {
                return NotFound($"Employee with Id = {id} not found");
            }

            return await employeeRepository.DeleteEmployee(id);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error deleting data");
        }
    }
}
