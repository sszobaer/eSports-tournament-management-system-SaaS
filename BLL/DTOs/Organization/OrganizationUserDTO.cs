using BLL.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs.Organization
{
    public class OrganizationUserDTO
    {
        public virtual List<UserGetDTO> Users { get; set; }

        public OrganizationUserDTO()
        {
            Users = new List<UserGetDTO>();
        }
    }
}
