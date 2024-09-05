using Microsoft.EntityFrameworkCore;
using LearningMVC.Data;
using LearningMVC.Models.Blogs;
using LearningMVC.Repositories;
using LearningMVC.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<IBlog, Blog>();


builder.Services.AddDbContext<LearningMvcContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LearningMVCContext") ?? throw new InvalidOperationException("Connection string 'LearningMVCContext' not found.")));
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<RouteOptions>(options =>
    {
        options.LowercaseUrls = true;
        options.LowercaseQueryStrings = true;
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(name: "blog",
    pattern: "blogs/{*id}",
    defaults: new { controller = "Blogs", action = "View" }
);

app.Run();
