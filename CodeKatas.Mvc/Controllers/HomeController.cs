using System.Diagnostics;
using CodeKatas.Abstractions.Contracts;
using CodeKatas.Abstractions.Services;
using CodeKatas.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeKatas.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonService _personService;

        public HomeController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Index(string message = "")
        {
            var model = new DefaultModel
            {
                IntroText = "",
                PersonList = _personService.GetAll(),
                Message = message
                    
            };
 
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PersonCarrier personCarrirer)
        {
            try
            {
                _personService.Create(personCarrirer);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}