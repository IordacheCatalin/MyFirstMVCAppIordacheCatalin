using Microsoft.AspNetCore.Mvc;
using MyFirstMVCAppIordacheCatalin.Models;
using MyFirstMVCAppIordacheCatalin.Repositories;

namespace MyFirstMVCAppIordacheCatalin.Controllers
{

    
    public class AnnouncementsController : Controller
    {
        private readonly AnnouncementsRepository _repository;

            public AnnouncementsController(AnnouncementsRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var announcements = _repository.GetAnnouncements();
            return View("Index", announcements);
        }
    }
}
