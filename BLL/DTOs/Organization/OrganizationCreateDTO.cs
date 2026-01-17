using DAL.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs.Organization
{
    public class OrganizationCreateDTO : BaseDTO
    {
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
