using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Sims.Models.Relations;

namespace Sims.Models.ViewModels
{
    public class SimQuestViewModel
    {
        public Travel Travel { get; set; }
        [Display(Name = "Quest")]
        public Guid QuestID { get; set; }
        public IEnumerable<Quest> Quests { get; set; }

    }
}
