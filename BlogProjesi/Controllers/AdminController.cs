using BlogProjesi.Context;
using BlogProjesi.Identity;
using BlogProjesi.Models;
using BlogProjesi.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.Controllers
{
    public class AdminController : Controller
    {
        private readonly BlogDbContext _context;
        private readonly UserManager<BlogIdentityUser> _userManager;
        
        public AdminController(BlogDbContext context,UserManager<BlogIdentityUser>userManager)
        {
            _context = context;
            _userManager= userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Blogs()
        {   
            var blogs = _context.Blogs.ToList();
            return View(blogs);
        }

        public IActionResult EditBlogs(int id)
        {
            var blog = _context.Blogs.Where(x => x.Id ==id).FirstOrDefault();

            return View(blog);
        }
        public IActionResult DeleteBlogs(int id)
        {
            var blog = _context.Blogs.Where(x=> x.Id ==id).FirstOrDefault();
            _context.Blogs.Remove(blog);
            _context.SaveChanges();
        return RedirectToAction("Blogs");
        }

        [HttpPost]
        public IActionResult EditBlogs(Blog model)
        {
            var blog= _context.Blogs.Where(x=> x.Id ==model.Id).FirstOrDefault();
            blog.name=model.name;
            blog.description = model.description;
            blog.Tags = model.Tags;
            blog.imageUrl = model.imageUrl;
            _context.SaveChanges();
            return RedirectToAction("Blogs");

        }
        public IActionResult ToggleStatus(int id) 
        {
            var blog= _context.Blogs.Where(x=> x.Id ==id).FirstOrDefault();
            
            if (blog.status == 1)
            {
                blog.status = 0;
            }
            else
            {
                blog.status = 1;
            }
            _context.SaveChanges();
                return RedirectToAction("Blogs");
        }
        public IActionResult CreateBlogs(int id)
        {

            return View();
        }
        [HttpPost]
        public IActionResult CreateBlogs(Blog model)
        {
            model.Publishdate=DateTime.Now;
            model.status=1;
            _context.Blogs.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Blogs");
        }
        
        public IActionResult Comments(int? blogid)
        {
            var comment = new List<Comment>();
            if(blogid == null)
            {
                comment = _context.Comments.ToList();
            }
            else
            {
                comment = _context.Comments.Where(x=> x.BlogId == blogid).ToList();    
            }
                return View(comment);
        }
        public IActionResult DeleteComment(int id) 
        {
            var comment = _context.Comments.Where(x=> x.Id == id).FirstOrDefault();
            _context.Comments.Remove(comment);
            _context.SaveChanges();

            return RedirectToAction("Comments");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (model.Password == model.Repassword)
            {
                var user = new BlogIdentityUser
                {
                    Name = model.Name,
                    Surname= model.Surname,
                    Email = model.Email,
                    UserName=model.Email
                };
                var result = await _userManager.CreateAsync(user,model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
               
        }
    }
}
