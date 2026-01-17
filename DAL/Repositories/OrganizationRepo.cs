using DAL.Entities.Context;
using DAL.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class OrganizationRepo
        :BaseRepo<Organization, int>
    {
        public OrganizationRepo(ETMSContext context) 
            :base(context)
        { }
    }
}
