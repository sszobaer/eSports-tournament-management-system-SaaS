using BLL.DTOs;
using BLL.Helper;
using DAL;
using DAL.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class TeamService
    {
        DataAccessFactory factory;

        public TeamService(DataAccessFactory factory)
        {
            this.factory = factory;
        }

        public async Task<bool> Create(TeamDTO team)
        {
            Team data=MapperConfig.GetMapper().Map<Team>(team);
            return await factory.TeamData().Create(data);
        }

        public async Task<bool> Update(TeamDTO team,int id)
        {
            Team data = MapperConfig.GetMapper().Map<Team>(team);
            return await factory.TeamData().Update(data, id);
        }

        public async Task<bool> Delete (int id)
        {
            return await factory.TeamData().Delete(id);
        }
        public async Task<TeamDTO> GetById(int id)
        {
            var data = await factory.TeamData().Get(id);
            return MapperConfig.GetMapper().Map<TeamDTO>(data);
        }
        public async Task<List<TeamDTO>> GetAll()
        {
            var data = await factory.TeamData().GetAll();
            return MapperConfig.GetMapper().Map<List<TeamDTO>>(data);

        }
    }
}
