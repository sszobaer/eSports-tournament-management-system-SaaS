using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs.User
{
    public class UserCreateDTO : BaseDTO
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; } = true;

        public List<int> RoleIds { get; set; }

        public List<int> OrganizationIds { get; set; }
    }
}
