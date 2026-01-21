using DAL.Entities.Context;
using DAL.Entities.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class AuthRepo : BaseRepo<User, int>, IAuth
    {
        public AuthRepo(ETMSContext context) : base(context)
        {
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Set<User>()
                .Include(u => u.Organizations)
                .ThenInclude(ou => ou.Organization)
                 .Include(u => u.Organizations)
                 .ThenInclude(ou => ou.Role)
                 .Include(u => u.UserRoles)
                 .ThenInclude(ur => ur.Role)
                 .FirstOrDefaultAsync(u => u.Email == email);
        }

    }
}
