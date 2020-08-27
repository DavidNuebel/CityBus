using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityBus.Database.Models
{
    public class TicketCondition
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(3)]
        public string Short { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public float Amount { get; set; }

        [Required]
        public float ExpiryOffset { get; set; }

        public override string ToString()
        {
            return $"{Short} - {Amount.ToString("0.00")} €";
        }
    }
}