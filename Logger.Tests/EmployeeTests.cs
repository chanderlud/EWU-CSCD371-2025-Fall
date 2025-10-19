using Xunit;

namespace Logger.Tests;

public class EmployeeTests
{
    [Fact]
    public void Constructor_ValidArguments_SetsProperties()
    {
        FullName name = new("Homer", "J", "Simpson");
        Employee employee = new(name, 60000f);

        Assert.Equal(name, employee.FullName);
        Assert.Equal("Homer J Simpson", employee.Name);
        Assert.Equal(60000f, employee.Salary);
    }

    [Theory]
    [InlineData(0f)]
    [InlineData(-10f)]
    public void Constructor_InvalidSalary_ThrowsArgumentException(float salary)
    {
        FullName name = new("Carl", null, "Carlson");
        Assert.Throws<ArgumentException>(() => new Employee(name, salary));
    }
}
