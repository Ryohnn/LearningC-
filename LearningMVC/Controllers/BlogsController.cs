using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LearningMVC.Data;
using LearningMVC.Models;
using LearningMVC.Repositories;

namespace LearningMVC.Controllers
{
    [Route("blogs")]
    public class BlogsController(IBlogRepository repository) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await repository.GetBlogList());
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var blog = await repository.GetBlogById(id);

            if (blog == null) return NotFound();

            return View(blog);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> View(int? id)
        {
            if (id == null) return NotFound();

            var blog = await repository.GetBlogById(id);

            if (blog == null) return NotFound();

            return View(blog);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Content")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                repository.Add(blog);
                await repository.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var blog = await repository.GetBlogById(id);

            if (blog == null) return NotFound();

            return View(blog);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content")] Blog blog)
        {
            if (id != blog.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    repository.Update(blog);
                    await repository.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!repository.Exists(blog.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await repository.GetBlogById(id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost("delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blog = await repository.GetBlogById(id);
            if (blog != null)
            {
                repository.Delete(blog);
            }

            await repository.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<Blog?> GetBlogById(int id)
        {
            return await repository.GetBlogById(id);
        }
    }
}
