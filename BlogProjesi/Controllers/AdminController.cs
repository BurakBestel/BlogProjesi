using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
