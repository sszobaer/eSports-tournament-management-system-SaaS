using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities.Models
{
    public class MatchTeamResult : BaseEntity
    {
        [Required]
        public Guid MatchId { get; set; }
        public Match Match { get; set; }

        [Required]
        public Guid TeamId { get; set; }
        public Team Team { get; set; }

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
