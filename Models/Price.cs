using System.ComponentModel.DataAnnotations;

namespace ORM2.Models
{
    public class Price
    {
        [Key]
        public int priceID { get; set; }
        [Required]
        public float price { get; set; }
    }
}