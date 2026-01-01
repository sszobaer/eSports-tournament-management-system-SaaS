using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities.Models
{
    public class Player : BaseEntity
    {
        [Required]
        public Guid TeamId { get; set; }
        public Team Team { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string InGameName { get; set; }
    }

}
