using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sims.Models;
using Sims.Models.Data;
using Sims.Models.Relations;

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

        
        /*
        public ViewResult Requirements(Guid id)
        {
            ActivityRequirementsViewModel viewModel = new ActivityRequirementsViewModel
            {
                Activity = repository.Activities.FirstOrDefault(a => a.ActivityID == id),
            };

            return View(viewModel);
        }
        */


        public ViewResult Temp(Guid id)
        {
            return View(repository.Activities.FirstOrDefault(a => a.ActivityID == id));
        }
        [HttpPost]
        public ActionResult Temp(Activity ac)
        {
            ActivityRequiresSkill asd = new ActivityRequiresSkill
            {
                Activity = repository.Activities.First(x=>x.ActivityID == ac.ActivityID),
                RequiredPoints = 2,
                Skill = repository.Skills.First()
            };
            if (ModelState.IsValid)
            {
                repository.SaveActivityRequiresSkill(asd);
            }

            return View("Index");
        }
        
    }
}
