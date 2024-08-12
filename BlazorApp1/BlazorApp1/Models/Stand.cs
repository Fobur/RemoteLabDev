using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Models
{
    public class Stand
    {
        [Key]
        public string ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? VideoUrl { get; set; }
        public Equipment? Equipment { get; set; }
        [Required]
        public string? AnsibleScript { get; set; }
    }
}
