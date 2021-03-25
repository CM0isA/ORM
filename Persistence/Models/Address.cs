using System.ComponentModel.DataAnnotations;

namespace Persistence.Models
{
    public class Address
    {
        [Key]
        public int addressID { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string zipcode { get; set; }
        [Required]
        public string state { get; set; }
        [Required]
        public string county { get; set; }
        [Required]
        public string City { get; set; }
    }
}