using DAL.Entities.Context;
using DAL.Entities.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class PlayerRepo:BaseRepo<Player,int>,IPlayer
    {
        public PlayerRepo(UMSContext context) : base(context)
        {
        }

        public async Task<int> CountByPerTeam(int teamId)
        {
            return await _context.Players.CountAsync(p => p.TeamId == teamId && !p.IsDeleted);
        }
    }
}
