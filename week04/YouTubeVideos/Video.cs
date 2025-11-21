public class Video
{
    // Attributes/Properties
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthSeconds { get; set; } // Length in seconds

    // Private field to hold the list of comments
    private List<Comment> _comments = new List<Comment>();

    // Constructor
    public Video(string title, string author, int lengthSeconds)
    {
        Title = title;
        Author = author;
        LengthSeconds = lengthSeconds;
    }

    // Method to add a comment to the video's internal list
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Method to return the number of comments
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    // Method to return the list of comments
    public List<Comment> GetAllComments()
    {
        return _comments;
    }
}