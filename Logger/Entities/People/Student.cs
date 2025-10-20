namespace Logger.Entities.People;

public record class Student : Person
{
    public float Gpa { get; init; }

    public Student(FullName fullName, float gpa) : base(fullName)
    {
        if (gpa < 0 || gpa > 4.0) throw new ArgumentOutOfRangeException(nameof(gpa), "GPA must be between 0 and 4.0");
        Gpa = gpa;
    }
}
