using Moq;
using StaffServices.Models;
using StaffServices.Repositories;

public class StaffTestingRepository
{
    private readonly Mock<IEmployeeRepository> mock;
    private readonly IEmployeeRepository employeeRepository;

    private readonly StaffsContext staffsContext;

    public static List<Employee> expectedList { get; set; }


    public StaffTestingRepository()
    {
        mock = new Mock<IEmployeeRepository>();

        expectedList = new List<Employee>
            {
                new Employee { EmployeeId = 1, FirstName = "Anh", LastName = "Phan", DateOfBirth = new DateTime(2004, 7, 15), DepartmentId = 1, GenderId = 1, Email = "long.doe376@example.com" },
                new Employee { EmployeeId = 2, FirstName = "Cuong", LastName = "Vuong", DateOfBirth = new DateTime(2004, 10, 4), DepartmentId = 4, GenderId = 1, Email = "dai.doe376@example.com" },
                new Employee { EmployeeId = 3, FirstName = "Long", LastName = "Nguyen", DateOfBirth = new DateTime(2004, 10, 5), DepartmentId = 4, GenderId = 2, Email = "luc.doe376@example.com" },

            };
    }
    //Exercise 1

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]


    public async Task GetStaffById(int id)
    {
        var expectedStaff = expectedList.FirstOrDefault(emp => emp.EmployeeId == id);

        mock.Setup(x => x.GetEmployee(id)).ReturnsAsync(expectedStaff);

        var result = await mock.Object.GetEmployee(id);

        Assert.NotNull(result);
        Assert.Equal(expectedStaff.EmployeeId, result.EmployeeId);
        Assert.Equal(expectedStaff.FirstName, result.FirstName);
    }
    //Exercise 2
    [Fact]
    public void AddStaff_Success()
    {
        var newStaff = new Employee
        {
            EmployeeId = 6,
            FirstName = "Phan",
            LastName = "Anh",
            DateOfBirth = new DateTime(2003, 7, 20),
            DepartmentId = 3,
            GenderId = 1,
            Email = "phananh@gmail.com"
        };

        mock.Setup(x => x.AddEmployee(newStaff)).Verifiable();

        mock.Object.AddEmployee(newStaff);

        mock.Verify(x => x.AddEmployee(newStaff), Times.Once);
    }
    //Exercise 3
    [Fact]
    public async Task AddStaff_NullData()
    {
        mock.Setup(x => x.AddEmployee(null)).Throws<ArgumentNullException>();

        await Assert.ThrowsAsync<ArgumentNullException>(() => mock.Object.AddEmployee(null));
    }
    //Exercise 4

    [Fact]
    public async Task GetAllStaffs_Succcess()
    {
        mock.Setup(x => x.GetEmployees()).ReturnsAsync(expectedList.AsEnumerable());

        var result = await mock.Object.GetEmployees();

        Assert.NotNull(result);
        Assert.Equal(expectedList.Count, result.Count());


    }

    [Fact]
    public async void GetAllStaffs_EmptyList()
    {
        mock.Setup(x => x.GetEmployees()).ReturnsAsync(new List<Employee>().AsEnumerable());

        var result = await mock.Object.GetEmployees();

        Assert.NotNull(result);
        Assert.Empty(result);
    }

    //Exercise 5

    [Fact]
    public async Task UpdateStaff_Success()
    {

        var existingStaff = expectedList.First();
        existingStaff.FirstName = "Anh"; // Update the name

        mock.Setup(x => x.UpdateEmployee(existingStaff)).ReturnsAsync(existingStaff);

        var result = await mock.Object.UpdateEmployee(existingStaff);


        Assert.NotNull(result);
        Assert.Equal("Anh", result.FirstName);
        mock.Verify(x => x.UpdateEmployee(existingStaff), Times.Once);
    }

    [Fact]
    public async Task UpdateStaff_NonExistingStaff()
    {
        var nonExistingStaff = new Employee
        {
            EmployeeId = 99,
            FirstName = "Anh",
        };

        mock.Setup(x => x.UpdateEmployee(nonExistingStaff)).Throws<InvalidOperationException>();

        await Assert.ThrowsAsync<InvalidOperationException>(() => mock.Object.UpdateEmployee(nonExistingStaff));
    }

    [Fact]
    public async Task UpdateStaff_NullStaff()
    {
        mock.Setup(x => x.UpdateEmployee(null)).Throws<ArgumentNullException>();

        await Assert.ThrowsAsync<ArgumentNullException>(() => mock.Object.UpdateEmployee(null));
    }
    // Exercise 7
    [Fact]
    public async Task DeleteStaff_Success()
    {
        var existingStaffId = 1;
        mock.Setup(x => x.DeleteEmployee(existingStaffId)).ReturnsAsync(true);

        var result = await mock.Object.DeleteEmployee(existingStaffId);

        Assert.True(result);
        mock.Verify(x => x.DeleteEmployee(existingStaffId), Times.Once);
    }

    [Fact]
    public async Task DeleteStaff_NonExistingStaff()
    {

        var nonExistingStaffId = 100;
        mock.Setup(x => x.DeleteEmployee(nonExistingStaffId)).ReturnsAsync(false);

        var result = await mock.Object.DeleteEmployee(nonExistingStaffId);

        Assert.False(result);
    }

    [Fact]
    public async Task DeleteStaff_InvalidId()
    {
        var invalidStaffId = -1;
        mock.Setup(x => x.DeleteEmployee(invalidStaffId)).ThrowsAsync(new ArgumentOutOfRangeException());

        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => mock.Object.DeleteEmployee(invalidStaffId));
    }


}
