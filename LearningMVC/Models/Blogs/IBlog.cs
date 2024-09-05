using System.ComponentModel.DataAnnotations.Schema;

namespace LearningMVC.Models.Blogs;

public interface IBlog
{
    [Column("id")]
    public int Id { get; set; }
    
    [Column("title")]

    public string? Title { get; set; }
    
    [Column("content")]
    public string? Content { get; set; }

    public bool IsEmpty();
}