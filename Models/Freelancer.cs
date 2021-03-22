using System.ComponentModel.DataAnnotations;

namespace ORM2.Models
{
    public class Freelancer
    {
        [Key]
        public int freelancerID { get; set; }
        [Required]
        public string freelancer { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string zipcode { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string state { get; set; }
        [Required]
        public string county { get; set; }
    }
}