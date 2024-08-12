using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Models
{
    public class Organization
    {
        [Key]
        public string ID { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public Stand[] Stands { get; set; } = new Stand[100];
        [Required]
        public DateTime CreationTime { get; set; }
    }
}
