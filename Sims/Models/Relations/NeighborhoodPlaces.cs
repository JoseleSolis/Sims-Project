using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sims.Models.Relations
{
    public class NeighborhoodPlaces
    {
        
        public Guid NeighborhoodID { get; set; }
        [ForeignKey("NeighborhoodID")]
        public Neighborhood Neighborhood { get; set; }

        [Key]
        public Guid PlaceID { get; set; }
        [ForeignKey("PlaceID")]
        public Place Place { get; set; }
    }
}
