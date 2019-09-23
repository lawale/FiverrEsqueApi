using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiverrEsqueApi.Models.Data.Dto.V1.Responses
{
    public class AuthFailResponse
    {
        public string Status { get; set; }

        public string[] Errors { get; set; }
    }
}
