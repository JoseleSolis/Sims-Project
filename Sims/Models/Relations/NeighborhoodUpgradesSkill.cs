using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sims.Models.Relations
{
    public class NeighborhoodUpgradesSkill
    {
        [Key]
        public Guid NeighborhoodID { get; set; }
        [ForeignKey("NeighborhoodID")]
        public Neighborhood Neighborhood { get; set; }

        
        public Guid SkillID { get; set; }
        [ForeignKey("SkillID")]

        public Skill Skill { get; set; }
    }
}
