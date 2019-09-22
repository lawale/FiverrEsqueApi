using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FiverrEsqueApi.Models.Domain
{
    public class AppUserInterest
    {
        public string AppUserId { get; set; }

        [ForeignKey(nameof(AppUserId))]
        public AppUser AppUser { get; set; }

        public int InterestId { get; set; }

        [ForeignKey(nameof(InterestId))]
        public Interest Interest { get; set; }
    }
}
