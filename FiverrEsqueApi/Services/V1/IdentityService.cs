using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiverrEsqueApi.Extensions;
using FiverrEsqueApi.Models.Data.DataContext;
using FiverrEsqueApi.Models.Data.Dto.V1.Responses;
using FiverrEsqueApi.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace FiverrEsqueApi.Services.V1
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<AppUser> UserManager;

        private readonly ApplicationDbContext Context;

        public IdentityService(UserManager<AppUser> userManager, ApplicationDbContext context)
        {
            UserManager = userManager;
            Context = context;
        }

        public async Task<AuthResponse> ChangePasswordAsync(HttpContext context, string newPassword, string oldPassword)
        {
            var user = await context.AppUserFromContextAsync(UserManager);
            if (user == null)
                return new AuthResponse
                {
                    IsSuccess = false,
                    Errors = new[] { "User does not exist" }
                };
            var identityResult = await UserManager.ChangePasswordAsync(user, oldPassword, newPassword);
            return IdentityResultToAuthResponse(identityResult);
        }

        public async Task<AuthResponse> ConfirmEmailAsync(string email, string token)
        {
            var user = new AppUser { Email = email };
            var identityResult = await UserManager.ConfirmEmailAsync(user, token);
            return IdentityResultToAuthResponse(identityResult);
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(string email)
        {
            var user = await UserManager.FindByEmailAsync(email);
            if (user == null)
                return null;
            return await UserManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(string email)
        {
            var user = await UserManager.FindByEmailAsync(email);
            if (user == null)
                return null;
            return await UserManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<AuthResponse> LoginAsync(string email, string password)
        {
            var user = await UserManager.FindByEmailAsync(email);
            if (user == null)
                return new AuthResponse
                {
                    IsSuccess = false,
                    Errors = new[] { "Invalid User Details" }
                };

            var isPasswordValid = await UserManager.CheckPasswordAsync(user, password);

            if(!isPasswordValid)
                return new AuthResponse
                {
                    IsSuccess = false,
                    Errors = new[] { "Invalid User Details" }
                };

            return new AuthResponse
            {
                IsSuccess = true,
                Token = string.Empty,
                RefreshToken = string.Empty
            };
        }

        public Task<AuthResponse> RefreshTokenAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthResponse> RegisterAsync(string email, string password)
        {
            var user = await UserManager.FindByEmailAsync(email);

            if(user != null)
                return new AuthResponse
                {
                    IsSuccess = false,
                    Errors = new[] { "Email Address already exists" }
                };

            user = new AppUser { Email = email };
            var identityResult = await UserManager.CreateAsync(user, password);

            return IdentityResultToAuthResponse(identityResult);
        }

        public async Task<AuthResponse> ResetPasswordAsync(string email, string token, string password)
        {
            var user = new AppUser { Email = email };
            var identityResult = await UserManager.ResetPasswordAsync(user, token, password);
            return IdentityResultToAuthResponse(identityResult);
        }

        private AuthResponse IdentityResultToAuthResponse(IdentityResult identityResult)
        {
            if (!identityResult.Succeeded)
                return new AuthResponse
                {
                    IsSuccess = false,
                    Errors = identityResult.Errors.Select(x => x.Description).ToArray()
                };
            return new AuthResponse
            {
                IsSuccess = true,
                Token = string.Empty,
                RefreshToken = string.Empty
            };
        }
    }
}
