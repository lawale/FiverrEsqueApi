using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FiverrEsqueApi.Models.Domain
{
    public class Rating
    {
        public int Id { get; set; }

        [Range(1,5)]
        public int SellerCommunicationStarRating { get; set; }

        [Range(1, 5)]
        public int RecommendationRatingStarRating { get; set; }

        [Range(1, 5)]
        public int ServiceRatingStarRating { get; set; }

        public Review Review { get; set; }

        [NotMapped]
        public double OverallRating => (SellerCommunicationStarRating + RecommendationRatingStarRating + ServiceRatingStarRating) / 3;
    }
}
