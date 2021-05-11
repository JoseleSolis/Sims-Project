using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sims.Models;
using Sims.Models.Data;
using Sims.Models.Relations;
using Sims.Models.ViewModels;

namespace Sims.Controllers
{
    public class ActivityController : Controller
    {
        private IRepository repository;
        public ActivityController(IRepository repo)
        {
            repository = repo;
        }
        public ViewResult Profile(Guid id) => View(
            repository.Activities
            .FirstOrDefault(a => a.ActivityID == id));

        public ViewResult Index() => View(repository.Activities);

        public ViewResult Edit(Guid activityID) =>
         View(repository.Activities
             .FirstOrDefault(a => a.ActivityID == activityID));

        [HttpPost]
        public IActionResult Edit(Activity activity)
        {

            if (ModelState.IsValid)
            {
                repository.SaveActivity(activity);
                TempData["message"] = $"{activity.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                // if enters here there is something wrong with the data values
                return View(activity);
            }
        }

        public ViewResult Create() => View("Edit", new Activity());

        
        [HttpPost]
        public IActionResult Delete(Guid activityID)
        {
            Activity deletedActivity = repository.DeleteActivity(activityID);
            if (deletedActivity != null)
            {
                TempData["message"] = $"{deletedActivity.Name} was deleted";
            }
            return RedirectToAction("Index");
        }

        
        
        public ViewResult Requirements(Guid id)
        {
            ActivityRequirementsViewModel viewModel = new ActivityRequirementsViewModel
            {
                Activity = repository.Activities.FirstOrDefault(a => a.ActivityID == id),
                Skills = repository.Skills.ToList(),
            };
            List<int> reqPoints = new List<int>();
            for (int i = 0; i < viewModel.Skills.Count; i++)
                reqPoints.Add(0);
            viewModel.RequiredPoints = reqPoints;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Requirements(ActivityRequirementsViewModel viewModelPost)
        {
            List<ActivityRequiresSkill> activityRequiresSkills = new List<ActivityRequiresSkill>();
            for (int i = 0; i < viewModelPost.Skills.Count; i++)
            {
                if (viewModelPost.RequiredPoints[i] > 0)
                {
                    activityRequiresSkills.Add(new ActivityRequiresSkill
                    {
                        Skill = repository.Skills.FirstOrDefault(s => s.SkillID == viewModelPost.Skills[i].SkillID),
                        Activity = repository.Activities.FirstOrDefault(a=>a.ActivityID == viewModelPost.Activity.ActivityID),
                        RequiredPoints = viewModelPost.RequiredPoints[i]
                    });
                }
            }


            var toDelete = repository.ActivityRequiresSkillsTable.Where(a => a.ActivityID == viewModelPost.Activity.ActivityID).ToList();
            foreach (ActivityRequiresSkill item in toDelete)
                repository.DeleteActivityRequiresSkill(item.ActivityID, item.SkillID);

            foreach (ActivityRequiresSkill item in activityRequiresSkills)
                repository.SaveActivityRequiresSkill(item);

            return RedirectToAction("Index");
        }


    }
}
