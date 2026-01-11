using BLL.DTOs;
using BLL.Helper;
using DAL;
using DAL.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class PlayerService
    {
        DataAccessFactory factory;
        public PlayerService(DataAccessFactory factory) {

            this.factory = factory;

        }
        public async Task<ServiceResponse<PlayerDTO>>Create(PlayerDTO player)
        {
            Team team=await factory.TeamData().Get(player.TeamId);

            if (team == null)
            {
                return ServiceResponse<PlayerDTO>.FailureResponse("Team not found") ;
            }

            Game game=await factory.GameData().Get(team.GameId);
            if (game == null) {
               return ServiceResponse<PlayerDTO>.FailureResponse( "Game not found");
            }

            var currentTotalPlayers=await factory.PlayerData().CountByPerTeam(player.TeamId);
            if (currentTotalPlayers >= game.TeamSize)
            {
                return ServiceResponse<PlayerDTO>.FailureResponse("Team has already reached maximum size");
            }
            Player data=MapperConfig.GetMapper().Map<Player>(player);
            var created=await factory.PlayerData().Create(data);
            if (!created) {
                return ServiceResponse<PlayerDTO>.FailureResponse("Failed to create player");
            }
            
            


            return ServiceResponse<PlayerDTO>.SuccessResponse(player, "Player created successfully");





        }
    }
}
