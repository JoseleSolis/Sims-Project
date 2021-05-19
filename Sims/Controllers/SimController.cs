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


        public ActionResult Work(Guid id)
        {
            var simJob = repository.Exercises.FirstOrDefault(s => s.SimID == id);

            Sim sim = repository.Sims.FirstOrDefault(s => s.SimID == id);
            Profession profession = repository.Professions.FirstOrDefault(p => p.ProfessionID == simJob.ProfessionID);
            sim.Money += simJob.Level * profession.BasicSalary;
            repository.SaveSim(sim);

            if (simJob.Level < 10)
                simJob.Level++;

            repository.SaveExercise(simJob);

            ProfessionUpgradesSkill upgrade = repository.ProfessionUpgradesSkillsTable.FirstOrDefault(p => p.ProfessionID == profession.ProfessionID);
            if (upgrade != null)
            {
                SimSkills simSkill = repository.SimSkillsTable.FirstOrDefault(s => s.SimID == sim.SimID && s.SkillID == upgrade.SkillID);
                if (simSkill == null)
                {
                    simSkill = new SimSkills
                    {
                        Sim = repository.Sims.FirstOrDefault(s => s.SimID == sim.SimID),
                        Skill = repository.Skills.FirstOrDefault(s => s.SkillID == upgrade.SkillID),
                        Points = 1
                    };
                    repository.SaveSimSkills(simSkill);
                }
                else if (simSkill.Points < 10)
                {
                    simSkill.Skill = repository.Skills.FirstOrDefault(s => s.SkillID == simSkill.SkillID);
                    simSkill.Points++;
                    repository.SaveSimSkills(simSkill);
                }

            }
            return RedirectToAction("Profile", new { id = id });
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

        public ViewResult Skills(Guid id)
        {
            SimSkillViewModel viewModel = new SimSkillViewModel
            {
                Sim = repository.Sims.FirstOrDefault(s => s.SimID == id),
                SkillPoints = new List<SkillPoints>()
            };
            IEnumerable<SimSkills> thisSimSkills = repository.SimSkillsTable.Where(s => s.SimID == id);

            foreach (SimSkills skills in thisSimSkills)
                viewModel.SkillPoints.Add(new SkillPoints
                {
                    Skill = repository.Skills.FirstOrDefault(s => s.SkillID == skills.SkillID),
                    Points = skills.Points
                });
            return View(viewModel);
        }


        public ViewResult Activities(Guid id)
        {
            SimActivityViewModel viewModel = new SimActivityViewModel
            {
                Activities = repository.Activities,
                Sim = repository.Sims.FirstOrDefault(s => s.SimID == id)
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Activities(SimActivityViewModel viewModel)
        {
            viewModel.Activities = repository.Activities;
            var requirements = repository.ActivityRequiresSkillsTable
                .Where(a => a.ActivityID == viewModel.ActivityID);

            var skills = repository.SimSkillsTable
                .Where(s => s.SimID == viewModel.Sim.SimID);



            foreach (ActivityRequiresSkill requirement in requirements)
            {
                var temp = skills.FirstOrDefault(s => s.SkillID == requirement.SkillID);
                if (temp == null || temp.Points < requirement.RequiredPoints)
                {
                    string actName = repository.Activities.FirstOrDefault(a => a.ActivityID == requirement.ActivityID).Name;
                    string skiName = repository.Skills.FirstOrDefault(s => s.SkillID == requirement.SkillID).Name;
                    string pronoun = viewModel.Sim.Gender == "Masculine" ? "she" : "he";

                    ViewBag.Message = $"{viewModel.Sim.Name} couldn't perform the activity {actName} " +
                        $"because {pronoun} does not fulfill {skiName} required points";
                    ViewBag.Error = true;

                    return View(viewModel);
                }
            }
            Perform performance = new Perform
            {
                Sim = repository.Sims.FirstOrDefault(s => s.SimID == viewModel.Sim.SimID),
                Activity = repository.Activities.FirstOrDefault(a => a.ActivityID == viewModel.ActivityID),
                LastPerform = DateTime.Today
            };
            repository.SavePerform(performance);
            ViewBag.Message = $"{performance.Activity.Name} successfully performed ";

            ActivityImprovesSkill improvement = repository.ActivityImprovesSkillTable.FirstOrDefault(i => i.ActivityID == performance.ActivityID);
            if (improvement != null)
            {
                SimSkills simSkill = repository.SimSkillsTable.
                    FirstOrDefault(s => s.SimID == viewModel.Sim.SimID && s.SkillID == improvement.SkillID);
                if (simSkill == null)
                {
                    simSkill = new SimSkills
                    {
                        Sim = repository.Sims.FirstOrDefault(s => s.SimID == viewModel.Sim.SimID),
                        Skill = repository.Skills.FirstOrDefault(s => s.SkillID == improvement.SkillID),
                        Points = 1
                    };
                    ViewBag.ImprovementMessage = $"{simSkill.Sim.Name} improved {simSkill.Skill.Name}'s skill points";
                    repository.SaveSimSkills(simSkill);
                }
                else if (simSkill.Points < 10)
                {
                    simSkill.Skill = repository.Skills.FirstOrDefault(s => s.SkillID == simSkill.SkillID);
                    simSkill.Points++;
                    repository.SaveSimSkills(simSkill);
                    ViewBag.ImprovementMessage = $"{simSkill.Sim.Name} improved {simSkill.Skill.Name}'s skill points";
                }
            }

            ViewBag.Error = false;
            return View(viewModel);
        }



        public ViewResult FilterForm()
        {
            SimSearchFilterForm form = new SimSearchFilterForm
            {
                Professions = repository.Professions,
                Skills = repository.Skills,
                Neighborhoods = repository.Neighborhoods
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
            if (form.ProfessionID.CompareTo(Guid.Empty) != 0)
            {
                foreach (Sim sim in simPropsCheck)
                    if (repository.Exercises.FirstOrDefault(e => e.SimID == sim.SimID && e.ProfessionID == form.ProfessionID) != null)
                        professionCheck.Add(sim);
            }
            else professionCheck = simPropsCheck;

            var neighborhoodCheck = new List<Sim>();
            if (form.NeighborhoodID.CompareTo(Guid.Empty) != 0)
            {
                foreach (Sim sim in professionCheck)
                {
                    var simDomesticUnit = repository.SimLivesTable.FirstOrDefault(s => s.SimID == sim.SimID);
                    if (simDomesticUnit != null)
                    {
                        var domesticUnitNeighborhood = repository.NeighborhoodDomesticUnitsTable.FirstOrDefault(d => d.DomesticUnitID == simDomesticUnit.DomesticUnitID);
                        if (domesticUnitNeighborhood != null & domesticUnitNeighborhood.NeighborhoodID == form.NeighborhoodID)
                            neighborhoodCheck.Add(sim);
                    }
                }
            }
            else neighborhoodCheck = professionCheck;


            var bySkillPoints = new List<SimSkillPoints>();
            var simsBySkillPoints = new List<Sim>();
            if (form.SkillID.CompareTo(Guid.Empty) != 0)
            {
                foreach (Sim sim in neighborhoodCheck)
                {
                    var simPoints = repository.SimSkillsTable.FirstOrDefault(s => s.SimID == sim.SimID && s.SkillID == form.SkillID);
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
                var ordered = bySkillPoints.OrderByDescending(s => s.SkillPoints);
                foreach (var simPoints in ordered)
                    simsBySkillPoints.Add(simPoints.Sim);

            }
            else simsBySkillPoints = neighborhoodCheck;

            var petOwnerCheck = new List<Sim>();
            if (form.PetOwner == "No")
            {
                foreach (Sim sim in simsBySkillPoints)
                {
                    SimLives simDomesticUnit = repository.SimLivesTable.FirstOrDefault(s => s.SimID == sim.SimID);
                    if (simDomesticUnit == null || repository.PetLivesTable.First(d => d.DomesticUnitID == simDomesticUnit.DomesticUnitID) == null)
                        petOwnerCheck.Add(sim);
                }
            }
            else if (form.PetOwner == "Yes")
            {
                foreach (Sim sim in simsBySkillPoints)
                {
                    SimLives simDomesticUnit = repository.SimLivesTable.FirstOrDefault(s => s.SimID == sim.SimID);
                    if (simDomesticUnit != null && repository.PetLivesTable.First(d => d.DomesticUnitID == simDomesticUnit.DomesticUnitID) != null)
                        petOwnerCheck.Add(sim);
                }
            }
            else petOwnerCheck = simsBySkillPoints;


            var truncatedList = new List<Sim>();
            int range = Math.Min(petOwnerCheck.Count, form.FirstHowMany);
            for (int i = 0; i < range; i++)
                truncatedList.Add(petOwnerCheck[i]);

            return View(truncatedList);
        }


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
            if(repository.Exercises.FirstOrDefault(s=>s.SimID == simID) != null) repository.DeleteExercise(simID);
            if (repository.SimLivesTable.FirstOrDefault(s => s.SimID == simID) != null) repository.DeleteSimLives(simID);
            foreach (var item in repository.SimSkillsTable.Where(s=>s.SimID == simID))
                repository.DeleteSimSkills(simID, item.SkillID);
            return RedirectToAction("Index");
        }

        public ViewResult Travel(Guid id)
        {
            SimTravelViewModel simTravel = new SimTravelViewModel
            {
                Sim = repository.Sims.FirstOrDefault(s => s.SimID == id),
                Worlds = repository.Worlds
            };
            return View(simTravel);
        }

        [HttpPost]
        public ActionResult Travel(SimTravelViewModel viewModel)
        {
            Travel travel = new Travel
            {
                SimID = viewModel.Sim.SimID,
                WorldID = viewModel.WorldID
            };

            travel.Sim = repository.Sims
                .FirstOrDefault(s => s.SimID == travel.SimID);

            travel.World = repository.Worlds
                .FirstOrDefault(d => d.WorldID == viewModel.WorldID);

            travel.Date = DateTime.Today;

            if (ModelState.IsValid)
            {
                if(repository.Travels.FirstOrDefault(s=>s.SimID == travel.SimID && s.WorldID == travel.WorldID && s.Date.CompareTo(travel.Date) == 0) != null)
                {
                    ViewBag.Message = $"{travel.Sim.Name} cannot travel again to {travel.World.Name} today";
                    ViewBag.Success = false;
                    return View("Profile", travel.Sim);
                }
                repository.SaveTravel(travel);
                return RedirectToAction("Quests", travel);
            }
            else
            {
                //if enters here there is something wrong with the data values
                return View(viewModel);
            }
        }

        public ViewResult Quests(Travel travel)
        {
            var questsInWorld = repository.QuestWorldTable.Where(w => w.WorldID == travel.WorldID);
            var quests = new List<Quest>();
            foreach (QuestWorld item in questsInWorld)
                quests.Add(repository.Quests.FirstOrDefault(q => q.QuestID == item.QuestID));

            SimQuestViewModel viewModel = new SimQuestViewModel
            {
                Travel = travel,
                Quests = quests
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Quests(SimQuestViewModel viewModel)
        {
            Sim sim = repository.Sims.FirstOrDefault(s => s.SimID == viewModel.Travel.SimID);
            Quest quest = repository.Quests.FirstOrDefault(q => q.QuestID == viewModel.QuestID);
            string pronoun = sim.Gender == "Masculine" ? "she" : "he";

            if (sim.Money < quest.Cost)
            {
                ViewBag.Message = $"{sim.Name} couldn't enter to {quest.Name} quest because {pronoun} can't afford it";
                ViewBag.Success = false;
                return View("Profile", sim);
            }
            
            var simSkills = repository.SimSkillsTable.Where(s => s.SimID == viewModel.Travel.SimID);
            var questReq = repository.QuestRequiresSkillTable.Where(q => q.QuestID == viewModel.QuestID);
            foreach (QuestRequiresSkill item in questReq)
            {
                
                SimSkills temp = simSkills.FirstOrDefault(s => s.SkillID == item.SkillID);
                if (temp == null || temp.Points < item.RequiredPoints)
                {                 
                    Skill skill = repository.Skills.FirstOrDefault(s => s.SkillID == item.SkillID);
                    ViewBag.Message = $"{sim.Name} couldn't enter to {quest.Name} quest because {pronoun} lacks {skill.Name} skill points";
                    ViewBag.Success = false;
                    return View("Profile", sim);
                }
            }

            Involve travelInvolveQuest = new Involve
            {
                SimID = viewModel.Travel.SimID,
                WorldID = viewModel.Travel.WorldID,
                Date = viewModel.Travel.Date,
                QuestID = viewModel.QuestID
            };

            travelInvolveQuest.Quest = repository.Quests.FirstOrDefault(q => q.QuestID == travelInvolveQuest.QuestID);
           
            travelInvolveQuest.Travel = repository.Travels
                .FirstOrDefault(q => 
                    q.SimID == travelInvolveQuest.SimID &&
                    q.WorldID == travelInvolveQuest.WorldID &&
                    q.Date.CompareTo(travelInvolveQuest.Date) == 0 
                    );

            Random r = new Random();
            travelInvolveQuest.Success = (r.Next(23) % 2 == 0);


            repository.SaveInvolve(travelInvolveQuest);

            Sim updateSim = new Sim
            {
                SimID = sim.SimID,
                LifeStage = sim.LifeStage,
                Gender = sim.Gender,
                LastName = sim.LastName,
                Name = sim.Name
            };
            if (travelInvolveQuest.Success) 
            {
                updateSim.Money = sim.Money + (quest.Reward - quest.Cost);
                ViewBag.Message = $"{sim.Name} succeeded at {quest.Name} quest and earned {quest.Reward - quest.Cost} simoleons";
                ViewBag.Success = true;
            }
            else
            {
                double money = sim.Money - quest.Cost;
                if (money < 0) money = 0;
                updateSim.Money = money;
                ViewBag.Message = $"{sim.Name} failed at {quest.Name} quest and lost {quest.Cost} simoleons";
                ViewBag.Success = false;
            }

            repository.SaveSim(updateSim);

            return View("Profile", updateSim);
        }
    }
}
