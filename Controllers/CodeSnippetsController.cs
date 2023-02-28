using Microsoft.AspNetCore.Mvc;
using MyFirstMVCAppIordacheCatalin.Models;
using MyFirstMVCAppIordacheCatalin.Repositories;

namespace MyFirstMVCAppIordacheCatalin.Controllers
{
    public class CodeSnippetsController : Controller
    {
     
             private readonly AnnouncementsRepository _repository;

        public CodeSnippetsController(AnnouncementsRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var codeSnippets = _repository.GetAnnouncements();
            return View("Index", codeSnippets);
        }
    }
    
}
