using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text;

namespace DAL.Entities.Models
{
    public class Team : BaseEntity
    {
        [Required]
        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }

        [Required]
        public Guid GameId { get; set; }
        public Game Game { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string LogoUrl { get; set; }

        public ICollection<Player> Players { get; set; }
    }

}
