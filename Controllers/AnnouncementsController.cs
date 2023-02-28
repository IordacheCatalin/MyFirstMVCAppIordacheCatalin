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

            TryUpdateModelAsync(announcement); // maps the data from the form filled in by the user to the announcements model
            _repository.Add(announcement);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            AnnouncementModel announcement = _repository.GetAnnouncementById(id);
            return View("Edit", announcement);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, IFormCollection collection)
        {
            AnnouncementModel announcement = new();
            TryUpdateModelAsync(announcement);
            _repository.Update(announcement);

            return RedirectToAction("Index");
        }

    }
}
