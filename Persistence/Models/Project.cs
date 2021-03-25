using System.ComponentModel.DataAnnotations;

namespace Persistence.Models
{
    public class Project
    {
        [Key]
        public int projectID { get; set; }
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public int estimation { get; set; }
        [Required]
        public Customer customer { get; set; }

        
    }
}