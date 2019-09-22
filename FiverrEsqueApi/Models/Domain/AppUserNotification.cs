using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FiverrEsqueApi.Models.Domain
{
    public class AppUserNotification
    {
        public string AppUserId { get; set; }

        [ForeignKey(nameof(AppUserId))]
        public AppUser AppUser { get; set; }

        public int NotificationId { get; set; }

        [ForeignKey(nameof(NotificationId))]
        public Notification Notification { get; set; }
    }
}
