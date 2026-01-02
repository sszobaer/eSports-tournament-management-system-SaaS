using DAL.Entities.Context;
using DAL.Entities.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    internal class RoleRepo
        : BaseRepo<Role, int>, IRole
    {
        public RoleRepo(UMSContext context) : base(context) { }

        public async Task<Role> GetByName(string roleName)
        {
            var data = await _context.Roles
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(r => r.Name == roleName);
            if (data == null) throw new KeyNotFoundException($"Role with name '{roleName}' not found.");
            
            return data;
        }
    }
}
