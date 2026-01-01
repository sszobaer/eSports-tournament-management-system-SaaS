using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities.Models
{
    public class OrganizationUser : BaseEntity
    {
        [Required]
        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; }

        [Required]
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }

}
