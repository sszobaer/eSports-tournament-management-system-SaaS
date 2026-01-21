using BLL.DTOs;
using BLL.Helper;
using DAL;
using DAL.Entities.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class RoleService
    {
        DataAccessFactory factory;
        public RoleService(DataAccessFactory factory) 
        {
            this.factory = factory;
        }

        public async Task<bool> Create(RoleDTO role)
        {
            Role data = MapperConfig.GetMapper().Map<Role>(role);
            return await factory.RoleData().Create(data);
        }

        public async Task<List<RoleDTO>> GetAll()
        {
            var data = await factory.RoleData().GetAll();
            return MapperConfig.GetMapper().Map<List<RoleDTO>>(data);
        }

        public async Task<bool> Delete(int id)
        {
            return await factory.RoleData().Delete(id);
        }

        public async Task<bool> Update(RoleDTO role, int id)
        {
            var entity = await factory.RoleData().Get(id);
            if (entity == null) return false;

            MapperConfig.GetMapper().Map(role, entity); 

            entity.UpdatedAt = DateTime.UtcNow;

            return await factory.SaveAsync() > 0;
        }



        public async Task<RoleDTO> GetById(int id)
        {
            var data = await factory.RoleData().Get(id);
            return MapperConfig.GetMapper().Map<RoleDTO>(data);
        }

        public async Task<RoleDTO> GetByName(string name)
        {
            var data = await factory.RoleData().GetByName(name);
            return MapperConfig.GetMapper().Map<RoleDTO>(data);
        }
    }
}
