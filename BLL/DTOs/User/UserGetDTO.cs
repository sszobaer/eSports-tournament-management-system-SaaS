using BLL.DTOs.Organization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs.User
{
    public class UserGetDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool IsActive { get; set; }

        public List<string> Roles { get; set; }

        public List<OrganizationCreateDTO> Organizations { get; set; }
    }
}
