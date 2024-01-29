using Logic.Repos;
using Logic.Repos.Intrefaces;
using Logic.Services;
using Logic.Services.Interfaces;
using Logic.Repos.DbImplementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DB;

namespace ProjektArtykuly
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IArticleRepository, DbArticleRepository>();
            builder.Services.AddScoped<IArticleService, ArticleService>();

            builder.Services.AddScoped<IUserRepository, DbUserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddScoped<IComentsRepository, DbComentsRepository>();
            builder.Services.AddScoped<IComentService, ComentService>();

            builder.Services.AddScoped<IMarksRepository, DbMarkRepository>();
            builder.Services.AddScoped<IMarkService, MarkService>();

            builder.Services.AddScoped<ITagRepository, DbTagRepository>();
            builder.Services.AddScoped<ITagService, TagService>();

            builder.Services.AddScoped<ISectionRepository, DbSectionRepository>();
            builder.Services.AddScoped<IArticleSectionService, ArticleSectionService>();

            builder.Services.AddScoped<IArticleParagraphRepository, DbArticleParagraphRepository>();
            builder.Services.AddScoped<IArticleParagraphService, ArticleParagraphService>();

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            builder.Services.AddDbContext<MyDbContext>(options =>
               {
                   options.UseSqlServer(builder.Configuration.GetConnectionString("MainDbString"));
               }); 

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddHttpClient();

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(120);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //u¿ycie sessji
            app.UseSession();

            app.MapControllers();
            app.MapRazorPages();

            app.Run();
        }
    }
}