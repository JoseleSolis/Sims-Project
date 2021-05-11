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
    public class WorldController : Controller
    {
        private IRepository repository;
        public WorldController(IRepository repo)
        {
            repository = repo;
        }
        
        public ViewResult Index() => View(repository.Worlds);

        public ViewResult Edit(Guid worldID) =>
         View(repository.Worlds
             .FirstOrDefault(n => n.WorldID == worldID));

        [HttpPost]
        public IActionResult Edit(World world)
        {

            if (ModelState.IsValid)
            {
                repository.SaveWorld(world);
                TempData["message"] = $"{world.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                // if enters here there is something wrong with the data values
                return View(world);
            }
        }

        public ViewResult Create() => View("Edit", new World());

        [HttpPost]
        public IActionResult Delete(Guid worldID)
        {
            World deletedWorld = repository.DeleteWorld(worldID);
            if (deletedWorld != null)
            {
                TempData["message"] = $"{deletedWorld.Name} was deleted";
            }
            return RedirectToAction("Index");
        }
        
    }
}
