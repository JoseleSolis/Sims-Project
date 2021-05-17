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

        public ViewResult Profile(Guid id) => View(
           repository.Quests
            .FirstOrDefault(p => p.QuestID == id));

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
        public ViewResult World(Guid id)
        {
            QuestWorldViewModel viewModel = new QuestWorldViewModel
            {
                Quest = repository.Quests.FirstOrDefault(d => d.QuestID == id)
            };
            QuestWorld relation = repository.QuestWorldTable
                .FirstOrDefault(e => e.QuestID == viewModel.Quest.QuestID);
            
            viewModel.Worlds = relation == null ? repository.Worlds : repository.Worlds.Where(n => n.WorldID != relation.WorldID);

            if (relation != null)
            {
                World world = repository.Worlds
                    .FirstOrDefault(n => n.WorldID == relation.WorldID);
                viewModel.CurrentWorldName = world.Name;
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult World(QuestWorldViewModel viewModel)
        {
            QuestWorld relation = new QuestWorld
            {
                QuestID = viewModel.Quest.QuestID,
                WorldID = viewModel.WorldID
            };
            relation.Quest = repository.Quests
                .FirstOrDefault(d => d.QuestID == relation.QuestID);
            relation.World = repository.Worlds
                .FirstOrDefault(n => n.WorldID == relation.WorldID);

            if (ModelState.IsValid)
            {
                repository.SaveQuestWorld(relation);
                TempData["message"] = $"{relation.Quest.Name} is now available on {relation.World.Name} world";
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
