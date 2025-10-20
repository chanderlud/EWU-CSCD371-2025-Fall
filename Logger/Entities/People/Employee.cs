namespace Logger.Entities.People;

public record class Employee : Person
{
    public float Salary { get; init; }

    public Employee(FullName fullName, float salary) : base(fullName)
    {
        if (salary <= 0) throw new ArgumentOutOfRangeException(nameof(salary), "Salary must be greater than 0");
        Salary = salary;
    }
}
