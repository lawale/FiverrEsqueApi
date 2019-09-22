using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FiverrEsqueApi.Models.Domain
{
    public enum OrderStatus
    {
        NotDelivered = 0,

        LateAndNotDelivered = 1,

        Delivered = 10,

        LateAndDelivered = 11,

        Accepted = 20,

        LateAndAccepted = 21,

        Cancelled = 30,

        LateAndCancelled = 31
    }
}
