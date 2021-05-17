using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Sims.Models.ViewModels
{
    public class SimSearchFilterForm
    {
        public Sim Sim { get; set; }
        [Display(Name = "Profession")]
        public Guid ProfessionID { get; set; }
        public IEnumerable<Profession> Professions { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a positive value")]
        [Display(Name = "Show Firsts")]
        public int FirstHowMany { get; set; }
        [Display(Name = "Order by Skill")]
        public Guid SkillID { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
        [Display(Name = "Neighborhood")]
        public Guid NeighborhoodID { get; set; }
        public IEnumerable<Neighborhood> Neighborhoods { get; set; }
        [Display(Name = "Pet Owner")]
        public string PetOwner { get; set; }


    }
}
