using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FiverrEsqueApi.Models.Domain
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<AppUserSkill> SkilledUsers { get; set; }

    }
}
