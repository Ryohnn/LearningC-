namespace LearningMVC.Models.Blogs;

public interface IBlog
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public bool IsEmpty();
}