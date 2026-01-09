using DAL.Entities.Context;
using DAL.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class TeamRepo : BaseRepo<Team,int>
    {
        ETMSContext context;
        public TeamRepo(ETMSContext context) : base(context)
        {

        }

    }
}
