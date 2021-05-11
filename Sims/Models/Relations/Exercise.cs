using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sims.Models.Relations
{
    public class Exercise
    {
        [Key]
        public Guid SimID { get; set; }
        [ForeignKey("SimID")]
        public Sim Sim { get; set; }

        public Guid ProfessionID { get; set; }
        [ForeignKey("ProfessionID")]
        public Profession Profession { get; set; }

        [Range(1,10)]
        public int Level { get; set; }
    }
}
