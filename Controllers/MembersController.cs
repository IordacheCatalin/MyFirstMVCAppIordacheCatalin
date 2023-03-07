using Microsoft.AspNetCore.Mvc;
using MyFirstMVCAppIordacheCatalin.Models;
using MyFirstMVCAppIordacheCatalin.Repositories;
using MyFirstMVCAppIordacheCatalin.ViewModels;

namespace MyFirstMVCAppIordacheCatalin.Controllers
{
    public class MembersController : Controller
    {
        private readonly MembersRepository _membersRepository;

        public MembersController(MembersRepository repository)
        {
            _membersRepository = repository;
        }
        //VIEW SECTION
        public IActionResult Index()
        {
            var members = _membersRepository.GetMembers();
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
            _membersRepository.Add(members);

            return RedirectToAction("Index");
        }

        //EDIT SECTION

        public IActionResult Edit(Guid id)
        {
            MemberModel members = _membersRepository.GetMemberById(id);
            return View("Edit", members);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, IFormCollection collection)
        {
            MemberModel members = new();
            TryUpdateModelAsync(members);
            _membersRepository.Update(members);

            return RedirectToAction("Index");
        }


        //DELETE SECTION

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            MemberModel members = _membersRepository.GetMemberById(id);
            return View("Delete", members);
        }

        [HttpPost]
        public IActionResult Delete(Guid id, IFormCollection collection)
        {
            _membersRepository.Delete(id);
            return RedirectToAction("Index");
        }

        //DETAILS SECTION

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            MemberModel members = _membersRepository.GetMemberById(id);
            return View("Details", members);
        }

        public IActionResult DetailsWithCodeSnippets(Guid id)
        {
            MemberCodesnippetsViewModel viewModel = _membersRepository.GetMemberCodeSnippets(id);
            return View("DetailsWithCodeSnippets", viewModel);
        }

    }
}
