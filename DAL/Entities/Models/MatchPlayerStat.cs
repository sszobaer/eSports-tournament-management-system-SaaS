using System.ComponentModel.DataAnnotations;

namespace DAL.Entities.Models
{
    public class MatchPlayerStat : BaseEntity
    {
        [Required]
        public Guid MatchTeamResultId { get; set; }
        public MatchTeamResult MatchTeamResult { get; set; }

        [Required]
        public Guid PlayerId { get; set; }
        public Player Player { get; set; }

        [Required]
        public int Kills { get; set; }

        [Required]
        public int KillPoints { get; set; }
    }

}