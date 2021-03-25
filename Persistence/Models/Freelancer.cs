using System.ComponentModel.DataAnnotations;

namespace Persistence.Models
{
    public class Freelancer
    {
        [Key]
        public int freelancerID { get; set; }
        [Required]
        public string freelancer { get; set; }
        [Required]
        public Address address { get; set; }
    }
}