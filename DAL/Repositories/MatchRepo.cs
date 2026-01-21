using DAL.Entities.Context;
using DAL.Entities.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class MatchRepo : BaseRepo<Match, int>, IMatch
    {
        public MatchRepo(ETMSContext context) : base(context) { }

        public async Task<int> GetTeamCountAsync(int matchId)
        {
            return await _context.StageGroupTeams
                .CountAsync(x => x.StageGroup.Matches.Any(m => m.Id == matchId));
        }

        public async Task<int> GetSubmittedResultCountAsync(int matchId)
        {
            return await _context.MatchTeamResults
                .CountAsync(x => x.MatchId == matchId);
        }
    }
}
