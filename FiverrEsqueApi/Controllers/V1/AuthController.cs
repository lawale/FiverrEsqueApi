using FiverrEsqueApi.Helpers.V1;
using FiverrEsqueApi.Models.Data.Dto.V1.Requests;
using FiverrEsqueApi.Models.Data.Dto.V1.Responses;
using FiverrEsqueApi.Models.Domain;
using FiverrEsqueApi.Services.V1;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FiverrEsqueApi.Controllers.V1
{
    [Route("api/v1/[controller]")]
    public class AuthController : Controller
    {
        private readonly IIdentityService IdentityService;
        public AuthController(IIdentityService identityService)
        {
            IdentityService = identityService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
                return InvalidModelStateAuthFailResponse();

            var response = await IdentityService.LoginAsync(request.Email, request.Password);
            if (!response.IsSuccess)
                return AuthFailResponse(response);
            return AuthSuccessResponse(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return InvalidModelStateAuthFailResponse();
            var response = await IdentityService.RegisterAsync(request.Email, request.Password);
            if (!response.IsSuccess)
                return AuthFailResponse(response);
            return AuthSuccessResponse(response);
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            var response = await IdentityService.ChangePasswordAsync(HttpContext, request.NewPassword, request.OldPassword);
            if (!response.IsSuccess)
                AuthFailResponse(response);
            return AuthSuccessResponse(response);
        }

        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailRequest request)
        {
            if (!ModelState.IsValid)
                return InvalidModelStateAuthFailResponse();
            var response = await IdentityService.ConfirmEmailAsync(request.Email, request.Token);
            if (!response.IsSuccess)
                return AuthFailResponse(response);
            return AuthSuccessResponse(response);
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            if (!ModelState.IsValid)
                return InvalidModelStateAuthFailResponse();
            var response = await IdentityService.ResetPasswordAsync(request.Email, request.Token, request.Password);
            if (!response.IsSuccess)
                return AuthFailResponse(response);
            return AuthSuccessResponse(response);
        }

        [HttpGet("password-reset-token/{email}")]
        public async Task<IActionResult> GeneratePasswordResetToken([FromQuery] string email)
        {
            if (string.IsNullOrEmpty(email))
                return BadRequest(new AuthFailResponse
                {
                    Status = Constants.AuthStatusFailed,
                    Errors = new[] { "Email is required" }
                });
            var response = await IdentityService.GeneratePasswordResetTokenAsync(email);
            if (response == null)
                return BadRequest(new AuthFailResponse
                {
                    Status = Constants.AuthStatusFailed,
                    Errors = new[] { "User does not exist." }
                });
            return Ok(new AuthSuccessResponse
            {
                Status = Constants.AuthStatusSuccess,
                Token = response
            });
        }

        [HttpGet("email-confirmation-token/{email}")]
        public async Task<IActionResult> GenerateEmailConfirmationToken([FromQuery] string email)
        {
            if (string.IsNullOrEmpty(email))
                return BadRequest(new AuthFailResponse
                {
                    Status = Constants.AuthStatusFailed,
                    Errors = new[] { "Email is required" }
                });
            var response = await IdentityService.GenerateEmailConfirmationTokenAsync(email);
            if (response == null)
                return BadRequest(new AuthFailResponse
                {
                    Status = Constants.AuthStatusFailed,
                    Errors = new[] { "User does not exist." }
                });
            return Ok(new AuthSuccessResponse
            {
                Status = Constants.AuthStatusSuccess,
                Token = response
            });
        }


        private IActionResult InvalidModelStateAuthFailResponse()
            => BadRequest(new AuthFailResponse
            {
                Status = Constants.AuthStatusFailed,
                Errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToArray()
            });

        private IActionResult AuthFailResponse(AuthResponse response)
            => BadRequest(new AuthFailResponse
            {
                Status = Constants.AuthStatusFailed,
                Errors = response.Errors
            });

        private IActionResult AuthSuccessResponse(AuthResponse response)
            => Ok(new AuthSuccessResponse
            {
                Status = Constants.AuthStatusSuccess,
                RefreshToken = response.RefreshToken,
                Token = response.Token
            });

    }
}