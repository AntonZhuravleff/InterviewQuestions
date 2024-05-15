using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TechQuestions.Core.Entities;

namespace TechQuestions.Infrastructure.Data
{
    public class QuestionsDbContext : DbContext
    {
        private IConfiguration _configuration { get; set; }

        public QuestionsDbContext(DbContextOptions<QuestionsDbContext> options, IConfiguration configuration) : base(options) 
        { 
            _configuration = configuration;
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DatabaseConnection"));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
