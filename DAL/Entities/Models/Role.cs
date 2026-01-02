using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities.Models
{
    public class Role : BaseEntity
    {
        [Required, MaxLength(25)]
        public string Name { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
