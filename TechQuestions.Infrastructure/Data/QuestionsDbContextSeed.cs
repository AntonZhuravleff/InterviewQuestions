using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TechQuestions.Core.Entities;

namespace TechQuestions.Infrastructure.Data
{
    public static class QuestionsDbContextSeed
    {
        public static async Task SeedAsync(QuestionsDbContext questionsDbContext, ILogger logger, int retry = 0)
        {
            var retryForAvailability = retry;
            try
            {
                if (!await questionsDbContext.Categories.AnyAsync())
                {
                    await questionsDbContext.Categories.AddRangeAsync(
                        GetPreconfiguredCategories());

                    await questionsDbContext.SaveChangesAsync();
                }

                if (!await questionsDbContext.Tags.AnyAsync())
                {
                    await questionsDbContext.Tags.AddRangeAsync(
                        GetPreconfiguredTags());

                    await questionsDbContext.SaveChangesAsync();
                }

                if (!await questionsDbContext.Questions.AnyAsync())
                {
                    await questionsDbContext.Questions.AddRangeAsync(
                        GetPreconfiguredQuestions(questionsDbContext));

                    await questionsDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability >= 10) throw;

                retryForAvailability++;

                logger.LogError(ex.Message);
                await SeedAsync(questionsDbContext, logger, retryForAvailability);
                throw;
            }
        }

        private static IEnumerable<Category> GetPreconfiguredCategories()
        {
            return new List<Category>
            {
                new("C#","#512bd4","category_csharp.png"),
                new("MSSQL","#0078d4","category_mssql.png"),
                new("Git", "#f14e32", "category_git.png"),
                new("Architecture", "#cf0606", "category_architecture.jpg"),
                new("Patterns", "#0c9638", "category_design-patterns.jpeg"),
            };
        }

        private static IEnumerable<Tag> GetPreconfiguredTags()
        {
            return new List<Tag>
            {
                new("CLR"),
                new("Multithreading"),
                new("ASP.NET"),
                new("Web"),
                new("WPF")
            };
        }

        private static IEnumerable<Question> GetPreconfiguredQuestions(QuestionsDbContext questionsDbContext)
        {
            var sharpCategory = questionsDbContext.Categories.First(c => c.Name == "C#");
            var mssqlCategory = questionsDbContext.Categories.First(c => c.Name == "MSSQL");

            var aspnetTag = questionsDbContext.Tags.First(c => c.Name == "ASP.NET");
            var webTag = questionsDbContext.Tags.First(c => c.Name == "Web");

            return new List<Question>
            {
                new(sharpCategory.Id, "What is the difference between an abstract class and an interface?", "Sample answer 1"),
                new(sharpCategory.Id, "What is the purpose of the Startup class?", "Sample short answer 2","Sample answer 2", new Tag[] { webTag, aspnetTag }),
                new(mssqlCategory.Id, "What is COALESCE in SQL Server?", "Sample answer 3"),
            };
        }
    }
}
