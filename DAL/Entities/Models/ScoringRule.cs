using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities.Models
{
    public class ScoringRule : BaseEntity
    {
        [Required]
        public Guid GameId { get; set; }
        public Game Game { get; set; }

        [Required]
        public int Placement { get; set; }

        [Required]
        public int PlacementPoints { get; set; }

        [Required]
        public int KillPointValue { get; set; }
    }

}
