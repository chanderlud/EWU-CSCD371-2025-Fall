namespace Logger;

public record class Employee : Person
{
    public float Salary { get; init; }

    public Employee(FullName fullName, float salary) : base(fullName)
    {
        if (salary <= 0) throw new ArgumentException("Salary must be greater than 0");
        Salary = salary;
    }
}
