 
using GlobalScholar.Models;
using Microsoft.EntityFrameworkCore;

namespace GlobalScholar.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
        public DbSet<Country>Countries { get; set; }
        public DbSet<CourseLevel>CourseLevels { get; set; }
        public DbSet<ExamType>ExamTypes { get; set; }
        public DbSet<ExpenseType>ExpenseTypes { get; set; }
    }
}
