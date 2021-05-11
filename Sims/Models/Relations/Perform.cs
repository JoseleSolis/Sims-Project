using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sims.Models.Relations
{
    public class Perform
    {
        [Key, Column(Order = 0)]
        public Guid SimID { get; set; }
        [ForeignKey("SimID")]
        public Sim Sim { get; set; }

        [Key, Column(Order = 1)]
        public Guid ActivityID { get; set; }
        [ForeignKey("ActivityID")]
        public Activity Activity { get; set; }

        public DateTime LastPerform { get; set; }

    }
}
