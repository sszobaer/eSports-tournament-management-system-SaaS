using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Text;

namespace DAL.Entities.Models
{
    public class ScoringRule : BaseEntity
    {
        //
        [ForeignKey("Game")]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        public int? Placement { get; set; } 
        public int? PlacementPoints { get; set; }
        public int? KillPointValue { get; set; }
    }

}
