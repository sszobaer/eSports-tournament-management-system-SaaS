using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities.Models
{
    public class QualificationMap : BaseEntity
    {
        [Required]
        public Guid FromStageGroupId { get; set; }

        [Required]
        public Guid ToStageGroupId { get; set; }

        [Required]
        public Guid TeamId { get; set; }
        public Team Team { get; set; }

        [Required]
        public int SeedNumber { get; set; }

        [Required]
        public DateTime QualifiedAt { get; set; }
    }

}
