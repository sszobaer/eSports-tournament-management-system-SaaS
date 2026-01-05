using BLL.DTOs;
using BLL.Helper;
using DAL;
using DAL.Entities.Models;
using DAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class GameService
    {

        DataAccessFactory factory;
        public GameService(DataAccessFactory factory)
        {
            this.factory = factory;
        }

        public async Task<bool> Create(GameDTO game)
        {
            
            Game data=MapperConfig.GetMapper().Map<Game>(game);
            return await factory.GameData().Create(data);

        }

        public async Task<bool> Delete (int id)
        {
            return await factory.GameData().Delete(id);

        }

        public async Task<bool> Update(GameDTO game, int id)
        {
            Game data = MapperConfig.GetMapper().Map<Game>(game);
            return await factory.GameData().Update(data, id);
        }

        public async Task <List<GameDTO>> GetAll()
        {
                       var data = await factory.GameData().GetAll();
            return MapperConfig.GetMapper().Map<List<GameDTO>>(data);

        }

        public async Task<GameDTO>GetById(int id)
        {
            var data = await factory.GameData().Get(id);
            return MapperConfig.GetMapper().Map<GameDTO>(data);
        }





    }
}
