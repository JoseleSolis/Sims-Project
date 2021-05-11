using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Sims.Models.ViewModels
{
    public class ActivityRequirementsViewModel
    {
        public Activity Activity { get; set; }
        public List<Skill> Skills { get; set; }
        public List<int> RequiredPoints { get; set; }

    }
}
