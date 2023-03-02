using Microsoft.AspNetCore.Mvc;
using MyFirstMVCAppIordacheCatalin.Models;
using MyFirstMVCAppIordacheCatalin.Repositories;

namespace MyFirstMVCAppIordacheCatalin.Controllers
{
    public class MembershipTypesController : Controller
    {
        private readonly MembershipTypesRepository _repository;

        public MembershipTypesController(MembershipTypesRepository repository)
        {
            _repository = repository;
        }
        //VIEW SECTION
        public IActionResult Index()
        {
            var membershipTypes = _repository.GetMembershipTypes();
            return View("Index", membershipTypes);
        }

        //CREATE SECTION

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(IFormCollection collection)
        {
            MembershipTypeModel membershipTypes = new MembershipTypeModel();

            TryUpdateModelAsync(membershipTypes); // maps the data from the form filled in by the user to the membershipTypes model
            _repository.Add(membershipTypes);

            return RedirectToAction("Index");
        }

        //EDIT SECTION

        public IActionResult Edit(Guid id)
        {
            MembershipTypeModel membershipTypes = _repository.GetMembershipTypeById(id);
            return View("Edit", membershipTypes);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, IFormCollection collection)
        {
            MembershipTypeModel membershipTypes = new();
            TryUpdateModelAsync(membershipTypes);
            _repository.Update(membershipTypes);

            return RedirectToAction("Index");
        }


        //DELETE SECTION

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            MembershipTypeModel membershipTypes = _repository.GetMembershipTypeById(id);
            return View("Delete", membershipTypes);
        }

        [HttpPost]
        public IActionResult Delete(Guid id, IFormCollection collection)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }

        //DETAILS SECTION

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            MembershipTypeModel membershipTypes = _repository.GetMembershipTypeById(id);
            return View("Details", membershipTypes);
        }


    }
}
