using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FiverrEsqueApi.Models.Domain
{
    
    public class Gig
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string SellerId { get; set; }

        [ForeignKey(nameof(SellerId))]
        public AppUser Seller { get; set; }

        [Required]
        public int NumberOfRevisions { get; set; }

        [Required]
        public int DeliveryDays { get; set; }

        public bool IsGigActive { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public string GigDescription { get; set; }
    }
}
