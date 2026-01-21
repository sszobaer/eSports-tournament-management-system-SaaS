using BLL.DTOs.Organization;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs.User
{
    public class UserGetDTO: BaseDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<OrganizationInfoDTO> Organizations { get; set; }
    }
}
