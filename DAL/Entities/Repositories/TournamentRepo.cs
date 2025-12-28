using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities.Repositories
{
    public class TournamentRepo
    {
        public List<Tournament> GetAll()
        {
            var list = new List<Tournament>();
            for (int i= 1; i <= 10; i++)
            {
                list.Add(new Tournament
                {
                    tournamentId = i,
                    tournamentName = $"Tournament {i}",
                    tournamentDescription = $"Description for Tournament {i}",
                    tournamentStartDate = DateTime.Now.AddDays(i),
                    tournamentEndDate = DateTime.Now.AddDays(i + 5)
                });
            }
            return list;
        }
    }
}
