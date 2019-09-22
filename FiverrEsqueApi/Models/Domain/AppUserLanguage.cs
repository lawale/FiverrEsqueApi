using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FiverrEsqueApi.Models.Domain
{
    public class AppUserLanguage
    {
        public string AppUserId { get; set; }

        [ForeignKey(nameof(AppUserId))]
        public AppUser AppUser { get; set; }

        public int LanguageId { get; set; }

        [ForeignKey(nameof(LanguageId))]
        public Language Language {get;set;}
    }
}
