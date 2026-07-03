using Microsoft.AspNetCore.Identity;

namespace BlogProjesi.Identity
{
    public class BlogIdentityUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
