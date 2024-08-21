using LearningMVC.Models;

namespace LearningMVC.Repositories
{
    public interface IBlogRepository
    {
        Task<List<Blog>?> GetBlogList();

        Task<Blog?> GetBlogById(int blogId);

        Task<int> Create(Blog blog);

        Task<int> Update(Blog blog);

        Task Delete(Blog blog);
    }
}
