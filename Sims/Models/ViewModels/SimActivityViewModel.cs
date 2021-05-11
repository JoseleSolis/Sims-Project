using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sims.Models.ViewModels
{
    public class SimActivityViewModel
    {
        public Sim Sim { get; set; }
        [Display(Name ="Activity")]
        public Guid ActivityID { get; set; }
        public IEnumerable<Activity> Activities { get; set; }
    }
}
