using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities.Models
{
    public class MatchTeamResult : BaseEntity
    {
        [Required]
        public int MatchId { get; set; }
        public virtual Match Match { get; set; }

        [ForeignKey("Team")]
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }

        [Required]
        public int Placement { get; set; }

        [Required]
        public int PlacementPoints { get; set; }

        [Required]
        public int KillPoints { get; set; }

        [Required]
        public int TotalPoints { get; set; }

        public ICollection<MatchPlayerStat> PlayerStats { get; set; }
    }

}
