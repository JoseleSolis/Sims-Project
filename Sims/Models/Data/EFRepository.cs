using System.Collections.Generic;
using System.Linq;
using System;
using Sims.Models.Relations;
namespace Sims.Models.Data
{
    public class EFRepository : IRepository
    {
        private ApplicationDbContext context;

        public EFRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Sim> Sims => context.Sims;
        public IQueryable<Activity> Activities => context.Activities;
        public IQueryable<Skill> Skills => context.Skills;
        public IQueryable<DomesticUnit> DomesticUnits => context.DomesticUnits;
        public IQueryable<Neighborhood> Neighborhoods => context.Neighborhoods;
        public IQueryable<Pet> Pets => context.Pets;
        public IQueryable<Profession> Professions => context.Professions;
        public IQueryable<Place> Places => context.Places;
        public IQueryable<Quest> Quests => context.Quests;
        public IQueryable<World> Worlds => context.Worlds;
        public IQueryable<PetType> PetTypes => context.PetTypes;


        public IQueryable<Exercise> Exercises => context.Exercises;
        public IQueryable<Involve> Involvements => context.Involvements;
        public IQueryable<Perform> Performances => context.Performances;
        public IQueryable<Travel> Travels => context.Travels;
        public IQueryable<NeighborhoodDomesticUnits> NeighborhoodDomesticUnitsTable => context.NeighborhoodDomesticUnits;
        public IQueryable<NeighborhoodPlaces> NeighborhoodPlacesTable => context.NeighborhoodPlaces;
        public IQueryable<ProfessionUpgradesSkill> ProfessionUpgradesSkillsTable => context.ProfessionUpgradesSkill;
        public IQueryable<PetLives> PetLivesTable => context.PetLives;
        public IQueryable<SimLives> SimLivesTable => context.SimLives;
        public IQueryable<SimSkills> SimSkillsTable => context.SimSkills;
        public IQueryable<ActivityRequiresSkill> ActivityRequiresSkillsTable => context.ActivityRequiresSkill;
        public IQueryable<ActivityImprovesSkill> ActivityImprovesSkillTable => context.ActivityImprovesSkill;
        public IQueryable<QuestRequiresSkill> QuestRequiresSkillTable => context.QuestRequiresSkill;


        public void SaveSim(Sim sim)
        {
            if (sim.SimID.CompareTo(Guid.Empty) == 0)
            {
                context.Sims.Add(sim);
            }
            else
            {
                Sim dbEntry = context.Sims
                .FirstOrDefault(s => s.SimID == sim.SimID);
                if (dbEntry != null)
                {
                    dbEntry.Name = sim.Name;
                    dbEntry.LastName = sim.LastName;
                    dbEntry.Money = sim.Money;
                    dbEntry.Gender = sim.Gender;
                    dbEntry.LifeStage = sim.LifeStage;
                }
            }
            context.SaveChanges();
        }
        public Sim DeleteSim(Guid simID)
        {
            Sim dbEntry = context.Sims
            .FirstOrDefault(s => s.SimID == simID);
            if (dbEntry != null)
            {
                context.Sims.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        public void SaveActivity(Activity activity)
        {
            if (activity.ActivityID.CompareTo(Guid.Empty) == 0)
            {
                context.Activities.Add(activity);
            }
            else
            {
                Activity dbEntry = context.Activities
                .FirstOrDefault(a => a.ActivityID == activity.ActivityID);
                if (dbEntry != null)
                {
                    dbEntry.Name = activity.Name;
                    dbEntry.Description = activity.Description;
                }
            }
            context.SaveChanges();
        }
        public Activity DeleteActivity(Guid activityID)
        {
            Activity dbEntry = context.Activities
            .FirstOrDefault(a => a.ActivityID == activityID);
            if (dbEntry != null)
            {
                context.Activities.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        public void SaveSkill(Skill skill)
        {
            if (skill.SkillID.CompareTo(Guid.Empty) == 0)
            {
                context.Skills.Add(skill);
            }
            else
            {
                Skill dbEntry = context.Skills
                .FirstOrDefault(s => s.SkillID == skill.SkillID);
                if (dbEntry != null)
                {
                    dbEntry.Name = skill.Name;
                    dbEntry.Description = skill.Description;
                }
            }
            context.SaveChanges();
        }
        public Skill DeleteSkill(Guid skillID)
        {
            Skill dbEntry = context.Skills
            .FirstOrDefault(s => s.SkillID == skillID);
            if (dbEntry != null)
            {
                context.Skills.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void SaveDomesticUnit(DomesticUnit domesticUnit)
        {
            if (domesticUnit.DomesticUnitID.CompareTo(Guid.Empty) == 0)
            {
                context.DomesticUnits.Add(domesticUnit);
            }
            else
            {
                DomesticUnit dbEntry = context.DomesticUnits
                .FirstOrDefault(d => d.DomesticUnitID == domesticUnit.DomesticUnitID);
                if (dbEntry != null)
                {
                    dbEntry.Name = domesticUnit.Name;
                    dbEntry.RoomNumber = domesticUnit.RoomNumber;
                    dbEntry.BathroomNumber = domesticUnit.BathroomNumber;
                    dbEntry.Description = domesticUnit.Description;
                }
            }
            context.SaveChanges();
        }
        public DomesticUnit DeleteDomesticUnit(Guid domesticUnitID)
        {
            DomesticUnit dbEntry = context.DomesticUnits
            .FirstOrDefault(d => d.DomesticUnitID == domesticUnitID);
            if (dbEntry != null)
            {
                context.DomesticUnits.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }




        public void SavePet(Pet pet)
        {
            if (pet.PetID.CompareTo(Guid.Empty) == 0)
            {
                context.Pets.Add(pet);
            }
            else
            {
                Pet dbEntry = context.Pets
                .FirstOrDefault(p => p.PetID == pet.PetID);
                if (dbEntry != null)
                {
                    dbEntry.Name = pet.Name;
                    dbEntry.Type = pet.Type;
                    dbEntry.TypeName = pet.TypeName;
                }
            }
            context.SaveChanges();
        }
        public Pet DeletePet(Guid petID)
        {
            Pet dbEntry = context.Pets
            .FirstOrDefault(p => p.PetID == petID);
            if (dbEntry != null)
            {
                context.Pets.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        public void SavePetType(PetType petType)
        {
            if (petType.TypeID.CompareTo(Guid.Empty) == 0)
            {
                context.PetTypes.Add(petType);
            }
            else
            {
                PetType dbEntry = context.PetTypes
                .FirstOrDefault(p => p.TypeID == petType.TypeID);
                if (dbEntry != null)
                {
                    dbEntry.Name = petType.Name;
                    dbEntry.Description = petType.Description;
                }
            }
            context.SaveChanges();
        }
        public PetType DeletePetType(Guid typeID)
        {
            PetType dbEntry = context.PetTypes
            .FirstOrDefault(p => p.TypeID == typeID);
            if (dbEntry != null)
            {
                context.PetTypes.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        public void SaveNeighborhood(Neighborhood neighborhood)
        {
            if (neighborhood.NeighborhoodID.CompareTo(Guid.Empty) == 0)
            {
                context.Neighborhoods.Add(neighborhood);
            }
            else
            {
                Neighborhood dbEntry = context.Neighborhoods
                .FirstOrDefault(n => n.NeighborhoodID == neighborhood.NeighborhoodID);
                if (dbEntry != null)
                {
                    dbEntry.Name = neighborhood.Name;
                    dbEntry.Description = neighborhood.Description;
                }
            }
            context.SaveChanges();
        }
        public Neighborhood DeleteNeighborhood(Guid neighborhoodID)
        {
            Neighborhood dbEntry = context.Neighborhoods
            .FirstOrDefault(n => n.NeighborhoodID == neighborhoodID);
            if (dbEntry != null)
            {
                context.Neighborhoods.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        public void SavePlace(Place place)
        {
            if (place.PlaceID.CompareTo(Guid.Empty) == 0)
            {
                context.Places.Add(place);
            }
            else
            {
                Place dbEntry = context.Places
                .FirstOrDefault(p => p.PlaceID == place.PlaceID);
                if (dbEntry != null)
                {
                    dbEntry.Name = place.Name;
                    dbEntry.Cost = place.Cost;
                    dbEntry.Description = place.Description;
                }
            }
            context.SaveChanges();
        }
        public Place DeletePlace(Guid placeID)
        {
            Place dbEntry = context.Places
            .FirstOrDefault(n => n.PlaceID == placeID);
            if (dbEntry != null)
            {
                context.Places.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        public void SaveWorld(World world)
        {
            if (world.WorldID.CompareTo(Guid.Empty) == 0)
            {
                context.Worlds.Add(world);
            }
            else
            {
                World dbEntry = context.Worlds
                .FirstOrDefault(p => p.WorldID == world.WorldID);
                if (dbEntry != null)
                {
                    dbEntry.Name = world.Name;
                    dbEntry.Description = world.Description;
                }
            }
            context.SaveChanges();
        }
        public World DeleteWorld(Guid worldID)
        {
            World dbEntry = context.Worlds
            .FirstOrDefault(n => n.WorldID == worldID);
            if (dbEntry != null)
            {
                context.Worlds.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        public void SaveQuest(Quest quest)
        {
            if (quest.QuestID.CompareTo(Guid.Empty) == 0)
            {
                context.Quests.Add(quest);
            }
            else
            {
                Quest dbEntry = context.Quests
                .FirstOrDefault(p => p.QuestID == quest.QuestID);
                if (dbEntry != null)
                {
                    dbEntry.Name = quest.Name;
                    dbEntry.Cost = quest.Cost;
                    dbEntry.Reward = quest.Reward;
                }
            }
            context.SaveChanges();
        }
        public Quest DeleteQuest(Guid questID)
        {
            Quest dbEntry = context.Quests
            .FirstOrDefault(n => n.QuestID == questID);
            if (dbEntry != null)
            {
                context.Quests.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        public void SaveProfession(Profession profession)
        {
            if (profession.ProfessionID.CompareTo(Guid.Empty) == 0)
            {
                context.Professions.Add(profession);
            }
            else
            {
                Profession dbEntry = context.Professions
                .FirstOrDefault(p => p.ProfessionID == profession.ProfessionID);
                if (dbEntry != null)
                {
                    dbEntry.Name = profession.Name;
                    dbEntry.BasicSalary = profession.BasicSalary;
                }
            }
            context.SaveChanges();
        }
        public Profession DeleteProfession(Guid id)
        {
            Profession dbEntry = context.Professions
            .FirstOrDefault(n => n.ProfessionID == id);
            if (dbEntry != null)
            {
                context.Professions.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }


        public void SaveExercise(Exercise exercise)
        {
            Exercise dbEntry = context.Exercises
                .FirstOrDefault(e => e.SimID == exercise.SimID);

            if (dbEntry != null) DeleteExercise(exercise.SimID);
            context.Exercises.Add(exercise);
            context.SaveChanges();
        }
        public Exercise DeleteExercise(Guid simID)
        {
            Exercise dbEntry = context.Exercises
            .FirstOrDefault(e => e.SimID == simID);
            if (dbEntry != null)
            {
                context.Exercises.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        public void SaveSimLives(SimLives simLives)
        {
            SimLives dbEntry = context.SimLives
                .FirstOrDefault(s => s.SimID == simLives.SimID);

            if (dbEntry != null) DeleteSimLives(simLives.SimID);
            context.SimLives.Add(simLives);
            context.SaveChanges();
        }
        public SimLives DeleteSimLives(Guid simID)
        {
            SimLives dbEntry = context.SimLives
                .FirstOrDefault(s => s.SimID == simID);
            if (dbEntry != null)
            {
                context.SimLives.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        public void SaveNeighborhoodDomesticUnit(NeighborhoodDomesticUnits neiDomesticUnit)
        {
            NeighborhoodDomesticUnits dbEntry = context.NeighborhoodDomesticUnits
                .FirstOrDefault(n => n.DomesticUnitID == neiDomesticUnit.DomesticUnitID);

            if (dbEntry != null) DeleteNeighborhoodDomesticUnit(neiDomesticUnit.DomesticUnitID);
            context.NeighborhoodDomesticUnits.Add(neiDomesticUnit);
            context.SaveChanges();
        }
        public NeighborhoodDomesticUnits DeleteNeighborhoodDomesticUnit(Guid id)
        {
            NeighborhoodDomesticUnits dbEntry = context.NeighborhoodDomesticUnits
                   .FirstOrDefault(n => n.DomesticUnitID == id);
            if (dbEntry != null)
            {
                context.NeighborhoodDomesticUnits.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        public void SavePetLives(PetLives petLives)
        {
            PetLives dbEntry = context.PetLives
                .FirstOrDefault(n => n.PetID == petLives.PetID);

            if (dbEntry != null) DeletePetLives(petLives.PetID);
            context.PetLives.Add(petLives);
            context.SaveChanges();
        }
        public PetLives DeletePetLives(Guid id)
        {
            PetLives dbEntry = context.PetLives
                   .FirstOrDefault(n => n.PetID == id);
            if (dbEntry != null)
            {
                context.PetLives.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        public void SaveNeighborhoodPlace(NeighborhoodPlaces neighborhoodPlaces)
        {
            NeighborhoodPlaces dbEntry = context.NeighborhoodPlaces
                .FirstOrDefault(n => n.PlaceID == neighborhoodPlaces.PlaceID);

            if (dbEntry != null) DeleteNeighborhoodPlace(neighborhoodPlaces.PlaceID);
            context.NeighborhoodPlaces.Add(neighborhoodPlaces);
            context.SaveChanges();
        }
        public NeighborhoodPlaces DeleteNeighborhoodPlace(Guid id)
        {
            NeighborhoodPlaces dbEntry = context.NeighborhoodPlaces
                   .FirstOrDefault(n => n.PlaceID == id);
            if (dbEntry != null)
            {
                context.NeighborhoodPlaces.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        public void SaveActivityRequiresSkill(ActivityRequiresSkill activityRequiresSkill)
        {
            context.ActivityRequiresSkill.Add(activityRequiresSkill);
            context.SaveChanges();
        }
    }   
}