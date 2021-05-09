using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sims.Models.Relations
{
    public class ActivityRequiresSkill
    {
        [Key, Column(Order = 0)]
        public Guid SkillID { get; set; }
        [ForeignKey("SkillID")]
        public Skill Skill { get; set; }

        [Key, Column(Order = 1)]
        public Guid ActivityID { get; set; }
        [ForeignKey("ActivityID")]
        public Activity Activity { get; set; }
        public int RequiredPoints { get; set; }
    }
}
