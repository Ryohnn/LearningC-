using LearningMVC.Data;
using LearningMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.ComponentModel;

namespace LearningMVC.Repositories
{
    public class BlogRepository(LearningMvcContext context) : IBlogRepository
    {
        public async Task<Blog?> GetBlogById(int? id)
            => await context.Blog.FirstOrDefaultAsync(m => m.Id == id);

        public async Task<List<Blog>?> GetBlogList()
            => await context.Blog.ToListAsync();

        public int Add(Blog blog)
        {
            context.Blog.Add(blog);
            return blog.Id;
        }

        public void Update(Blog blog)
            => context.Blog.Update(blog);

        public void Delete(Blog blog)
            => context.Blog.Remove(blog);

        public async Task SaveChanges()
            => await context.SaveChangesAsync();

        public bool Exists(int id)
            => context.Blog.Any(blog => blog.Id == id);

        public IQueryable<Blog> GetLatest()
            => context.Blog.OrderByDescending(blog => blog.Id);
    }
}
