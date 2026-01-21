using DAL.Entities.Context;
using DAL.Entities.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class MatchResultRepo : BaseRepo<MatchTeamResult, int>, IMatchResult
    {
        public MatchResultRepo(ETMSContext context) : base(context) { }

        public async Task<MatchTeamResult> GetByMatchAndTeamAsync(int matchId, int teamId)
        {
            return await _context.MatchTeamResults
                .Include(x => x.PlayerStats)
                .FirstOrDefaultAsync(x => x.MatchId == matchId && x.TeamId == teamId);
        }
        public async Task<MatchTeamResult> GetWithPlayersAsync(int teamResultId)
        {
            return await _context.MatchTeamResults
                .Include(mtr => mtr.PlayerStats)
                    .ThenInclude(ps => ps.Player)
                .Include(mtr => mtr.Team)
                .FirstOrDefaultAsync(mtr => mtr.Id == teamResultId);
        }
    }
}
