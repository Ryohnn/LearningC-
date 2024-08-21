using LearningMVC.Data;
using LearningMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningMVC.Repositories
{
    public class BlogRepository(LearningMvcContext context) : IBlogRepository
    {
        public async Task<List<Blog>?> GetBlogList()
            => await context.Blog.ToListAsync();

        public async Task<Blog?> GetBlogById(int blogId)
            => await context.Blog.FirstOrDefaultAsync(b => b.Id == blogId);

        public async Task<int> Create(Blog blog)
        {
            await context.Blog.AddAsync(blog);
            await context.SaveChangesAsync();
            return blog.Id;
        }

        public async Task<int> Update(Blog blog)
        {
            context.Blog.Update(blog);
            await context.SaveChangesAsync();
            return blog.Id;
        }

        public async Task Delete(Blog blog)
        {
            context.Blog.Remove(blog);
            await context.SaveChangesAsync();
        }
    }
}
