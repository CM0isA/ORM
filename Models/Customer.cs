using System.ComponentModel.DataAnnotations;

namespace ORM2.Models
{
    public class Customer
    {
        [Key]
        public int customerID { get; set; }
        [Required]
        public string customer { get; set; }
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