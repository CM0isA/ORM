using System.ComponentModel.DataAnnotations;

namespace Persistence.Models
{
    public class Freelancer
    {
        [Key]
        public int FreelancerID { get; set; }
        [Required]
        public string FreelancerName { get; set; }
        public Address Address { get; set; }
    }
}