using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities.Models
{
    public class StageGroupTeam : BaseEntity
    {
        [ForeignKey("StageGroup")]
        public int StageGroupId { get; set; }
        public virtual StageGroup StageGroup { get; set; }

        [ForeignKey("Team")]
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }

        [Required]
        public int TotalPoints { get; set; }

        public int Rank { get; set; }

        [Required]
        public bool IsQualified { get; set; } 
    }

}
