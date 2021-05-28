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

        public ViewResult CostInfo()
        {
            double min = double.MaxValue;
            double max = double.MinValue;
            double avg = 0;
            int count = 0;
            foreach (Quest quest in repository.Quests)
            {
                if (quest.Cost < min) min = quest.Cost;
                if (quest.Cost > max) max = quest.Cost;
                avg += quest.Cost;
                count++;
            }
            if (count > 0) avg /= count;
            QuestInfoViewModel viewModel = new QuestInfoViewModel
            {
                Max = max,
                Min = min,
                Avg = avg
            };
            return View(viewModel);
        }
        public ViewResult RewardInfo()
        {
            double min = double.MaxValue;
            double max = double.MinValue;
            double avg = 0;
            int count = 0;
            foreach (Quest quest in repository.Quests)
            {
                if (quest.Reward < min) min = quest.Reward;
                if (quest.Reward > max) max = quest.Reward;
                avg += quest.Reward;
                count++;
            }
            if (count > 0) avg /= count;
            QuestInfoViewModel viewModel = new QuestInfoViewModel
            {
                Max = max,
                Min = min,
                Avg = avg
            };
            return View(viewModel);
        }
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
            foreach (var item in repository.QuestRequiresSkillTable.Where(q => q.QuestID == questID))
                repository.DeleteQuestRequiresSkill(questID, item.SkillID);
            if (repository.QuestWorldTable.FirstOrDefault(p => p.QuestID == questID) != null)
                repository.DeleteQuestWorld(questID);
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

        public ViewResult Requirements(Guid id)
        {
            QuestRequirementsViewModel viewModel = new QuestRequirementsViewModel
            {
                Quest = repository.Quests.FirstOrDefault(q=>q.QuestID == id),
                Skills = repository.Skills.ToList(),
            };
            List<int> reqPoints = new List<int>();
            for (int i = 0; i < viewModel.Skills.Count; i++)
                reqPoints.Add(0);
            viewModel.RequiredPoints = reqPoints;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Requirements(QuestRequirementsViewModel viewModelPost)
        {
            List<QuestRequiresSkill> questRequiresSkills = new List<QuestRequiresSkill>();
            for (int i = 0; i < viewModelPost.Skills.Count; i++)
            {
                if (viewModelPost.RequiredPoints[i] > 0)
                {
                    questRequiresSkills.Add(new QuestRequiresSkill
                    {
                        Skill = repository.Skills.FirstOrDefault(s => s.SkillID == viewModelPost.Skills[i].SkillID),
                        Quest = repository.Quests.FirstOrDefault(q=>q.QuestID == viewModelPost.Quest.QuestID),
                        RequiredPoints = viewModelPost.RequiredPoints[i]
                    });
                }
            }
            
            var toDelete = repository.QuestRequiresSkillTable.Where(a => a.QuestID == viewModelPost.Quest.QuestID).ToList();
            foreach (QuestRequiresSkill item in toDelete)
                repository.DeleteActivityRequiresSkill(item.QuestID, item.SkillID);

            foreach (QuestRequiresSkill item in questRequiresSkills)
                repository.SaveQuestRequiresSkill(item);

            return RedirectToAction("Index");
        }
       
    }
}
