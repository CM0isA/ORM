using System.ComponentModel.DataAnnotations;

namespace Persistence.Models
{
    public class Time
    {
        [Key]
        public int LogID { get; set; }
        [Required]
        public Freelancer Freelancers { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime Workday { get; set; }
        [Required]
        public int Hours { get; set; }
        [Required]
        public Project Project { get; set; }
        [Required]
        public Price Price { get; set; }

    }
}