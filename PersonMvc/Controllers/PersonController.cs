using Microsoft.AspNetCore.Mvc;
using Person.Services;
using System;

namespace PersonMvc.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        public IActionResult Index()
        {
            var persons = _personService.GetAll();
            return View(persons);
        }
        public IActionResult Details(Guid id)
        {
            var person = _personService.Get(id);
            return View(person);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Person.Models.Person person)
        {
            _personService.Add(person);
            return Redirect("Index");
        }
        public IActionResult Edit(Guid id)
        {
            var person = _personService.Get(id);
            return View(person);
        }
        [HttpPost]
        public IActionResult Edit(Person.Models.Person person)
        {
            _personService.Update(person);
            return Redirect("Index");
        }
        public IActionResult Delete(Guid id)
        {
            var person = _personService.Get(id);
            return View(person);
        }
        [HttpPost]
        public IActionResult Delete(Person.Models.Person person)
        {
            _personService.Delete(person.Id);
            return Redirect("Index");
        }
    }
}
