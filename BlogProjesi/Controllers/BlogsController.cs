using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.Controllers
{
    public class BlogsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
