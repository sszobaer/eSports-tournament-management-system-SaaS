using DAL.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IMatchResult : IBase<MatchTeamResult, int, bool>
    {
        Task<MatchTeamResult> GetByMatchAndTeamAsync(int matchId, int teamId);
        Task<MatchTeamResult> GetWithPlayersAsync(int teamResultId);
    }
}
