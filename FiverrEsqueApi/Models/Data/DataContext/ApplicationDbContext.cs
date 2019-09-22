using FiverrEsqueApi.Models.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FiverrEsqueApi.Models.Data.DataContext
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUserInterest>()
                .HasKey(t => new { t.InterestId, t.AppUserId });

            builder.Entity<AppUserLanguage>()
                .HasKey(t => new { t.LanguageId, t.AppUserId });

            builder.Entity<AppUserSkill>()
                .HasKey(t => new { t.SkillId, t.AppUserId });

            builder.Entity<AppUserNotification>()
                .HasKey(t => new { t.NotificationId, t.AppUserId });
        }

    }
}