using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.Match
{
    public class MatchUpdateDTO
    {
        [Required]
        public string MapName { get; set; }
    }
}
