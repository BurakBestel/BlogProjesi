using BlogProjesi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogProjesi.Context
{
    public class BlogDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=VICTUS\\SQLEXPRESS; database=Blogstaj; Integrated Security=True; TrustServerCertificate=True;");

        }

        public DbSet<Blog> Blogs{ get; set; }
    }
}