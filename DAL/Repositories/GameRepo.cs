using DAL.Entities.Context;
using DAL.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class GameRepo : BaseRepo<Game, int>
    {
        public GameRepo(UMSContext context) : base(context)
        {
        }
       
    }
}
