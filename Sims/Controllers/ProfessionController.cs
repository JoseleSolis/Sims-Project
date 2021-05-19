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


        public ViewResult Profile(Guid id) => View(
        repository.Professions
        .FirstOrDefault(p => p.ProfessionID == id));

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
            foreach (var item in repository.Exercises.Where(p => p.ProfessionID == professionID))
                repository.DeleteExercise(item.SimID);
            if (repository.ProfessionUpgradesSkillsTable.FirstOrDefault(p => p.ProfessionID == professionID) != null)
                repository.DeleteProfessionUpgradesSkill(professionID);
            return RedirectToAction("Index");

        }

        public ViewResult ImproveSkill(Guid id)
        {
            ProfessionImprovesSkillViewModel viewModel = new ProfessionImprovesSkillViewModel
            {
                Profession = repository.Professions.FirstOrDefault(p => p.ProfessionID == id)
            };
            ProfessionUpgradesSkill relation = repository.ProfessionUpgradesSkillsTable
                .FirstOrDefault(e => e.ProfessionID == viewModel.Profession.ProfessionID);
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
        public ActionResult ImproveSkill(ProfessionImprovesSkillViewModel viewModel)
        {
            ProfessionUpgradesSkill relation = new ProfessionUpgradesSkill
            {
                ProfessionID = viewModel.Profession.ProfessionID,
                SkillID = viewModel.SkillID
            };
            relation.Profession = repository.Professions
                .FirstOrDefault(d => d.ProfessionID == relation.ProfessionID);
            relation.Skill = repository.Skills
                .FirstOrDefault(n => n.SkillID == relation.SkillID);

            if (ModelState.IsValid)
            {
                repository.SaveProfessionUpgradesSkill(relation);
                TempData["message"] = $"{relation.Profession.Name} now improves {relation.Skill.Name} skill";
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
