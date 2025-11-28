// MathAssignment.cs

// Inherits from Assignment
public class MathAssignment : Assignment
{
    private string _section;
    private string _problems;

    // Derived class constructor calls the base class constructor using 'base()'
    public MathAssignment(string studentName, string topic, string section, string problems)
        : base(studentName, topic)
    {
        _section = section;
        _problems = problems;
    }

    // Math-specific method
    public string GetHomeworkList()
    {
        return $"Section {_section} Problems {_problems}";
    }
}