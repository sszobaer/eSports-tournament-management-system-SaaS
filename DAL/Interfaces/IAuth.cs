using DAL.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IAuth : IBase<User, int, bool>
    {
        Task<User> GetByEmail(string email);
    }
}
