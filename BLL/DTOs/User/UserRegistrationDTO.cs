using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.User
{
    public class UserRegisterDTO
    {
        [Required, MaxLength(150)]
        public string FullName { get; set; }

        [Required, EmailAddress, MaxLength(150)]
        public string Email { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }

        [Required]
        public int RoleId { get; set; }
    }
}
