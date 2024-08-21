using LearningMVC.Models;
using LearningMVC.Repositories;

namespace LearningMVC.Services;

public class BlogService(IBlogRepository repo) : IBlogService
{
    public async Task<List<Blog>?> GetBlogList()
        => await repo.GetBlogList();

    public async Task<Blog?> GetBlogById(int blogId)
        => await repo.GetBlogById(blogId);
    
    public async Task<int> Create(Blog blog)
    {
        await repo.Create(blog);
        return blog.Id;
    }
    
    public async Task<int> Update(Blog blog)
    {
        await repo.Update(blog);
        return blog.Id;
    }

    public async Task<int> Delete(int blogId)
    {
        var blog = await repo.GetBlogById(blogId);

        if (blog != null)
            await repo.Delete(blog);

        return blogId;
    }
}