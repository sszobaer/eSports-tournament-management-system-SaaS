using BLL.DTOs.Organization;
using BLL.DTOs.User;
using BLL.Helper;
using DAL;
using DAL.Entities.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService
    {
        private readonly DataAccessFactory _factory;
        private readonly PasswordHasher<User> _passwordHasher;

        public AuthService(DataAccessFactory factory)
        {
            _factory = factory;
            _passwordHasher = new PasswordHasher<User>();
        }

        public async Task<UserGetDTO> Register(int orgId, UserRegisterDTO dto)
        {
            var existsInOrg = await _factory.OrgUserData()
                .ExistsByEmailInOrg(dto.Email, orgId);

            if (existsInOrg)
                throw new Exception("Email already registered in this organization");

 
            //var exists = await _factory.AuthData().GetByEmail(dto.Email);

            var user = MapperConfig.GetMapper().Map<User>(dto);
            user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);
            user.IsActive = true;
            user.IsEmailVerified = false;

            await _factory.AuthData().Create(user);

            var orgUser = new OrganizationUser
            {
                UserId = user.Id,
                OrganizationId = orgId,
                RoleId = dto.RoleId
            };

            await _factory.OrgUserData().Create(orgUser);
            await _factory.EmailData().SendAsync(
                    user.Email,
                    "Welcome to ETMS",
                    $@"
                        <h2>Welcome, {user.FullName}</h2>
                        <p>You have been successfully registered.</p>
                        <p><b>Organization ID:</b> {orgId}</p>
                    "
                );

            var createdUser = await _factory.AuthData().GetByEmail(user.Email);

            return new UserGetDTO
            {
                Id = createdUser.Id,
                FullName = createdUser.FullName,
                Email = createdUser.Email,
                Organizations = createdUser.Organizations.Select(ou => new OrganizationInfoDTO
                {
                    OrgId = ou.OrganizationId,
                    OrgName = ou.Organization.Name,
                    RoleName = ou.Role.Name
                }).ToList()
            };
        }


        public async Task<User> login(string email, string password)
        {
            var user = await _factory.AuthData().GetByEmail(email);
            if (user == null) return null;

            var result = new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, password);

            if (result == PasswordVerificationResult.Success)
                return user;

            return null;
        }
    }
}
