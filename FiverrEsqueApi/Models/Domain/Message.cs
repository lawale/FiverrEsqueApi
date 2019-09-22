using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FiverrEsqueApi.Models.Domain
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [Required]
        public string Content { get; set; }

        public ICollection<Attachment> Attachments { get; set; }

        public string SenderId { get; set; }

        [ForeignKey(nameof(SenderId))]
        public AppUser Sender { get; set; }

        public string ReceiverId { get; set; }

        [ForeignKey(nameof(ReceiverId))]
        public AppUser Receiver { get; set; }


    }
}
