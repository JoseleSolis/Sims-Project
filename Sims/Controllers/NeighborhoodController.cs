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

        public ViewResult Profile(Guid id)
        {
            var NeighborhoodPets = new List<Pet>();
           
            var housesOnNeighborhoodID = repository.NeighborhoodDomesticUnitsTable.Where(m => m.NeighborhoodID == id);
            var housesOnNeighborhood = new List<DomesticUnit>();
           
            foreach (NeighborhoodDomesticUnits item in housesOnNeighborhoodID)
               housesOnNeighborhood.Add(repository.DomesticUnits.FirstOrDefault(d => d.DomesticUnitID == item.DomesticUnitID));

            var petDomesticUnits = new List<PetLives>();
            foreach (DomesticUnit item in housesOnNeighborhood)
            {
                var collection = repository.PetLivesTable.Where(d => d.DomesticUnitID == item.DomesticUnitID);
                foreach (PetLives petHouse in collection)
                    petDomesticUnits.Add(petHouse);
            }

            var pets = new List<Pet>();
           
            foreach (PetLives item in petDomesticUnits)
                pets.Add(repository.Pets.FirstOrDefault(p => p.PetID == item.PetID));

            Dictionary<string, int> petTypeCount = new Dictionary<string, int>();
            foreach (Pet pet in pets)
            {
                if (petTypeCount.ContainsKey(pet.TypeName))
                    petTypeCount[pet.TypeName]++;
                else petTypeCount.Add(pet.TypeName, 1);
            }
            
            string popularPet = "";
            int max = 0;
            foreach (string Key in petTypeCount.Keys)
                if(petTypeCount[Key] > max) 
                {
                    max = petTypeCount[Key];
                    popularPet = Key;
                }
            

            NeighborhoodProfileViewModel viewModel = new NeighborhoodProfileViewModel
            {
                Neighborhood = repository.Neighborhoods.FirstOrDefault(n => n.NeighborhoodID == id),
                MostPopularPetType = popularPet
            };
            return View(viewModel);
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
            foreach (var item in repository.NeighborhoodDomesticUnitsTable.Where(n => n.NeighborhoodID == neighborhoodID))
                repository.DeleteNeighborhoodDomesticUnit(item.DomesticUnitID);
            foreach (var item in repository.NeighborhoodPlacesTable.Where(n => n.NeighborhoodID == neighborhoodID))
                repository.DeleteNeighborhoodPlace(item.PlaceID);
            if (repository.NeighborhoodUpgradesSkillsTable.FirstOrDefault(n => n.NeighborhoodID == neighborhoodID) != null)
                repository.DeleteNeighborhoodUpgradesSkill(neighborhoodID);
            return RedirectToAction("Index");
        }

        public ViewResult ImproveSkill(Guid id)
        {
            NeighborhoodImprovesSkillViewModel viewModel = new NeighborhoodImprovesSkillViewModel
            {
                Neighborhood = repository.Neighborhoods.FirstOrDefault(p => p.NeighborhoodID == id)
            };
            NeighborhoodUpgradesSkill relation = repository.NeighborhoodUpgradesSkillsTable
                .FirstOrDefault(e => e.NeighborhoodID == viewModel.Neighborhood.NeighborhoodID);
            viewModel.Skills = relation == null ? repository.Skills : repository.Skills.Where(n => n.SkillID != relation.SkillID);

            if (relation != null)
            {
                Skill skill = repository.Skills
                    .FirstOrDefault(n => n.SkillID == relation.SkillID);
                viewModel.CurrentImprovedSkill = skill.Name;
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult ImproveSkill(NeighborhoodImprovesSkillViewModel viewModel)
        {
            NeighborhoodUpgradesSkill relation = new NeighborhoodUpgradesSkill
            {
                NeighborhoodID = viewModel.Neighborhood.NeighborhoodID,
                SkillID = viewModel.SkillID
            };
            relation.Neighborhood = repository.Neighborhoods
                .FirstOrDefault(d => d.NeighborhoodID == relation.NeighborhoodID);
            relation.Skill = repository.Skills
                .FirstOrDefault(n => n.SkillID == relation.SkillID);

            if (ModelState.IsValid)
            {
                repository.SaveNeighborhoodUpgradesSkill(relation);
                TempData["message"] = $"{relation.Neighborhood.Name} now improves {relation.Skill.Name} skill";
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
