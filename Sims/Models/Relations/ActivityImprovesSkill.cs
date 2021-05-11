using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sims.Models.Relations
{
    public class ActivityImprovesSkill
    {
        
        public Guid SkillID { get; set; }
        [ForeignKey("SkillID")]
        public Skill Skill { get; set; }

        [Key]
        public Guid ActivityID { get; set; }
        [ForeignKey("ActivityID")]
        public Activity Activity { get; set; }
    }
}
