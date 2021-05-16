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

        public ViewResult Profile(Guid id) => View(
             repository.Neighborhoods
                .FirstOrDefault(p => p.NeighborhoodID == id));
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
