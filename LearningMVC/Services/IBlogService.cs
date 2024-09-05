using LearningMVC.Models;
using LearningMVC.Models.Blogs;

namespace LearningMVC.Services;

public interface IBlogService
{
    public Task<List<Blog>?> GetBlogList();
    
    public Task<Blog?> GetBlogById(int blogId);

    public Task<int> Create(Blog blog);
    
    public Task<int> Update(Blog blog);
    
    public Task<int> Delete(int blogId);

}