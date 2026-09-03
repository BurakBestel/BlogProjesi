using BlogProjesi.Context;
using BlogProjesi.Identity;
using BlogProjesi.Models;
using BlogProjesi.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.Controllers
{
    public class BlogsController : Controller
    {

        private readonly BlogDbContext _context;
        
        public BlogsController(BlogDbContext context)
        {
            _context = context;
            
        }
        public IActionResult deneme()
        {
            return View();
        }
        public IActionResult Index()
        {
            var blogs = _context.Blogs.ToList();
            return View(blogs);
        }
        public IActionResult Details(int id)
        {
            var blog = _context.Blogs.FirstOrDefault(x => x.Id == id);
            blog.viewcount += 1;
            _context.SaveChanges();
            var comments = _context.Comments.Where(x => x.BlogId == id).ToList();
            ViewBag.Comments = comments.ToList();
            return View(blog);
        }

        [HttpPost]
        public IActionResult CreateComment(Comment model)
        {
            model.PublishDate = DateTime.Now;
            _context.Comments.Add(model);

            var blog = _context.Blogs.Where(x => x.Id == model.BlogId).FirstOrDefault();
            blog.comment += 1;
            _context.SaveChanges();
            return RedirectToAction("Details", new { id = model.BlogId });
        }

        public IActionResult Support()
        {
            return View();
        }
        public IActionResult About(int id)
        {
            return View();
        }
        public IActionResult Contact(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateContact(Contact model)
        {
            model.CreatedAt = DateTime.Now;
            _context.Contacts.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
