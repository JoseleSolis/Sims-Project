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
    public class DomesticUnitController : Controller
    {
        private IRepository repository;
        public DomesticUnitController(IRepository repo)
        {
            repository = repo;
        }
        
        public ViewResult Profile(Guid id) => View(
           repository.DomesticUnits
           .FirstOrDefault(d => d.DomesticUnitID == id));

        public ViewResult Index() => View(repository.DomesticUnits);

        public ViewResult Edit(Guid domesticUnitID) =>
         View(repository.DomesticUnits
             .FirstOrDefault(d => d.DomesticUnitID == domesticUnitID));

        [HttpPost]
        public IActionResult Edit(DomesticUnit domesticUnit)
        {

            if (ModelState.IsValid)
            {
                repository.SaveDomesticUnit(domesticUnit);
                TempData["message"] = $"{domesticUnit.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                // if enters here there is something wrong with the data values
                return View(domesticUnit);
            }
        }

        public ViewResult Create() => View("Edit", new DomesticUnit());

        [HttpPost]
        public IActionResult Delete(Guid domesticUnitID)
        {
            DomesticUnit deletedDomesticUnit = repository.DeleteDomesticUnit(domesticUnitID);
            if (deletedDomesticUnit != null)
            {
                TempData["message"] = $"{deletedDomesticUnit.Name} was deleted";
            }
            return RedirectToAction("Index");
        }

        public ViewResult Neighborhood(Guid id)
        {
            DomesticUnitNeighborhoodViewModel viewModel = new DomesticUnitNeighborhoodViewModel
            {
                DomesticUnit = repository.DomesticUnits.FirstOrDefault(d => d.DomesticUnitID == id)
            };
            NeighborhoodDomesticUnits relation = repository.NeighborhoodDomesticUnitsTable
                .FirstOrDefault(e => e.DomesticUnitID == viewModel.DomesticUnit.DomesticUnitID);
            viewModel.Neighborhoods = relation == null ? repository.Neighborhoods : repository.Neighborhoods.Where(n => n.NeighborhoodID != relation.NeighborhoodID);

            if (relation != null)
            {
                Neighborhood neighborhood = repository.Neighborhoods
                    .FirstOrDefault(n => n.NeighborhoodID == relation.NeighborhoodID);
                viewModel.CurrentNeighborhoodName = neighborhood.Name;
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Neighborhood(DomesticUnitNeighborhoodViewModel viewModel)
        {
            NeighborhoodDomesticUnits relation = new NeighborhoodDomesticUnits
            {
                DomesticUnitID = viewModel.DomesticUnit.DomesticUnitID,
                NeighborhoodID = viewModel.NeighborhoodID
            };
            relation.DomesticUnit = repository.DomesticUnits
                .FirstOrDefault(d => d.DomesticUnitID == relation.DomesticUnitID);
            relation.Neighborhood = repository.Neighborhoods
                .FirstOrDefault(n => n.NeighborhoodID == relation.NeighborhoodID);

            if (ModelState.IsValid)
            {
                repository.SaveNeighborhoodDomesticUnit(relation);
                TempData["message"] = $"{relation.DomesticUnit.Name} is now located in {relation.Neighborhood.Name}";
                return RedirectToAction("Index");
            }
            else
            {
                // if enters here there is something wrong with the data values
                return View(relation);
            }
        }
        
    }
}
