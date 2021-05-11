using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Sims.Models.Relations
{
    public class Travel
    {
        [Key, Column(Order = 0)]
        public DateTime Date { get; set; }

        [Key, Column(Order = 1)]
        public Guid SimID { get; set; }
        [ForeignKey("SimID")]
        public Sim Sim { get; set; }

        [Key, Column(Order = 2)]
        public Guid WorldID { get; set; }
        [ForeignKey("WorldID")]
        public World World { get; set; }
    }
}
