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

        //VIEW SECTION
        public IActionResult Index()
        {
            var announcements = _repository.GetAnnouncements();
            return View("Index", announcements);
        }

        //CREATE SECTION

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

        //EDIT SECTION

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


        //DELETE SECTION

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            AnnouncementModel announcement = _repository.GetAnnouncementById(id);
            return View("Delete", announcement);
        }

        [HttpPost]
        public  IActionResult Delete(Guid id, IFormCollection collection)
        {
          
                _repository.Delete(id);
                return RedirectToAction("Index");
          
            
        }

        //DETAILS SECTION

        [HttpGet]
        public IActionResult Details(Guid id)
        {

            AnnouncementModel announcement = _repository.GetAnnouncementById(id);
            return View("Details", announcement);
        }

    }
}
