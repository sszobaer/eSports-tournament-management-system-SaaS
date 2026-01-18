using DAL.Entities.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs.Organization
{
    public class OrganizationCreateDTO : BaseDTO
    {
        public string Name { get; set; }
        public IFormFile LogoUrl { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
