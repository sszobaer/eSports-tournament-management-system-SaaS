using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.Match
{
    public class MatchCreateDTO
    {
        [Required]
        public int StageGroupId { get; set; }

        [Required]
        public int MatchNumber { get; set; }

        [Required]
        public string MapName { get; set; }
    }
}
