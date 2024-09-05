using LearningMVC.Data;
using LearningMVC.Factories;
using LearningMVC.Models.Blogs;
using Microsoft.EntityFrameworkCore;

namespace LearningMVC.Repositories
{
    public class BlogRepository(LearningMvcContext context) : IBlogRepository
    {
        public async Task<List<Blog>?> GetBlogList()
        {
            var list = await context.Blog.ToListAsync();
            return list.Count == 0 
                ? [ BlogFactory.CreateNoBlog() ] : list;
        }

        public async Task<Blog> GetBlogById(int blogId)
        {
            return await context.Blog.FirstOrDefaultAsync(b => b.Id == blogId)
                   ?? BlogFactory.CreateNoBlog();
        }

        public async Task<int> Create(Blog blog)
        {
            if (blog.IsEmpty())
            {
                throw new NullReferenceException("Blog is empty");
            }
            
            await context.Blog.AddAsync(blog);
            await context.SaveChangesAsync();
            return blog.Id;
        }

        public async Task<int> Update(Blog blog)
        {
            if (blog.IsEmpty())
            {
                throw new NullReferenceException("Blog is empty");
            }
            
            context.Blog.Update(blog);
            await context.SaveChangesAsync();
            return blog.Id;
        }

        public async Task Delete(Blog blog)
        {
            if (blog.IsEmpty())
            {
                throw new NullReferenceException("Blog is empty");
            }
            
            context.Blog.Remove(blog);
            await context.SaveChangesAsync();
        }
    }
}
