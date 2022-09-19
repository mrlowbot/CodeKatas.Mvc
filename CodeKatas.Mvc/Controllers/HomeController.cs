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

        [HttpGet]
        public IActionResult Edit(Guid personId)
        {
            var person = _personService.Get(personId);

            var model = new PersonModel
            {
                PersonId = personId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                PhoneNumber = person.PhoneNumber
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(PersonCarrier model)
        {
            try
            {
                _personService.Update(model);
                return RedirectToAction("Index");
            }

            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(Guid personId)
        {
            var person = _personService.Get(personId);

            var model = new PersonModel
            {
                PersonId = personId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                PhoneNumber = person.PhoneNumber
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Guid personId, int k)
        {
            try
            {
                var person = _personService;
                person.Delete(personId);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult AddAddress(Guid personId, Guid addressId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAddress([Bind] AddressCarrier model, Guid personId)
        {
            try
            {
                _personService.CreateAddress(model, personId);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult RemoveAddress()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RemoveAddress(Guid addressId, Guid personId)
        {
            try
            {
                var person = _personService.Get(personId);

                var address = person.Addresses.FirstOrDefault();
                _personService.DeleteAddress(address.AddressId);

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