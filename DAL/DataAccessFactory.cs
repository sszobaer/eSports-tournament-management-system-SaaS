using DAL.Entities.Context;
using DAL.Entities.Models;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DataAccessFactory
    {
        UMSContext db;
        public DataAccessFactory(UMSContext db)
        {
            this.db = db;
        }
        public IRole RoleData()
        {
            return new RoleRepo(db);
        }

        public IBase <Game,int,bool> GameData()
        {
            return new GameRepo(db);

        }

        public IBase<Team, int, bool> TeamData()
        {
            return new TeamRepo(db);
        }
        public IPlayer PlayerData()
        {
            return new PlayerRepo(db);
        }
      
    }
}
