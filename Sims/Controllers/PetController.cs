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
    public class PetController : Controller
    {
        private IRepository repository;
        public PetController(IRepository repo)
        {
            repository = repo;
        }
        
        public ViewResult Profile(Guid id) => View(
          repository.Pets
          .FirstOrDefault(p => p.PetID == id));
        public ViewResult Index() => View(repository.Pets);

        public ViewResult Edit(Guid petID)
        {
            PetEditViewModel viewModel = new PetEditViewModel
            {
                Pet = repository.Pets.FirstOrDefault(p => p.PetID == petID),
                Types = repository.PetTypes
            };
            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Edit(PetEditViewModel viewModel)
        {
            Pet pet = viewModel.Pet;
            pet.Type = repository.PetTypes.FirstOrDefault(t => t.TypeID == viewModel.TypeId);
            pet.TypeName = pet.Type.Name;
            if (ModelState.IsValid)
            {
                repository.SavePet(pet);
                TempData["message"] = $"{pet.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                // if enters here there is something wrong with the data values
                return View(pet);
            }
        }

        public ViewResult Create()
        {
            PetEditViewModel viewModel = new PetEditViewModel
            {
                Pet = new Pet(),
                Types = repository.PetTypes
            };
            return View("Edit", viewModel);
        }


        [HttpPost]
        public IActionResult Delete(Guid petID)
        {
            Pet deletedPet = repository.DeletePet(petID);
            if (deletedPet != null)
            {
                TempData["message"] = $"{deletedPet.Name} was deleted";
            }
            return RedirectToAction("Index");
        }

        public ViewResult DomesticUnit(Guid id)
        {
            PetDomesticUnitViewModel viewModel = new PetDomesticUnitViewModel
            {
                Pet = repository.Pets.FirstOrDefault(p => p.PetID == id)
            };
            PetLives relation = repository.PetLivesTable
                .FirstOrDefault(p => p.PetID == id);
            viewModel.DomesticUnits = relation == null ? repository.DomesticUnits : repository.DomesticUnits.Where(d => d.DomesticUnitID != relation.DomesticUnitID);

            if (relation != null)
            {
                DomesticUnit domesticUnit = repository.DomesticUnits
                    .FirstOrDefault(d => d.DomesticUnitID == relation.DomesticUnitID);
                viewModel.CurrentDomesticUnitName = domesticUnit.Name;
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult DomesticUnit(PetDomesticUnitViewModel viewModel)
        {
            PetLives relation = new PetLives
            {
                PetID = viewModel.Pet.PetID,
                DomesticUnitID = viewModel.DomesticUnitID
            };
            relation.Pet = repository.Pets
                .FirstOrDefault(p => p.PetID == relation.PetID);
            relation.DomesticUnit = repository.DomesticUnits
                .FirstOrDefault(d => d.DomesticUnitID == relation.DomesticUnitID);
            
            if (ModelState.IsValid)
            {
                repository.SavePetLives(relation);
                TempData["message"] = $"{relation.Pet.Name} now lives in {relation.DomesticUnit.Name}";
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
