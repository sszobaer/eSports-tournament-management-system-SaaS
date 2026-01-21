using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.Match
{
    public class PlayerStatDTO
    {
        [Required]
        public int PlayerId { get; set; }

        [Required]
        public int Kills { get; set; }
    }
}
