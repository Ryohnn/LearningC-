namespace LearningMVC.Models.Blogs
{
    public class Blog : object, IBlog
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public bool IsEmpty()
        {
            return false;
        }
    }
}
