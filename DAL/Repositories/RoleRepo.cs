using DAL.Entities.Context;
using DAL.Entities.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class RoleRepo
        : BaseRepo<Role, int>, IRole
    {
        public RoleRepo(ETMSContext context) : base(context) { }

        public override async Task<bool> Create(Role entity)
        {
            if (await _context.Roles.AnyAsync(r => r.Name == entity.Name))
                return false;

            return await base.Create(entity);
        }
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
