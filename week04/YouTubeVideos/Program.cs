using System;

using System.Collections.Generic;
using System.Reflection.PortableExecutable;

public class Program
{
    public static void Main(string[] args)
    {
        // Videos with its comments.
        Video video1 = new Video("C# Basics: Understanding Classes", "CodeMaster Academy", 600);
        Video video2 = new Video("Nature's Wonders: Alaskan Wildlife", "Explorer Diaries", 1250);
        Video video3 = new Video("Baking 101: The Perfect Sourdough", "Culinary Creations", 850);

        // Video 1 Comments
        video1.AddComment(new Comment("AlexT", "Great explanation of abstraction!"));
        video1.AddComment(new Comment("SarahM", "This helped me a lot with my assignment."));
        video1.AddComment(new Comment("DevGuy77", "Could you make a video on interfaces next?"));

        // Video 2 Comments
        video2.AddComment(new Comment("WildlifeFan", "The quality is stunning, amazing shots!"));
        video2.AddComment(new Comment("Traveler22", "I wish I could go there someday."));
        video2.AddComment(new Comment("BearWatcher", "That grizzly bear segment was intense!"));
        video2.AddComment(new Comment("PhotogPro", "What camera gear did you use?"));

        // Video 3 Comments
        video3.AddComment(new Comment("BakerGal", "Followed the recipe exactly, worked perfectly!"));
        video3.AddComment(new Comment("Sam_Cooks", "My crust turned out a little flat, any tips?"));
        video3.AddComment(new Comment("Foodie_FTW", "Best sourdough tutorial on YouTube."));

        // Put videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Iterate through the list of videos and display the information
        Console.WriteLine("--- YouTube Video & Comment Tracker ---");
        Console.WriteLine();

        foreach (Video video in videos)
        {
            Console.WriteLine("-------------------------------------");
            // Display Video Details
            Console.WriteLine($"Title: **{video.Title}**");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthSeconds} seconds");

            // Call the method to get the number of comments
            Console.WriteLine($"Number of Comments: **{video.GetNumberOfComments()}**");
            Console.WriteLine();

            // List out all comments
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetAllComments())
            {
                // Format: Name - "Text of the comment"
                Console.WriteLine($"- {comment.Name}: \"{comment.Text}\"");
            }
            Console.WriteLine();
        }
        Console.WriteLine("-------------------------------------");
    }
}