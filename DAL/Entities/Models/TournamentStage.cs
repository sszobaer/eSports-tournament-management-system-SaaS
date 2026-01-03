using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities.Models
{
    public class TournamentStage : BaseEntity
    {
        [ForeignKey("Tournament")]
        public int TournamentId { get; set; }
        public virtual Tournament Tournament { get; set; }

        [Required, MaxLength(100)]
        public string StageName { get; set; }

        [Required]
        public int StageOrder { get; set; }

        [Required]
        public StageType StageType { get; set; }

        [Required]
        public int QualifiedTeamsPerGroup { get; set; }

        public ICollection<StageGroup> Groups { get; set; }
    }

}
