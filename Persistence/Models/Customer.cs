using System.ComponentModel.DataAnnotations;

namespace Persistence.Models
{
    public class Customer
    {
        [Key]
        public int customerID { get; set; }
        [Required]
        public string customer { get; set; }
        [Required]
        public Address address { get; set; }

    }
}