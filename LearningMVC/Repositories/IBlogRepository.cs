using LearningMVC.Models;

namespace LearningMVC.Repositories
{
    public interface IBlogRepository
    {
        Task<Blog?> GetBlogById(int? id);

        Task<List<Blog>?> GetBlogList();

        int Add(Blog blog);

        void Update(Blog blog);

        void Delete(Blog blog);

        Task SaveChanges();

        bool Exists(int id);

        IQueryable<object> GetLatest();
    }
}
