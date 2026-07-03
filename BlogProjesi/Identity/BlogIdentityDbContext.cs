using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogProjesi.Identity
{
    public class BlogIdentityDbContext : IdentityDbContext<BlogIdentityUser, BlogIdentityRole,string >
    {
        public BlogIdentityDbContext(DbContextOptions<BlogIdentityDbContext> options) : base(options)
        {

        }

    }
}
