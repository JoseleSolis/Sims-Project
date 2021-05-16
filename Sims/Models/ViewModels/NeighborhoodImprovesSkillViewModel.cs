using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sims.Models.ViewModels
{
    public class NeighborhoodImprovesSkillViewModel
    {
        public Neighborhood Neighborhood { get; set; }
        public Guid SkillID { get; set; }
        public string CurrentImprovedSkill { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
    }
}
