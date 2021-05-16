using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sims.Models.ViewModels
{
    public class ActivityImprovementViewModel
    {
        public Activity Activity { get; set; }
        [Display(Name = "Skill")]
        public Guid SkillID { get; set; }
        public string CurrentImprovedSkillName { get; set; }
        public IEnumerable<Skill> Skills { get; set; }

    }
}
