using LearningMVC.Models.Blogs;

namespace LearningMVC.Factories;

public class BlogFactory
{
    public static Blog CreateNoBlog()
    {
        return new NoBlog
        {
            Id = 0,
            Title = null,
            Content = null
        };
    }
}