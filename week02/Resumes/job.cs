public class Job
{
    //Member variables for the job's responsibilities
    public string _company = "";
    public string _jobTitle = "";
    public int _startYear;
    public int _endYear;

    // Displays job information in the required format
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}