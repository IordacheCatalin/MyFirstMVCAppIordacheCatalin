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
        //VIEW SECTION
        public IActionResult Index()
        {
            var members = _repository.GetMembers();
            return View("Index", members);
        }

        //CREATE SECTION

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(IFormCollection collection)
        {
            MemberModel members = new MemberModel();

            TryUpdateModelAsync(members); // maps the data from the form filled in by the user to the members model
            _repository.Add(members);

            return RedirectToAction("Index");
        }

        //EDIT SECTION

        public IActionResult Edit(Guid id)
        {
            MemberModel members = _repository.GetMemberById(id);
            return View("Edit", members);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, IFormCollection collection)
        {
            MemberModel members = new();
            TryUpdateModelAsync(members);
            _repository.Update(members);

            return RedirectToAction("Index");
        }


        //DELETE SECTION

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            MemberModel members = _repository.GetMemberById(id);
            return View("Delete", members);
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
            MemberModel members = _repository.GetMemberById(id);
            return View("Details", members);
        }
    }
}
