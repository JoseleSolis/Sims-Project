using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Sims.Models;

namespace Sims.Models.ViewModels
{
    public class DomesticUnitIndexViewModel
    {
        public DomesticUnit domesticUnit { get; set; }
        public Neighborhood neighborhood { get; set; }
    }
}
