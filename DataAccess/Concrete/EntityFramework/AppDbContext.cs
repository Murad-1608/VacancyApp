using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=VacancyAppDb; Integrated Security=true;");
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<JobSeeker> JobSeekers { get; set; }
    }
}
