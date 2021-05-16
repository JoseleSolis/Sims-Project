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
        [Key, Column(Order = 0)]
        public Guid NeighborhoodID { get; set; }
        [ForeignKey("NeighborhoodID")]
        public Neighborhood Neighborhood { get; set; }

        [Key, Column(Order = 1)]
        public Guid SkillID { get; set; }
        [ForeignKey("SkillID")]

        public Skill Skill { get; set; }
    }
}
