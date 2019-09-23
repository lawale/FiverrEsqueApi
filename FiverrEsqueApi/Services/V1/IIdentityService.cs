using FiverrEsqueApi.Models.Data.Dto.V1.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiverrEsqueApi.Services.V1
{
    public interface IIdentityService
    {
        Task<AuthResponse> LoginAsync(string email, string password);

        Task<AuthResponse> RegisterAsync(string email, string password);

        Task<AuthResponse> ResetPasswordAsync(string email, string token, string password);

        Task<string> GeneratePasswordResetTokenAsync(string email);

        Task<string> GenerateEmailConfirmationTokenAsync(string email);

        Task<AuthResponse> ConfirmEmailAsync(string email, string token);

        Task<AuthResponse> ChangePasswordAsync(HttpContext context, string newPassword, string oldPassword);

        Task<AuthResponse> RefreshTokenAsync(string email, string password);
    }
}
