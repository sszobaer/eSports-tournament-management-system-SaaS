using DAL.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IPlayer:IBase<Player,int,bool>
    {
        Task<int> CountByPerTeam(int teamId);

    }
}
