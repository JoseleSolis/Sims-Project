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
    public class PlaceController : Controller
    {
        private IRepository repository;
        public PlaceController(IRepository repo)
        {
            repository = repo;
        }
        
        public ViewResult Profile(Guid id) => View(
            repository.Places
            .FirstOrDefault(p => p.PlaceID == id));

        public ViewResult Index() => View(repository.Places);

        public ViewResult Edit(Guid placeID) =>
         View(repository.Places
             .FirstOrDefault(p =>p.PlaceID == placeID));

        [HttpPost]
        public IActionResult Edit(Place place)
        {

            if (ModelState.IsValid)
            {
                repository.SavePlace(place);
                TempData["message"] = $"{place.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                // if enters here there is something wrong with the data values
                return View(place);
            }
        }

        public ViewResult Create() => View("Edit", new Place());

        [HttpPost]
        public IActionResult Delete(Guid placeID)
        {
            Place deletedPlace = repository.DeletePlace(placeID);
            if (deletedPlace != null)
            {
                TempData["message"] = $"{deletedPlace.Name} was deleted";
            }
            return RedirectToAction("Index");
        }

        public ViewResult Neighborhood(Guid id)
        {
            PlaceNeighborhoodViewModel viewModel = new PlaceNeighborhoodViewModel
            {
                Place = repository.Places.FirstOrDefault(p => p.PlaceID == id)
            };
            NeighborhoodPlaces relation = repository.NeighborhoodPlacesTable
                .FirstOrDefault(e => e.PlaceID == viewModel.Place.PlaceID);
           
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
        public ActionResult Neighborhood(PlaceNeighborhoodViewModel viewModel)
        {
            NeighborhoodPlaces relation = new NeighborhoodPlaces
            {
                PlaceID = viewModel.Place.PlaceID,
                NeighborhoodID = viewModel.NeighborhoodID
            };
            relation.Place = repository.Places
                .FirstOrDefault(p => p.PlaceID == relation.PlaceID);
            relation.Neighborhood = repository.Neighborhoods
                .FirstOrDefault(n => n.NeighborhoodID == relation.NeighborhoodID);

            if (ModelState.IsValid)
            {
                repository.SaveNeighborhoodPlace(relation);
                TempData["message"] = $"{relation.Place.Name} is now located in {relation.Neighborhood.Name}";
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
