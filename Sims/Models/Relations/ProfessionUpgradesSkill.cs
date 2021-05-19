using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sims.Models.Relations
{
    public class ProfessionUpgradesSkill
    {
        [Key]
        public Guid ProfessionID { get; set; }
        [ForeignKey("ProfessionID")]
        public Profession Profession { get; set; }

        
        public Guid SkillID { get; set; }
        [ForeignKey("SkillID")]

        public Skill Skill { get; set; }
    }
}
