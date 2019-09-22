using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FiverrEsqueApi.Models.Domain
{
    public class Attachment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Size { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int MessageId { get; set; }

        [ForeignKey(nameof(MessageId))]
        public Message Message { get; set; }
    }
}
