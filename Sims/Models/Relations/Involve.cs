using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sims.Models.Relations
{
    public class Involve
    {
        [Key,Column(Order = 0)]
        public Guid QuestID { get; set; }
        [ForeignKey("QuestID")]
        public Quest Quest { get; set; }

        [Key, Column(Order = 1)]
        public Guid SimID { get; set; }
        [Key, Column(Order = 2)]
        public Guid WorldID { get; set; }
        [Key, Column(Order = 3)]
        public DateTime Date { get; set; }
        
        [ForeignKey("SimID,WorldID,Date")]
        public Travel Travel { get; set; }

    }
}
