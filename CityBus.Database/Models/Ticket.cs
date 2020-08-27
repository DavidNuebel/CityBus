using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CityBus.Database.Models
{
    public class Ticket
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public Guid Serial { get; set; }

        [Required]
        public DateTime CreationTime { get; set; }

        [Required]
        public DateTime ExpiryTime { get; set; }

        [Required]
        [ForeignKey("TicketConditionId")]
        public TicketCondition TicketCondition { get; set; }

        public override string ToString()
        {
            return $"({ID}) {TicketCondition.Short} {TicketCondition.Amount.ToString("0.00 €")}";
        }
    }
}
