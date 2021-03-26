using System.ComponentModel.DataAnnotations;

namespace Persistence.Models
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Zipcode { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string County { get; set; }
        [Required]
        public string City { get; set; }
    }
}