using EntertainmentProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EntertainmentProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEntertainmentRepository _repo;

        public HomeController(IEntertainmentRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Bring in list of entertainer to display

        public IActionResult EntertainerList()
        {
            var entertainerNames = _repo.Entertainers.ToList();

            return View(entertainerNames);
        }

        //Brings in one Entertainer to display after details button is clicked

        [HttpGet]
        public IActionResult EntertainerDetails(int id)
        {
            var entertainerToDisplay = _repo.Entertainers.Single(x => x.EntertainerId == id);

            return View(entertainerToDisplay);
        }

        // UPDATE

        //Brings in one Entertainer to update when edit button is clicked

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var entertainerToEdit = _repo.Entertainers.Single(x => x.EntertainerId == id);

            return View("AddUpdateEntertainer", entertainerToEdit);
        }

        //Changes the data when the submit button is pushed 

        [HttpPost]
        public IActionResult Edit(Models.Entertainer updatedEntertainer)
        {

            if (ModelState.IsValid)
            {
                _repo.UpdateEntertainer(updatedEntertainer);

                return RedirectToAction("EntertainerList");
            }
            else
            {
                return View("AddUpdateEntertainer", updatedEntertainer);
            }
        }

        // CREATE

        [HttpGet]

        public IActionResult Add()
        {
            return View("AddUpdateEntertainer", new Models.Entertainer());
        }

        [HttpPost]

        public IActionResult Add(Models.Entertainer entertainer)
        {
            if (ModelState.IsValid)
            {
                _repo.AddEntertainer(entertainer);
                return RedirectToAction("EntertainerList");
            }
            else
            {
                return View("AddUpdateEntertainer", entertainer);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var entertainerToDelete = _repo.Entertainers
                .Single(x => x.EntertainerId == id);

            return View(entertainerToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Models.Entertainer entertainerToDelete)
        {
            _repo.DeleteEntertainer(entertainerToDelete);

            return RedirectToAction("EntertainerList");
        }

    }
}
