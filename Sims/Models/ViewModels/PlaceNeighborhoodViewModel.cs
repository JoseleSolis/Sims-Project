using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Sims.Models.ViewModels
{
    public class PlaceNeighborhoodViewModel
    {
        public Place Place { get; set; }
        [Display(Name ="Neighborhood")]
        public Guid NeighborhoodID { get; set; }
        public string CurrentNeighborhoodName { get; set; }
        public IEnumerable<Neighborhood> Neighborhoods { get; set; }
    }
}
