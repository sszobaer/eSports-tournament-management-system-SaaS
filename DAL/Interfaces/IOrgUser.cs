using DAL.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IOrgUser: IBase<OrganizationUser, int, bool>
    {
        Task<bool> ExistsByEmailInOrg(string email, int orgId);
    }
}
