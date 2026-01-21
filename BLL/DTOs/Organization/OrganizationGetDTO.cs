using BLL.DTOs.User;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs.Organization
{
    public class OrganizationGetDTO : BaseDTO
    {
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public bool IsActive { get; set; }
        public virtual List<UserGetDTO> Users { get; set; }
        public OrganizationGetDTO()
        {
            Users = new List<UserGetDTO>();
        }

    }
}
