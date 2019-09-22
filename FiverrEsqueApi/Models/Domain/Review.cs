using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FiverrEsqueApi.Models.Domain
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string BuyerReview { get; set; }

        [Required]
        public string BuyerId { get; set; }

        [ForeignKey(nameof(BuyerId))]
        public AppUser Buyer { get; set; }

        [Required]
        public string SellerId { get; set; }

        [ForeignKey(nameof(SellerId))]
        public AppUser Seller { get; set; }

        [Required]
        public int RatingId { get; set; }

        [ForeignKey(nameof(RatingId))]
        public Rating Rating { get; set; }

        [Required]
        public DateTime TimeOfReview { get; set; }

    }
}
