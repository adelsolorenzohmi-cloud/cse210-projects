// WritingAssignment.cs

// Inherits from Assignment
public class WritingAssignment : Assignment
{
    private string _title;

    // Derived class constructor calls the base class constructor using 'base()'
    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    // Writing-specific method
    public string GetWritingInformation()
    {
        // Accesses the protected _studentName attribute from the base class
        return $"{_title} by {_studentName}";
    }
}