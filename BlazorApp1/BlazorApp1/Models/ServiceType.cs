using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Models
{
    public class ServiceType
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public long DefaultTimeout { get; set; }
        [Required]
        public string DockerFilename { get; set; }
    }
}