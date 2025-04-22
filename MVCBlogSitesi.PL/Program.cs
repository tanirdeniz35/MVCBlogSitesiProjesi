using BlogSitesi.BL.Managers.Abstract;
using BlogSitesi.BL.Managers.Concrete;
using BlogSitesi.DAL.Data;
using BlogSitesi.DAL.Entities;
using BlogSitesi.DAL.Repositories.Abstract;
using BlogSitesi.DAL.Repositories.Concrete;
using BlogSitesi.PL.MapperProfiles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCBlogSitesiProjesi.Data;
using MVCBlogSitesiProjesi.Data;
using NuGet.Protocol.Core.Types;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MVCBlogSitesiPLContextConnection") ?? throw new InvalidOperationException("Connection string 'MVCBlogSitesiPLContextConnection' not found.");


builder.Services.AddDbContext<MVCBlogSitesiPLContext>(options =>
    options.UseLazyLoadingProxies()  // Enable lazy loading proxies
           .UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<MVCBlogSitesiPLUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<MVCBlogSitesiPLContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddScoped<Repository<Category>>();
builder.Services.AddScoped<Repository<Article>>();
builder.Services.AddScoped<IArticleManager, ArticleManager>();
builder.Services.AddScoped<ICategoryManager, CategoryManager>();

 
builder.Services.AddAutoMapper(typeof(AutoMapperViewProfile));

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
