using System.ComponentModel.DataAnnotations;

namespace Persistence.Models
{
    public class Price
    {
        [Key]
        public int priceID { get; set; }
        [Required]
        public float price { get; set; }
    }
}