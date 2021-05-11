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
    public class QuestController : Controller
    {
        private IRepository repository;
        public QuestController(IRepository repo)
        {
            repository = repo;
        }
        
        public ActionResult Index() => View(repository.Quests);

        public ViewResult Edit(Guid questID) =>
           View(repository.Quests
          .FirstOrDefault(q => q.QuestID == questID));

        [HttpPost]
        public IActionResult Edit(Quest quest)
        {

            if (ModelState.IsValid)
            {
                repository.SaveQuest(quest);
                TempData["message"] = $"{quest.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                // if enters here there is something wrong with the data values
                return View(quest);
            }
        }
        public ViewResult Create() => View("Edit", new Quest());

        [HttpPost]
        public IActionResult Delete(Guid questID)
        {
            Quest deletedQuest = repository.DeleteQuest(questID);
            if (deletedQuest != null)
            {
                TempData["message"] = $"{deletedQuest.Name} was deleted";
            }
            return RedirectToAction("Index");
        }
        
    }
}
