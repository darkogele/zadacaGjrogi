using SchoolApi.Data.Entites;
using Microsoft.EntityFrameworkCore;

namespace SchoolApi.Data.SchoolDbContext
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions contextOptions) : base(contextOptions) { }


        public DbSet<Company> Companies { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Application> Applications { get; set; }
    }
}