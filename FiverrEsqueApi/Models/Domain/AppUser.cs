using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiverrEsqueApi.Models.Domain
{
    public class AppUser : IdentityUser
    {
        public string DisplayPicture { get; set; }

        public bool IsSeller { get; set; }

        public string Nationality { get; set; }

        public DateTime Joined { get; set; }

        public string SellerAccountDescription { get; set; }

        [InverseProperty("Receiver")]
        public ICollection<Message> ReceivedMessages { get; set; }

        [InverseProperty("Sender")]
        public ICollection<Message> SentMessages { get; set; }

        public ICollection<AppUserLanguage> Languages { get; set; }

        public ICollection<AppUserInterest> Interests { get; set; }

        public ICollection<AppUserSkill> Skills { get; set; }

        public ICollection<Gig> Gigs { get; set; }

        public ICollection<AppUserNotification> Notifications { get; set; }

        [InverseProperty("Buyer")]
        public ICollection<Review> GigReviewsAsBuyer { get; set; }

        [InverseProperty("Seller")]
        public ICollection<Review> GigReviewsAsSeller { get; set; }
    }
}