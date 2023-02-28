using Microsoft.AspNetCore.Mvc;
using MyFirstMVCAppIordacheCatalin.Repositories;

namespace MyFirstMVCAppIordacheCatalin.Controllers
{
    public class MembershipsController : Controller
    {
        private readonly MembershipsRepository _repository;

        public MembershipsController(MembershipsRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var memberships = _repository.GetMemberships();
            return View("Index", memberships);
        }
    }
}
