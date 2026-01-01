using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace DAL.Entities.Models
{
    public class StageGroup : BaseEntity
    {
        [Required]
        public Guid StageId { get; set; }
        public TournamentStage Stage { get; set; }

        [Required, MaxLength(10)]
        public string GroupName { get; set; }   // A, B, C

        [Required]
        public int MaxTeams { get; set; }

        [Required]
        public int QualifyCount { get; set; }

        public ICollection<StageGroupTeam> Teams { get; set; }
        public ICollection<Match> Matches { get; set; }
    }

}
