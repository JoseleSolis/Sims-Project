using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sims.Models.ViewModels
{
    public class SimProfileViewModel
    {
        public Sim Sim { get; set; }
        public Profession Profession { get; set; }
        public DomesticUnit DomesticUnit { get; set; }
    }
}
