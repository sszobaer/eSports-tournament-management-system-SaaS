using BLL.DTOs.Match;
using System.ComponentModel.DataAnnotations;
namespace BLL.DTOs.Match
{
    public class MatchResultSubmitDTO
    {
        [Required]
        public int MatchId { get; set; }

        [Required]
        public int TeamId { get; set; }

        [Required]
        public int Placement { get; set; }

        [Required]
        public List<PlayerStatDTO> Players { get; set; }
    }
}