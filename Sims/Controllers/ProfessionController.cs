using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sims.Models;
using Sims.Models.Relations;
using Sims.Models.ViewModels;
using Sims.Models.Data;

namespace Sims.Controllers
{
    public class ProfessionController : Controller
    {
        private IRepository repository;
        public ProfessionController(IRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index() => View(repository.Professions);

        public ViewResult Edit(Guid professionID) =>
         View(repository.Professions
             .FirstOrDefault(n => n.ProfessionID == professionID));

        [HttpPost]
        public IActionResult Edit(Profession profession)
        {

            if (ModelState.IsValid)
            {
                repository.SaveProfession(profession);
                TempData["message"] = $"{profession.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                // if enters here there is something wrong with the data values
                return View(profession);
            }
        }

        public ViewResult Create() => View("Edit", new Profession());

        [HttpPost]
        public IActionResult Delete(Guid professionID)
        {
            Profession deletedProfession = repository.DeleteProfession(professionID);
            if (deletedProfession != null)
            {
                TempData["message"] = $"{deletedProfession.Name} was deleted";
            }
            return RedirectToAction("Index");
        }

    }
}
