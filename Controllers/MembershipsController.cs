using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        // GET: CodeSnippetsController
        //VIEW SECTION
        public IActionResult Index()
        {
            var memberships = _repository.GetMemberships();
            return View("Index", memberships);
        }

        

    }
}
