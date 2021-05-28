using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sims.Models.ViewModels
{
    public class NeighborhoodImprovesSkillViewModel
    {
        public Neighborhood Neighborhood { get; set; }
        [Display(Name ="Skill")]
        public Guid SkillID { get; set; }
        public string CurrentImprovedSkill { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
    }
}
