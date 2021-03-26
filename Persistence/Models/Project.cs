using System.ComponentModel.DataAnnotations;

namespace Persistence.Models
{
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public int Estimation { get; set; }
        [Required]
        public Customer Customer { get; set; }

        
    }
}