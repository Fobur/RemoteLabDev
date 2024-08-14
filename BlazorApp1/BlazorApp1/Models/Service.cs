using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Models
{
    public class Service
    {
        [Key]
        public string ID { get; set; }
        [Required]
        public Stand Stand { get; set; }
        [Required]
        public ServiceType ServiceType { get; set; }
        [Required]
        public DateTime TimeStartService { get; set; }
        [Required]
        public DateTime TimeStopService { get; set; }
        [Required]
        public string DockerPort { get; set; }
    }
}
