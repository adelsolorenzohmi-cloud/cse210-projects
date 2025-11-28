// Assignment.cs

public class Assignment
{
    // Protected attributes are accessible by derived classes.
    protected string _studentName;
    protected string _topic;

    // Constructor
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // Method to return the summary
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}