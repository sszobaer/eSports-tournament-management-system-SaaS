using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities.Models
{
    public class MatchPlayerStat : BaseEntity
    {
        [ForeignKey("MatchTeamResult")]
        public int MatchTeamResultId { get; set; }
        public virtual MatchTeamResult MatchTeamResult { get; set; }

        [ForeignKey("Player")]
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }

        [Required]
        public int Kills { get; set; }

        [Required]
        public int KillPoints { get; set; }
    }

}