using System.Linq;
using Sims.Models.Relations;
using System;
namespace Sims.Models.Data
{
    public interface IRepository
    {
        IQueryable<Sim> Sims { get; }
        IQueryable<Activity> Activities { get; }
        IQueryable<Skill> Skills { get; }
        IQueryable<DomesticUnit> DomesticUnits { get; }
        IQueryable<Neighborhood> Neighborhoods { get; }
        IQueryable<Pet> Pets { get; }
        IQueryable<Profession> Professions { get; }
        IQueryable<Place> Places { get; }
        IQueryable<Quest> Quests { get; }
        IQueryable<World> Worlds { get; }
        IQueryable<PetType> PetTypes { get; }
        IQueryable<Exercise> Exercises { get; }
        IQueryable<Involve> Involvements { get; }
        IQueryable<Perform> Performances { get; }
        IQueryable<Travel> Travels { get; }



        IQueryable<ActivityRequiresSkill> ActivityRequiresSkillsTable { get; }
        IQueryable<NeighborhoodDomesticUnits> NeighborhoodDomesticUnitsTable { get; }
        IQueryable<NeighborhoodPlaces> NeighborhoodPlacesTable { get; }
        IQueryable<ProfessionUpgradesSkill> ProfessionUpgradesSkillsTable { get; }
        IQueryable<NeighborhoodUpgradesSkill> NeighborhoodUpgradesSkillsTable { get; }
        IQueryable<PetLives> PetLivesTable { get; }
        IQueryable<SimLives> SimLivesTable { get; }
        IQueryable<SimSkills> SimSkillsTable { get; }
        IQueryable<ActivityImprovesSkill> ActivityImprovesSkillTable { get; }
        IQueryable<QuestRequiresSkill> QuestRequiresSkillTable { get; }
        IQueryable<QuestWorld> QuestWorldTable { get; }


        void SaveSim(Sim sim);
        Sim DeleteSim(Guid simID);
        void SaveActivity(Activity activity);
        Activity DeleteActivity(Guid activityID);
        void SaveSkill(Skill skill);
        Skill DeleteSkill(Guid skillID);
        void SavePet(Pet pet);
        Pet DeletePet(Guid petID);
        void SavePetType(PetType type);
        PetType DeletePetType(Guid petID);
        void SaveNeighborhood(Neighborhood neighborhood);
        Neighborhood DeleteNeighborhood(Guid neighborhoodID);
        void SavePlace(Place place);
        Place DeletePlace(Guid placeID);
        void SaveWorld(World world);
        World DeleteWorld(Guid worldID);
        void SaveQuest(Quest quest);
        Quest DeleteQuest(Guid id);
        void SaveProfession(Profession profession);
        Profession DeleteProfession(Guid id);




        void SaveActivityRequiresSkill(ActivityRequiresSkill activityRequiresSkill);
        ActivityRequiresSkill DeleteActivityRequiresSkill(Guid ActivityID, Guid SkillID);

        void SaveQuestRequiresSkill(QuestRequiresSkill questRequiresSkill);
        QuestRequiresSkill DeleteQuestRequiresSkill(Guid QuestID, Guid SkillID);
        void SaveSimSkills(SimSkills simSkills);
        SimSkills DeleteSimSkills(Guid SimID, Guid SkillID);
        void SaveActivityImprovesSkill(ActivityImprovesSkill activityImprovesSkill);
        ActivityImprovesSkill DeleteActivityImprovesSkill(Guid ActivityID);
        void SaveDomesticUnit(DomesticUnit domesticUnit);
        DomesticUnit DeleteDomesticUnit(Guid domesticUnitID);
        void SaveExercise(Exercise exercise);
        Exercise DeleteExercise(Guid simID);
        void SaveSimLives(SimLives simLives);
        SimLives DeleteSimLives(Guid simID);
        void SaveNeighborhoodDomesticUnit(NeighborhoodDomesticUnits neiDomesticUnit);
        NeighborhoodDomesticUnits DeleteNeighborhoodDomesticUnit(Guid id);
        void SaveProfessionUpgradesSkill(ProfessionUpgradesSkill professionSkill);
        ProfessionUpgradesSkill DeleteProfessionUpgradesSkill(Guid id);
        void SaveNeighborhoodUpgradesSkill(NeighborhoodUpgradesSkill neighborhoodSkill);
        NeighborhoodUpgradesSkill DeleteNeighborhoodUpgradesSkill(Guid id);
        void SavePetLives(PetLives petLives);
        PetLives DeletePetLives(Guid id);
        void SaveNeighborhoodPlace(NeighborhoodPlaces neighborhoodPlaces);
        NeighborhoodPlaces DeleteNeighborhoodPlace(Guid id);
        void SavePerform(Perform performance);
        Perform DeletePerform(Guid SimID,Guid ActivityID);
        void SaveQuestWorld(QuestWorld questWorld);
        QuestWorld DeleteQuestWorld(Guid id);
        void SaveTravel(Travel travel);
        Travel DeleteTravel(Guid SimID, Guid WorldID, DateTime date);
        void SaveInvolve(Involve involve);
        Involve DeleteInvolve(Guid SimID, Guid WorldID, DateTime date, Guid QuestID);








    }
}