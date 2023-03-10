using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstMVCAppIordacheCatalin.Models;
using MyFirstMVCAppIordacheCatalin.Repositories;
using NuGet.Protocol.Core.Types;

namespace MyFirstMVCAppIordacheCatalin.Controllers
{
    public class MembershipsController : Controller
    {
        private readonly MembershipsRepository _repository;

        public MembershipsController(MembershipsRepository repository)
        {
            _repository = repository;
        }

        //VIEW SECTION
        // GET: MembershipController

        public IActionResult Index()
        {
            var memberships = _repository.GetMemberships();
            return View("Index", memberships);
        }

        // GET: MembershipController/Details/5
        //DETAILS SECTION
        public IActionResult Details(Guid id)
        {
            MembershipModel membership = _repository.GetMembershipById(id);
            return View("Details", membership);
        }

        //CREATE SECTION
        // GET: MembershipController/Create

        public IActionResult Create()
        {
            var membership = _repository.GetMemberships();

            return View("Create");
        }

        // POST: MembershipController/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Guid id, IFormCollection collection)
        {
            MembershipModel membership = new MembershipModel();

            TryUpdateModelAsync(membership); // maps the data from the form filled in by the user to the membership model
            _repository.AddMembership(membership);
            return RedirectToAction("Index");

        }


        //EDIT SECTION
        // GET: MembershipController/Edit/5
        public IActionResult Edit(Guid id)
        {
            MembershipModel membership = _repository.GetMembershipById(id);
            return View("Edit", membership);
        }

        // POST: MembershipController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, IFormCollection collection)
        {
            MembershipModel membership = new MembershipModel();
            TryUpdateModelAsync(membership);
            _repository.AddMembership(membership);
            return RedirectToAction("Index");
        }


        //DELETE SECTION
        // GET: MembershipController/Delete/5
        public IActionResult Delete(Guid id)
        {
            MembershipModel membership = _repository.GetMembershipById(id);
            return View("Delete", membership);
        }

        // POST: MembershipController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id, IFormCollection collection)
        {
            _repository.DeleteMembership(id);    // Variant B
            return RedirectToAction("Index");
        }

    }
}
