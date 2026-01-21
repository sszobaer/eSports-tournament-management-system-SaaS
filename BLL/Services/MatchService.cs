using BLL.DTOs.Match;
using DAL;
using DAL.Entities.Models;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class MatchService
    {
        private readonly DataAccessFactory _factory;

        public MatchService(DataAccessFactory factory)
        {
            _factory = factory;
        }

        public async Task<bool> Create(MatchCreateDTO dto)
        {
            var match = new Match
            {
                StageGroupId = dto.StageGroupId,
                MatchNumber = dto.MatchNumber,
                MapName = dto.MapName,
                Status = MatchStatus.Pending,
            };

            return await _factory.MatchData().Create(match);
        }

        public async Task<List<Match>> GetAll()
        {
            return await _factory.MatchData().GetAll();
        }

        public async Task<Match> Get(int id)
        {
            return await _factory.MatchData().Get(id);
        }

        public async Task<bool> Update(int id, MatchUpdateDTO dto)
        {
            var match = await _factory.MatchData().Get(id);
            if (match == null) return false;

            match.MapName = dto.MapName;
            return await _factory.MatchData().Update(match, id);
        }

        public async Task<bool> Delete(int id)
        {
            return await _factory.MatchData().Delete(id);
        }

        private int GetPlacementPoints(int placement)
        {
            return placement switch
            {
                1 => 10,
                2 => 6,
                3 => 5,
                4 => 4,
                5 => 3,
                6 => 2, 
                7 => 1,
                8 => 1,
                _ => 0
            };
        }

        public async Task<bool> SubmitMatchResult(MatchResultSubmitDTO dto)
        {
            var existing = await _factory.MatchTeamResultData()
                .GetByMatchAndTeamAsync(dto.MatchId, dto.TeamId);

            if (existing != null)
                throw new Exception("Result already submitted for this team.");

            int killPoints = dto.Players.Sum(p => p.Kills);
            int placementPoints = GetPlacementPoints(dto.Placement); 

            
            var teamResult = new MatchTeamResult
            {
                MatchId = dto.MatchId,
                TeamId = dto.TeamId,
                Placement = dto.Placement,
                PlacementPoints = placementPoints,
                KillPoints = killPoints,
                TotalPoints = placementPoints + killPoints,
                PlayerStats = dto.Players.Select(p => new MatchPlayerStat
                {
                    PlayerId = p.PlayerId,
                    Kills = p.Kills,
                    KillPoints = p.Kills 
                }).ToList()
            };


            await _factory.MatchTeamResultData().Create(teamResult);

            teamResult = await _factory.MatchTeamResultData().GetWithPlayersAsync(teamResult.Id);

            try
            {
                await SendMatchResultEmail(teamResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Email sending failed: {ex.Message}");
            }

            var totalTeams = await _factory.MatchData().GetTeamCountAsync(dto.MatchId);
            var submitted = await _factory.MatchData().GetSubmittedResultCountAsync(dto.MatchId);

            if (submitted >= totalTeams)
            {
                var match = await _factory.MatchData().Get(dto.MatchId);
                match.Status = MatchStatus.Completed;
                await _factory.MatchData().Update(match, dto.MatchId);
            }

            return true;
        }

        private async Task SendMatchResultEmail(MatchTeamResult teamResult)
        {
            var match = await _factory.MatchData().Get(teamResult.MatchId);
            var teamName = teamResult.Team.Name;

            var sb = new StringBuilder();
            sb.Append($@"
            <h2>Match Result - Team: {teamName}</h2>
            <p><b>Match Number:</b> {match.MatchNumber}</p>
            <p><b>Map:</b> {match.MapName}</p>
            <table border='1' cellpadding='5' cellspacing='0'>
                <tr>
                    <th>Player Name</th>
                    <th>In-Game Name</th>
                    <th>Kills</th>
                    <th>Kill Points</th>
                </tr>
            ");

            foreach (var stat in teamResult.PlayerStats)
            {
                sb.Append($@"
                <tr>
                    <td>{stat.Player.Name}</td>
                    <td>{stat.Player.InGameName}</td>
                    <td>{stat.Kills}</td>
                    <td>{stat.KillPoints}</td>
                </tr>
                ");
            }

            sb.Append($@"
            </table>
            <p><b>Placement:</b> {teamResult.Placement}</p>
            <p><b>Placement Points:</b> {teamResult.PlacementPoints}</p>
            <p><b>Team Total Points:</b> {teamResult.TotalPoints}</p>
            ");

            foreach (var stat in teamResult.PlayerStats)
            {
                await _factory.EmailData().SendAsync(
                    stat.Player.PlayersEmail,
                    $"Match Result - {teamName} in {match.MapName}",
                    sb.ToString()
                );
            }
        }


    }
}
