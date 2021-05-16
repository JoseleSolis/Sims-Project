using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sims.Models.ViewModels
{
    public class ProfessionImprovesSkillViewModel
    {
        public Profession Profession { get; set; }
        public Guid SkillID { get; set; }
        public string CurrentImprovedSkill { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
    }
}
