using BLL.DTOs;

namespace BLL.DTOs.Match
{
    public class PlayerStatGetDTO : BaseDTO
    {
        public int PlayerId { get; set; }
        public int Kills { get; set; }
        public int KillPoints { get; set; }
    }
}
