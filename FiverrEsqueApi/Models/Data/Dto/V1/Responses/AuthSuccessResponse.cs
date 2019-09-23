using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiverrEsqueApi.Models.Data.Dto.V1.Responses
{
    public class AuthSuccessResponse
    {
        public string Status { get; set; }

        public string Token { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string RefreshToken { get; set; }
    }
}
