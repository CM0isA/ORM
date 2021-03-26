using System.ComponentModel.DataAnnotations;

namespace Persistence.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public Address Address { get; set; }

    }
}