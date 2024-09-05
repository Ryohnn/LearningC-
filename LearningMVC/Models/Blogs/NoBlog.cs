namespace LearningMVC.Models.Blogs;

public class NoBlog : Blog
{
    public new bool IsEmpty()
    {
        return true;
    }
}