using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiverrEsqueApi.Models.Data.Dto.V1.Responses
{
    public class AuthResponse
    {
        public bool IsSuccess { get; set; }

        public string Token { get; set; }

        public string RefreshToken { get; set; }

        public string[] Errors { get; set; }
    }
}
