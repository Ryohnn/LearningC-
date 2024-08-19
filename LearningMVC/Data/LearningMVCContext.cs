using Microsoft.EntityFrameworkCore;
using LearningMVC.Models;

namespace LearningMVC.Data
{
    public class LearningMvcContext(DbContextOptions<LearningMvcContext> options) : DbContext(options)
    {
        public DbSet<Blog> Blog { get; set; } = default!;
    }
}
