using DAL.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IMatch : IBase<Match, int, bool>
    {
        Task<int> GetTeamCountAsync(int matchId);
        Task<int> GetSubmittedResultCountAsync(int matchId);
    }
}
