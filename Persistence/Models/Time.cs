using System.ComponentModel.DataAnnotations;

namespace Persistence.Models
{
    public class Time
    {
        [Key]
        public int LogID { get; set; }
        [Required]
        public Freelancer FreelancerID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime workday { get; set; }
        [Required]
        public int hours { get; set; }
        [Required]
        public Project project { get; set; }
        [Required]
        public Price price { get; set; }
    }
}