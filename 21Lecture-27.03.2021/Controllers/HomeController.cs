using _21Lecture_27._03._2021.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using _21Lecture_27._03._2021.Models.Repositories;
namespace _21Lecture_27._03._2021.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new PersonRepository().GetInfo());
        }

        [HttpPost]
        public IActionResult GetInfoName(string LastName, string FirstName, string MiddleName)
        {
            try
            {
                LastName = LastName.Trim();
                FirstName = FirstName.Trim();
                MiddleName = MiddleName.Trim();

                var person = new Person() { FirstName = FirstName, LastName = LastName, MiddleName = MiddleName };

                var result = new PersonRepository().GetInfo(person);
                Console.WriteLine(result);
                return View("Index", result);
            }
            catch (Exception)
            {
                return NoContent();
            }
        }

        [HttpPost]
        public IActionResult GetInfo(string Id)
        {
            try
            {
                var result = new PersonRepository().GetInfo(int.Parse(Id));
                return View("Index", result);
            }
            catch
            {
                return NoContent();
            }
        }

        [HttpPost]
        public IActionResult AddToDb(Person Model)
        {
            //var person = new Person() { LastName = LastName, FirstName = FirstName, MiddleName = MiddleName };
            new PersonRepository().Insert(Model);

            return RedirectToAction("index", "home");
        }
    }
}

