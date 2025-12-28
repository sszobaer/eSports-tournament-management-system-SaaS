using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF.Models
{
    public class Tournament
    {
        public int tournamentId { get; set; }
        public string tournamentName { get; set; }
        public string tournamentDescription { get; set; }
        public DateTime tournamentStartDate { get; set; }
        public DateTime tournamentEndDate { get; set; }

    }
}
