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
            var logoUrl = await FileUploadHelper.SaveOrganizationLogoAsync(
                dto.LogoUrl,
                "D:/eSports-tournament-management-system-SaaS/ApplicationLayer/wwwroot",
                "uploads/org-logos"
            );

            var org = new Organization
            {
                Name = dto.Name,
                LogoUrl = logoUrl,
                IsActive = dto.IsActive
            };

            await _factory.OrgData().Create(org);
            return org;
        }


        public async Task<List<OrganizationGetDTO>> GetAll()
        {
            var data = await _factory.OrgData().GetAll();
            return MapperConfig.GetMapper().Map<List<OrganizationGetDTO>>(data);
        }

        public async Task<OrganizationGetDTO> GetById(int id)
        {
            var data = await _factory.OrgData().Get(id);
            return MapperConfig.GetMapper().Map<OrganizationGetDTO>(data);
        }
        public async Task<bool> Delete(int id)
        {
            return await _factory.OrgData().Delete(id);
        }
        public async Task<bool> Update(int id, OrganizationUpdateDTO org)
        {
            var existingOrg = await _factory.OrgData().Get(id);
            if (existingOrg == null)
                return false;

            var newLogoUrl = await FileUploadHelper.SaveOrganizationLogoAsync(
                org.LogoUrl,
                "D:/eSports-tournament-management-system-SaaS/ApplicationLayer/wwwroot",
                "uploads/org-logos"
            );

            MapperConfig.GetMapper().Map(org, existingOrg);

            if (newLogoUrl != null)
                existingOrg.LogoUrl = newLogoUrl;

            existingOrg.UpdatedAt = DateTime.UtcNow;

            return await _factory.SaveAsync() > 0;
        }
    }
}
