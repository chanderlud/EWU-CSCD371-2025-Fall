using Xunit;

namespace Logger.Tests;

public class StudentTests
{
    [Fact]
    public void Constructor_ValidArguments_SetsProperties()
    {
        FullName name = new("Lisa", null, "Simpson");
        Student student = new(name, 4.0f);

        Assert.Equal(name, student.FullName);
        Assert.Equal("Lisa Simpson", student.Name);
        Assert.Equal(4.0f, student.GPA);
    }

    [Theory]
    [InlineData(-1f)]
    [InlineData(4.1f)]
    public void Constructor_InvalidGpa_ThrowsArgumentException(float gpa)
    {
        FullName name = new("Milhouse", null, "Van Houten");
        Assert.Throws<ArgumentException>(() => new Student(name, gpa));
    }
}
