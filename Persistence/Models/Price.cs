using System.ComponentModel.DataAnnotations;

namespace Persistence.Models
{
    public class Price
    {
        [Key]
        public int PriceID { get; set; }
        [Required]
        public float Value { get; set; }
    }
}