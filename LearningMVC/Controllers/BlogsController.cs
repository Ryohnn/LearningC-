using LearningMVC.Models;
using Microsoft.AspNetCore.Mvc;
using LearningMVC.Services;

namespace LearningMVC.Controllers
{
    public class BlogsController(IBlogService service) : Controller
    {
        public async Task<IActionResult> Index()
            => View(await service.GetBlogList());

        public IActionResult Create()
            => View();

        [HttpPost]
        public async Task<IActionResult> Create(Blog blog)
        {
            if (!ModelState.IsValid)
                return View(blog);
            
            await service.Create(blog);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> View(int id)
            => View(await service.GetBlogById(id));
        
        public async Task<IActionResult> Edit(int id)
            => View(await service.GetBlogById(id));
        
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Blog blog)
        {
            await service.Update(blog);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
