using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FiverrEsqueApi.Models.Domain
{
    public class Language
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<AppUserLanguage> LanguageSpeakers { get; set; }
    }
}
