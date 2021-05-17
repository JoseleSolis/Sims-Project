using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sims.Models.Relations
{
    public class QuestWorld
    {
        public Guid WorldID { get; set; }
        [ForeignKey("WorldID")]
        public World World { get; set; }

        [Key]
        public Guid QuestID { get; set; }
        [ForeignKey("QuestID")]
        public Quest Quest { get; set; }
    }
}
