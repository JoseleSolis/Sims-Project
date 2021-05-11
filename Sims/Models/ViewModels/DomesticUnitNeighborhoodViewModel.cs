using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sims.Models.ViewModels
{
    public class DomesticUnitNeighborhoodViewModel
    {
        public DomesticUnit DomesticUnit { get; set; }
        public Guid NeighborhoodID { get; set; }
        public string CurrentNeighborhoodName { get; set; }
        public IEnumerable<Neighborhood> Neighborhoods { get; set; }
    }
}
