using DAL.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IRole : IBase<Role, int, bool>
    {
        Task<Role> GetByName(string name);
        //Task<bool> AssignRoleToUser(int userId, int roleId);
        //Task<bool> RemoveRoleFromUser(int userId, int roleId);
    }
}
