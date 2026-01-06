using DAL.Entities.Context;
using DAL.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class TeamRepo : BaseRepo<Team,int>
    {
        UMSContext context;
        public TeamRepo(UMSContext context) : base(context)
        {

        }

    }
}
