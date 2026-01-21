using DAL.Entities.Context;
using DAL.Entities.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class OrganizationUserRepo : BaseRepo<OrganizationUser, int>, IOrgUser
    {
        public OrganizationUserRepo(ETMSContext context) : base(context)
        {

        }

        public async Task<bool> ExistsByEmailInOrg(string email, int orgId)
        {
            return await _context.OrganizationUsers.AnyAsync(ou =>
                    ou.OrganizationId == orgId &&
                    ou.User.Email == email);
        }


}
}
