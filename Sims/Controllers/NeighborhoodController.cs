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
    public class NeighborhoodController : Controller
    {
        private IRepository repository;
        public NeighborhoodController(IRepository repo)
        {
            repository = repo;
        }
        
        public ViewResult Index() => View(repository.Neighborhoods);

        public ViewResult Edit(Guid neighborhoodID) =>
         View(repository.Neighborhoods
             .FirstOrDefault(n => n.NeighborhoodID == neighborhoodID));

        [HttpPost]
        public IActionResult Edit(Neighborhood neighborhood)
        {

            if (ModelState.IsValid)
            {
                repository.SaveNeighborhood(neighborhood);
                TempData["message"] = $"{neighborhood.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                // if enters here there is something wrong with the data values
                return View(neighborhood);
            }
        }

        public ViewResult Create() => View("Edit", new Neighborhood());

        [HttpPost]
        public IActionResult Delete(Guid neighborhoodID)
        {
            Neighborhood deletedNeighborhood = repository.DeleteNeighborhood(neighborhoodID);
            if (deletedNeighborhood != null)
            {
                TempData["message"] = $"{deletedNeighborhood.Name} was deleted";
            }
            return RedirectToAction("Index");
        }
       
    }
}
