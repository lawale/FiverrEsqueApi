using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FiverrEsqueApi.Models.Domain
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderedGigId { get; set; }

        [ForeignKey(nameof(OrderedGigId))]
        public Gig OrderedGig { get; set; }

        [Required]
        public string BuyerId { get; set; }

        [ForeignKey(nameof(BuyerId))]
        public AppUser Buyer { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int DeliveryDays { get; set; }

        public OrderStatus OrderStatus { get; set; }
    }
}
