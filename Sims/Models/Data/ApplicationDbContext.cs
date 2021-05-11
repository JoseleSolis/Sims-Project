using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sims.Models.Relations;

namespace Sims.Models.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
        public DbSet<Sim> Sims { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<DomesticUnit> DomesticUnits { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetType> PetTypes { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Quest> Quests { get; set; }
        public DbSet<World> Worlds { get; set; }


        public DbSet<ActivityImprovesSkill> ActivityImprovesSkill { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Involve> Involvements { get; set; }
        public DbSet<NeighborhoodDomesticUnits> NeighborhoodDomesticUnits { get; set; }
        public DbSet<ActivityRequiresSkill> ActivityRequiresSkill { get; set; }
        public DbSet<Perform> Performances { get; set; }
        public DbSet<NeighborhoodPlaces> NeighborhoodPlaces { get; set; }
        public DbSet<PetLives> PetLives { get; set; }
        public DbSet<ProfessionUpgradesSkill> ProfessionUpgradesSkill { get; set; }
        public DbSet<QuestRequiresSkill> QuestRequiresSkill { get; set; }
        public DbSet<SimLives> SimLives { get; set; }
        public DbSet<SimSkills> SimSkills { get; set; }
        public DbSet<Travel> Travels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<ActivityRequiresSkill>().HasKey(m => new { m.SkillID, m.ActivityID });            
            modelBuilder.Entity<Involve>().HasKey(m => new { m.SimID, m.Date, m.QuestID, m.WorldID });
            modelBuilder.Entity<Perform>().HasKey(m => new { m.SimID, m.ActivityID });
            modelBuilder.Entity<Travel>().HasKey(m => new { m.SimID, m.WorldID, m.Date });           
            modelBuilder.Entity<ProfessionUpgradesSkill>().HasKey(m => new { m.ProfessionID, m.SkillID });            
            modelBuilder.Entity<SimSkills>().HasKey(m => new { m.SimID, m.SkillID });
            modelBuilder.Entity<QuestRequiresSkill>().HasKey(m => new { m.SkillID, m.QuestID });


            modelBuilder.Entity<ActivityRequiresSkill>().Property(a => a.ActivityID).ValueGeneratedNever();
            modelBuilder.Entity<ActivityRequiresSkill>().Property(a => a.SkillID).ValueGeneratedNever();

            

            
        }
    }
}
