using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities.Models
{
    public class Game : BaseEntity
    {
        [Required, MaxLength(20)]
        public string GameCode { get; set; }   // PUBGM, VALORANT

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int TeamSize { get; set; }

        public ICollection<ScoringRule> ScoringRules { get; set; }
    }

}
