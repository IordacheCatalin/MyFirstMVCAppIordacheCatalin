using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstMVCAppIordacheCatalin.Models;
using MyFirstMVCAppIordacheCatalin.Repositories;
using NuGet.Protocol.Core.Types;

namespace MyFirstMVCAppIordacheCatalin.Controllers
{
    public class CodeSnippetsController : Controller
    {
        private readonly CodeSnippetsRepository _repository;
        private readonly MembersRepository _membersRepository;

        public CodeSnippetsController(CodeSnippetsRepository repository, MembersRepository membersRepository )
        {
            _repository = repository;
            _membersRepository = membersRepository;
        }

        //VIEW SECTION
        // GET: CodeSnippetsController

        public IActionResult Index()
        {
            var codeSnippets = _repository.GetCodeSnippets();
            return View("Index", codeSnippets);
        }

        // GET: CodeSnippetsController/Details/5
        //DETAILS SECTION
        public IActionResult Details(Guid id)
        {
            CodeSnippetModel codeSnippet = _repository.GetCodeSnippetById(id);
            return View("Details", codeSnippet);
        }

        //CREATE SECTION
        // GET: CodeSnippetsController/Create

        public IActionResult Create()
        {
            var members = _membersRepository.GetMembers();

            ViewBag.data = members;

            return View("Create");
        }

        // POST: CodeSnippetsController/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {
            CodeSnippetModel codeSnippet = new CodeSnippetModel();

            TryUpdateModelAsync(codeSnippet); // maps the data from the form filled in by the user to the announcements model
            _repository.AddCodeSnippet(codeSnippet);
            return RedirectToAction("Index");

        }


        //EDIT SECTION
        // GET: CodeSnippetsController/Edit/5
        public IActionResult Edit(Guid id)
        {
            CodeSnippetModel codeSnippet = _repository.GetCodeSnippetById(id);
            return View("Edit", codeSnippet);
        }

        // POST: CodeSnippetsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, IFormCollection collection)
        {
            CodeSnippetModel codeSnippet = new CodeSnippetModel();
            TryUpdateModelAsync(codeSnippet);
            _repository.AddCodeSnippet(codeSnippet);
            return RedirectToAction("Index");
        }


        //DELETE SECTION
        // GET: CodeSnippetsController/Delete/5
        public IActionResult Delete(Guid id)
        {
            CodeSnippetModel codeSnippet = _repository.GetCodeSnippetById(id);
            return View("Delete", codeSnippet);
        }

        // POST: CodeSnippetsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id, IFormCollection collection)
        {
            _repository.DeleteCodeSnippet(id);    // Variant B
            return RedirectToAction("Index");
        }
    }
}
