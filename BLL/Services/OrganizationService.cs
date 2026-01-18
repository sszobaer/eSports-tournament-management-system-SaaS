using BLL.DTOs.Organization;
using BLL.Helper;
using DAL;
using DAL.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class OrganizationService
    {
        DataAccessFactory _factory;
        public OrganizationService(DataAccessFactory factory)
        {
            _factory = factory;
        }

        public async Task<Organization> Create(OrganizationCreateDTO dto)
        {
            string logoUrl = null;

            if (dto.LogoUrl != null)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(dto.LogoUrl.FileName)}";
                var path = Path.Combine("D:/eSports-tournament-management-system-SaaS/ApplicationLayer/wwwroot/uploads/org-logos", fileName);

                using var stream = new FileStream(path, FileMode.Create);
                await dto.LogoUrl.CopyToAsync(stream);

                logoUrl = $"/uploads/org-logos/{fileName}";
            }

            var org = new Organization
            {
                Name = dto.Name,
                LogoUrl = logoUrl,
                IsActive = dto.IsActive
            };

            await _factory.OrgData().Create(org);

            return org;
        }


    }
}
