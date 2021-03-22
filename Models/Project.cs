using System.ComponentModel.DataAnnotations;

namespace ORM2.Models
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