using Microsoft.AspNetCore.Mvc;

namespace MyFirstMVCAppIordacheCatalin.Controllers
{
    public class AnnouncementsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
