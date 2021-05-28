using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Sims.Models.ViewModels
{
    public class SimSkillViewModel
    {
        public Sim Sim { get; set; }
        [Display(Name = "Skill Points")]
        public List<SkillPoints> SkillPoints { get; set; }
    }
}
