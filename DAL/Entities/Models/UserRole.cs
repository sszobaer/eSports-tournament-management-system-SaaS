using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;

namespace DAL.Entities.Models
{
    public class UserRole
    {
        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; }

        [Required]
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}
