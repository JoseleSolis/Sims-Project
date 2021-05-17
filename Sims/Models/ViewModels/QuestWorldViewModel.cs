using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sims.Models.ViewModels
{
    public class QuestWorldViewModel
    {
        public Quest Quest { get; set; }
        public Guid WorldID { get; set; }
        public string CurrentWorldName { get; set; }
        public IEnumerable<World> Worlds { get; set; }
    }
}
