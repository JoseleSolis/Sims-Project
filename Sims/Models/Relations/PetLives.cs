using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sims.Models.Relations
{
    public class PetLives
    {
        [Key]
        public Guid PetID { get; set; }
        [ForeignKey("PetID")]
        public Pet Pet { get; set; }

        
        public Guid DomesticUnitID { get; set; }
        [ForeignKey("DomesticUnitID")]
        public DomesticUnit DomesticUnit { get; set; }
    }
}
