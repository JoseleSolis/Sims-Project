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
        public IQueryable<ActivityRequiresSkill> ActivityRequiresSkillsTable => context.ActivityRequiresSkillsTable;

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
        public void SaveActivityRequiresSkill(ActivityRequiresSkill activityRequiresSkill)
        {
            context.ActivityRequiresSkillsTable.Add(activityRequiresSkill);
            context.SaveChanges();
        }
    }   
}