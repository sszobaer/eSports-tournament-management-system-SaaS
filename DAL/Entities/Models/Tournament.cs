using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities.Models
{
    public class Tournament : BaseEntity
    {
        [ForeignKey("Game")]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }

        [ForeignKey("Organization")]
        public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public TournamentStatus Status { get; set; }

        public ICollection<TournamentStage> Stages { get; set; }
    }

}
