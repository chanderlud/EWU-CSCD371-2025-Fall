namespace Logger;

public record class Student : Person
{
    public float GPA { get; init; }

    public Student(FullName fullName, float gpa) : base(fullName)
    {
        if (gpa < 0 || gpa > 4.0) throw new ArgumentException("GPA must be between 0 and 4.0");
        GPA = gpa;
    }
}
