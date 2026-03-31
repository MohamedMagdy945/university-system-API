using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using UniversitySystem.Application.Common.Models;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniverstySystem.Infrastructure.Service
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _claimsFactory;

        public IdentityService(
            UserManager<ApplicationUser> userManager,
            IAuthorizationService authorizationService,
            IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory)
        {
            _userManager = userManager;
            _authorizationService = authorizationService;
            _claimsFactory = claimsFactory;
        }

        public async Task<string?> GetUserNameAsync(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            return user?.UserName;
        }

        public async Task<AuthResult> CreateUserAsync(string userName, string password)
        {
            var user = new ApplicationUser
            {
                UserName = userName,
                Email = userName
            };

            var result = await _userManager.CreateAsync(user, password);

            return new AuthResult
            {
                Succeeded = result.Succeeded,
                UserId = result.Succeeded ? user.Id.ToString() : null,
                Errors = result.Errors.Select(e => e.Description).ToList()
            };
        }
        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
                return false;

            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }


        public async Task<bool> IsInRoleAsync(int userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
                return false;

            return await _userManager.IsInRoleAsync(user, role);
        }

        public async Task<bool> AuthorizeAsync(int userId, string policyName)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
                return false;

            ClaimsPrincipal principal = await _claimsFactory.CreateAsync(user);
            var result = await _authorizationService.AuthorizeAsync(principal, resource: null, policyName);
            return result.Succeeded;
        }

    }
}
