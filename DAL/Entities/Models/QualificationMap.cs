using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities.Models
{
    public class QualificationMap : BaseEntity
    {
        [Required]
        public int FromStageGroupId { get; set; }

        [Required]
        public int ToStageGroupId { get; set; }

        [ForeignKey("Team")]
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }

        [Required]
        public int SeedNumber { get; set; }

        [Required]
        public DateTime QualifiedAt { get; set; }
    }

}
