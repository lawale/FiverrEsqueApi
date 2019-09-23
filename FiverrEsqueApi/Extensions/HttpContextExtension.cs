using FiverrEsqueApi.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiverrEsqueApi.Extensions
{
    public static class HttpContextExtension
    {
        public static async Task<AppUser> AppUserFromContextAsync(this HttpContext context, UserManager<AppUser> userManager)
        {
            if (context.User == null)
                return null;
            var id = context.User.Claims.Single(x => x.Type == "id").Value;
            var user = await userManager.FindByIdAsync(id);
            return user;
        }
    }
}
