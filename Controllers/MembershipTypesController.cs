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
        public IActionResult Index()
        {
            var membershipTypes = _repository.GetMembershipTypes();
            return View("Index", membershipTypes);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(IFormCollection collection)
        {
            MembershipTypeModel membershipType = new MembershipTypeModel();
            TryUpdateModelAsync(membershipType);
            _repository.Add(membershipType);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            MembershipTypeModel membershipType = _repository.GetMembershipTypeById(id);
            return View("Edit", membershipType);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, IFormCollection collection)
        {
            MembershipTypeModel membershipType = new();
            TryUpdateModelAsync(membershipType);
            _repository.Update(membershipType);

            return RedirectToAction("Index");
        }


    }
}
