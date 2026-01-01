using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities.Models
{
    public class Match : BaseEntity
    {
        [Required]
        public Guid StageGroupId { get; set; }
        public StageGroup StageGroup { get; set; }

        [Required]
        public int MatchNumber { get; set; }

        [Required, MaxLength(50)]
        public string MapName { get; set; }

        [Required]
        public MatchStatus Status { get; set; }

        public ICollection<MatchTeamResult> TeamResults { get; set; }
    }

}
