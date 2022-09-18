using CodeKatas.Abstractions.Contracts;
using CodeKatas.Abstractions.Services;
using CodeKatas.Mvc.Models;
using CodeKatas.Mvc.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CodeKatas.Mvc.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
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
                return RedirectToAction(nameof(HomeController.Index), "HomeController");
            }
        }
    }
}
