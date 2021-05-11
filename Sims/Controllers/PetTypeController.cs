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
    public class PetTypeController : Controller
    {
        private IRepository repository;
        public PetTypeController(IRepository repo)
        {
            repository = repo;
        }
        
        public ViewResult Index() => View(repository.PetTypes);

        public ViewResult Edit(Guid typeID) =>
         View(repository.PetTypes
             .FirstOrDefault(t => t.TypeID == typeID));

        [HttpPost]
        public IActionResult Edit(PetType type)
        {

            if (ModelState.IsValid)
            {
                repository.SavePetType(type);
                TempData["message"] = $"{type.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                // if enters here there is something wrong with the data values
                return View(type);
            }
        }

        public ViewResult Create() => View("Edit", new PetType());

        [HttpPost]
        public IActionResult Delete(Guid typeID)
        {
            PetType deletedType = repository.DeletePetType(typeID);
            if (deletedType != null)
            {
                TempData["message"] = $"{deletedType.Name} was deleted";
            }
            return RedirectToAction("Index");
        }
        
    }
}
