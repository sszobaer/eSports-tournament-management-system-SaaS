using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities.Models
{
    public class Tournament : BaseEntity
    {
        [Required]
        public Guid GameId { get; set; }
        public Game Game { get; set; }

        [Required]
        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public TournamentStatus Status { get; set; }

        public ICollection<TournamentStage> Stages { get; set; }
    }

}
