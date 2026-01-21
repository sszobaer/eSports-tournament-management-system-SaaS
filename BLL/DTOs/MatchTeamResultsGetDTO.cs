using BLL.DTOs;
using System.Collections.Generic;

namespace BLL.DTOs.Match
{
    public class MatchTeamResultGetDTO : BaseDTO
    {
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public int Placement { get; set; }
        public int PlacementPoints { get; set; }
        public int KillPoints { get; set; }
        public int TotalPoints { get; set; }

        public List<PlayerStatGetDTO> Players { get; set; }
    }
}
