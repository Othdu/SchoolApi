using Microsoft.EntityFrameworkCore;
using SchoolAPI.models;


namespace SchoolAPI
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            public DbSet<Student> Students { get; set; }


    }
}
