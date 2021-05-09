using System.Linq;
using Sims.Models.Relations;

namespace Sims.Models.Data
{
    public interface IRepository
    {
        IQueryable<Sim> Sims { get; }
        IQueryable<Activity> Activities { get; }
        IQueryable<Skill> Skills { get; }
        IQueryable<ActivityRequiresSkill> ActivityRequiresSkillsTable { get; }

        void SaveSim(Sim sim);
        void SaveActivity(Activity activity);
        void SaveSkill(Skill skill);

        void SaveActivityRequiresSkill(ActivityRequiresSkill activityRequiresSkill);
    }
}