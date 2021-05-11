using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sims.Models;
using Sims.Models.Data;

namespace Sims.Controllers
{
    public class SkillController : Controller
    {
        private IRepository repository;
        public SkillController(IRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index() => View(repository.Skills);

        public ViewResult Edit(Guid skillID) =>
         View(repository.Skills
             .FirstOrDefault(s => s.SkillID == skillID));

        [HttpPost]
        public IActionResult Edit(Skill skill)
        {

            if (ModelState.IsValid)
            {
                repository.SaveSkill(skill);
                TempData["message"] = $"{skill.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                // if enters here there is something wrong with the data values
                return View(skill);
            }
        }

        public ViewResult Create() => View("Edit", new Skill());

        /*
        [HttpPost]
        public IActionResult Delete(int skillID)
        {
            Skill deletedSkill = repository.DeleteSkill(skillID);
            if (deletedSkill != null)
            {
                TempData["message"] = $"{deletedSkill.Name} was deleted";
            }
            return RedirectToAction("Index");
        }
        */
    }
}
