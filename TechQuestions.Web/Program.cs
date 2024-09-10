using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TechQuestions.Application.Interfaces;
using TechQuestions.Application.Services;
using TechQuestions.Core.Interfaces.Repositories;
using TechQuestions.Infrastructure.Data;
using TechQuestions.Infrastructure.Data.Repositories;
using TechQuestions.Web.Interfaces;
using TechQuestions.Web.Services;
using TechQuestions.Web.ViewModels;

namespace TechQuestions.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddAutoMapper(typeof(Program));


            builder.Services.AddDbContext<QuestionsDbContext>();

            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
            builder.Services.AddScoped<ITestRepository, TestRepository>();
            builder.Services.AddScoped<ITagsRepository, TagsRepository>();

            builder.Services.AddScoped<IQuestionService, QuestionService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ITestService, TestService>();
            builder.Services.AddScoped<ICategoryRandomTestService, CategoryRandomTestService>();
            builder.Services.AddScoped<ITagsService, TagsService>();

            builder.Services.AddScoped<IQuestionViewModelService, QuestionViewModelService>();
            builder.Services.AddScoped<ICategoryViewModelService, CategoryViewModelService>();
            builder.Services.AddScoped<ITestViewModelService, TestViewModelService>();
            builder.Services.AddScoped<ICategoryRandomTestViewModelService, CategoryRandomTestViewModelService>();
            builder.Services.AddScoped<ITagsViewModelService, TagsViewModelService>();

            var app = builder.Build();

            SeedDatabase(app.Services, app.Logger).Wait();

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

            app.MapRazorPages();
   
            app.Run();
        }

        public static async Task SeedDatabase(IServiceProvider serviceProvider, ILogger logger)
        {
            using (IServiceScope scope = serviceProvider.CreateScope())
            {
                var scopedProvider = scope.ServiceProvider;
                try
                {
                    var catalogContext = scopedProvider.GetRequiredService<QuestionsDbContext>();
                    await QuestionsDbContextSeed.SeedAsync(catalogContext, logger);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }
        }
    }
}