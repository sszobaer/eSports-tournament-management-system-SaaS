using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs.Organization
{
    public class OrganizationUpdateDTO
    {
        public string Name { get; set; }
        public IFormFile LogoUrl { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? UpdatedAt { get; set; }
    }
}
