using Microsoft.AspNetCore.Mvc;
using MyFirstMVCAppIordacheCatalin.Models;
using MyFirstMVCAppIordacheCatalin.Repositories;

namespace MyFirstMVCAppIordacheCatalin.Controllers
{
    public class MembersController : Controller
    {
        private readonly MembersRepository _repository;

        public MembersController(MembersRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var members = _repository.GetMembers();
            return View("Index", members);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(IFormCollection collection)
        {
            MemberModel member = new MemberModel();

            TryUpdateModelAsync(member); // maps the data from the form filled in by the user to the announcements model
            _repository.Add(member);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            MemberModel member = _repository.GetMemberById(id);
            return View("Edit", member);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, IFormCollection collection)
        {
            MemberModel member = new();
            TryUpdateModelAsync(member);
            _repository.Update(member);

            return RedirectToAction("Index");
        }
    }
}
