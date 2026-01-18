using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities.Models
{
    public class User : BaseEntity
    {
        [Required, MaxLength(150)]
        public string FullName { get; set; }

        [Required, EmailAddress, MaxLength(150)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public bool IsEmailVerified { get; set; } = false;

        [Required]
        public bool IsActive { get; set; } = true;

        public virtual List<UserRole> UserRoles { get; set; }
        public virtual List<OrganizationUser> Organizations { get; set; }
    }
}
