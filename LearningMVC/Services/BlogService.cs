using LearningMVC.Models;
using LearningMVC.Repositories;

namespace LearningMVC.Services;

public class BlogService(IBlogRepository repo)
{
    public int Create(Blog blog)
    {
        repo.Add(blog);
        repo.SaveChanges();

        return blog.Id;
    }

    public Blog GetLatestBlog()
    {
        repo.GetLatest();
    }
}