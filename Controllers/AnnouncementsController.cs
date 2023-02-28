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

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(IFormCollection collection)
        {
            AnnouncementModel announcement = new AnnouncementModel();

            TryUpdateModelAsync(announcement); // mapeaza datele din formularul completat de utilizator pe modelul announcements
            _repository.Add(announcement);

            return RedirectToAction("Index");
        }


    }
}
