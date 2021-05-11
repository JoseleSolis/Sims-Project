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
    public class SimController : Controller
    {
        private IRepository repository;
        public SimController(IRepository repo)
        {
            repository = repo;
        }

        public ViewResult Profile(Guid id) => View(
            repository.Sims
            .FirstOrDefault(s => s.SimID == id));



        public ViewResult ChooseDomesticUnit(Guid id)
        {
            SimDomesticUnitViewModel simDomesticUnit = new SimDomesticUnitViewModel
            {
                Sim = repository.Sims.FirstOrDefault(s => s.SimID == id)
            };

            SimLives simLives = repository.SimLivesTable
                .FirstOrDefault(s => s.SimID == simDomesticUnit.Sim.SimID);

            simDomesticUnit.DomesticUnits = simLives == null ? repository.DomesticUnits : repository.DomesticUnits.Where(d => d.DomesticUnitID != simLives.DomesticUnitID);

            if (simLives != null)
            {
                DomesticUnit domesticUnit = repository.DomesticUnits
                    .FirstOrDefault(d => d.DomesticUnitID == simLives.DomesticUnitID);
                simDomesticUnit.CurrentDomesticUnitName = domesticUnit.Name;

            }

            return View(simDomesticUnit);
        }

        [HttpPost]
        public ActionResult ChooseDomesticUnit(SimDomesticUnitViewModel simDomesticUnit)
        {
            SimLives simLives = new SimLives
            {
                SimID = simDomesticUnit.Sim.SimID,
                DomesticUnitID = simDomesticUnit.DomesticUnitID
            };
            simLives.Sim = repository.Sims
                .FirstOrDefault(s => s.SimID == simLives.SimID);
            simLives.DomesticUnit = repository.DomesticUnits
                .FirstOrDefault(d => d.DomesticUnitID == simDomesticUnit.DomesticUnitID);

            if (ModelState.IsValid)
            {
                repository.SaveSimLives(simLives);
                TempData["message"] = $"{simLives.Sim.Name} now lives in {simLives.DomesticUnit.Name}";
                return RedirectToAction("Index");
            }
            else
            {
                //if enters here there is something wrong with the data values
                return View(simDomesticUnit);
            }
        }

        public ViewResult ChooseProfession(Guid id)
        {

            SimProfessionViewModel simProfession = new SimProfessionViewModel
            {
                Sim = repository.Sims.FirstOrDefault(s => s.SimID == id)
            };
            Exercise exercise = repository.Exercises
                .FirstOrDefault(e => e.SimID == simProfession.Sim.SimID);
            simProfession.Professions = exercise == null ? repository.Professions : repository.Professions.Where(p => p.ProfessionID != exercise.ProfessionID);

            if (exercise != null)
            {
                Profession profession = repository.Professions
                    .FirstOrDefault(p => p.ProfessionID == exercise.ProfessionID);
                simProfession.CurrentProfessionName = profession.Name;
                simProfession.Level = exercise.Level;
            }


            return View(simProfession);
        }

        [HttpPost]
        public ActionResult ChooseProfession(SimProfessionViewModel simProfession)
        {
            Exercise exercise = new Exercise
            {
                SimID = simProfession.Sim.SimID,
                ProfessionID = simProfession.ProfessionID,
                Level = 1
            };
            exercise.Sim = repository.Sims
                .FirstOrDefault(s => s.SimID == exercise.SimID);
            exercise.Profession = repository.Professions
                .FirstOrDefault(p => p.ProfessionID == exercise.ProfessionID);

            if (ModelState.IsValid)
            {
                repository.SaveExercise(exercise);
                TempData["message"] = $"{exercise.Sim.Name} is now a level 1 {exercise.Profession.Name}";
                return RedirectToAction("Index");
            }
            else
            {
                //if enters here there is something wrong with the data values
                return View(simProfession);
            }
        }

        public ViewResult Skills(Guid simID) => View(repository.SimSkillsTable.Where(s => s.SimID == simID));

        public ViewResult Activities(Guid id)
        {
            SimActivityViewModel viewModel = new SimActivityViewModel
            {
                Activities = repository.Activities,
                Sim = repository.Sims.FirstOrDefault(s => s.SimID == id)
            };
            return View(viewModel);
        }

        /*
        [HttpPost]
        public ActionResult PerformActivity(SimActivityViewModel viewModel)
        {
            var requirements = repository.ActivityRequiresSkillTable
                .Where(a => a.ActivityID == viewModel.ActivityID);

            var skills = repository.SimSkillsTable
                .Where(s => s.SimID == viewModel.Sim.SimID);

        }
        */
       
        /*
        public ViewResult FilterForm()
        {
            SimSearchFilterForm form = new SimSearchFilterForm
            {
                Professions = repository.Professions,
                Skills = repository.Skills
            };
            return View(form);
        }
        public ActionResult List(SimSearchFilterForm form)
        {
            var simPropsCheck = repository.Sims
                .Where(s =>
                (form.Sim.Name != null && form.Sim.Name == s.Name) || (form.Sim.Name == null && s.Name != null))
                .Where(s =>
                (form.Sim.LastName != null && form.Sim.LastName == s.LastName) || (form.Sim.LastName == null && s.LastName != null))
                .ToList();

            var professionCheck = new List<Sim>();
            if (form.ProfessionID != 0)
            {
                foreach (Sim sim in simPropsCheck)
                    if (repository.Exercises.FirstOrDefault(e => e.SimID == sim.SimID && e.ProfessionID == form.ProfessionID) != null)
                        professionCheck.Add(sim);
            }
            else professionCheck = simPropsCheck;

            var bySkillPoints = new List<SimSkillPoints>();
            var simsBySkillPoints = new List<Sim>();
            if (form.SkillID != 0)
            {
                foreach (Sim sim in professionCheck)
                {
                    var simPoints = repository.SimSkills.FirstOrDefault(s => s.SimID == sim.SimID && s.SkillID == form.SkillID);
                    if (simPoints == null)
                        bySkillPoints.Add(new SimSkillPoints
                        {
                            Sim = sim,
                            SkillPoints = 0
                        });
                    else
                        bySkillPoints.Add(new SimSkillPoints
                        {
                            Sim = sim,
                            SkillPoints = simPoints.Points
                        });
                }
                bySkillPoints.OrderByDescending(s => s.SkillPoints);
                for (int i = 0; i < bySkillPoints.Count; i++)
                    simsBySkillPoints.Add(bySkillPoints[i].Sim);
            }
            else simsBySkillPoints = professionCheck;
            
            simsBySkillPoints.
            
            return View(professionCheck);
            
            
        }
        
        */  
        

        public ViewResult Index() => View(repository.Sims);
        
        public ViewResult Edit(Guid simID) =>
           View(repository.Sims
               .FirstOrDefault(s => s.SimID == simID));

        [HttpPost]
        public IActionResult Edit(Sim sim)
        {

            if (ModelState.IsValid)
            {
                repository.SaveSim(sim);
                TempData["message"] = $"{sim.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                 //if enters here there is something wrong with the data values
                return View(sim);
            }
        }
        public ViewResult Create() => View("Edit", new Sim());
         
        [HttpPost]
        public IActionResult Delete(Guid simID)
        {
            Sim deletedSim = repository.DeleteSim(simID);
            if (deletedSim != null)
            {
                TempData["message"] = $"{deletedSim.Name} was deleted";
            }
            return RedirectToAction("Index");
        }
        
    }
}
