using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FiverrEsqueApi.Models.Domain
{
    public class AppUserSkill
    {
        public string AppUserId { get; set; }

        [ForeignKey(nameof(AppUserId))]
        public AppUser AppUser { get; set; }

        public int SkillId { get; set; }

        [ForeignKey(nameof(SkillId))]
        public Skill Skill { get; set; }
    }
}
