using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities.Models
{
    public class StageGroupTeam : BaseEntity
    {
        [Required]
        public Guid StageGroupId { get; set; }
        public StageGroup StageGroup { get; set; }

        [Required]
        public Guid TeamId { get; set; }
        public Team Team { get; set; }

        [Required]
        public int TotalPoints { get; set; }

        public int Rank { get; set; }

        [Required]
        public bool IsQualified { get; set; }
    }

}
