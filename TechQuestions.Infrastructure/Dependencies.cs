using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechQuestions.Infrastructure.Data;

namespace TechQuestions.Infrastructure
{
    public static class Dependencies
    {
        public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            bool useOnlyInMemoryDatabase = false;
            if (configuration["UseOnlyInMemoryDatabase"] != null)
            {
                useOnlyInMemoryDatabase = bool.Parse(configuration["UseOnlyInMemoryDatabase"]!);
            }

            if (useOnlyInMemoryDatabase)
            {
                services.AddDbContext<QuestionsDbContext>(c =>
                   c.UseInMemoryDatabase("QuestionsDb"));
            }
            else
            {
                services.AddDbContext<QuestionsDbContext>(c => c.UseSqlite());
            }
        }
    }
}
