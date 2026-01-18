using DAL.Entities.Context;
using DAL.Entities.Models;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DataAccessFactory
    {
        ETMSContext db;
        public DataAccessFactory(ETMSContext db)
        {
            this.db = db;
        }

        public IBase<Organization, int, bool> OrgData()
        {
            return new OrganizationRepo(db);
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
        public async Task<int> SaveAsync()
        {
            return await db.SaveChangesAsync();
        }
    }
}
