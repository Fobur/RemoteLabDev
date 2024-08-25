using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Models
{
    public class Service
    {
        [Key]
        public string? ID { get; set; }
        [Required]
        public Stand? Stand { get; set; }
        public int? ServiceTypeID { get; set; }
        [Required, ForeignKey(nameof(ServiceTypeID))]
        public ServiceType? ServiceType { get; set; }
        [Required]
        public DateTime TimeStartService { get; set; }
        [Required]
        public DateTime TimeStopService { get; set; }
        [Required]
        public string? DockerPort { get; set; }
    }
}
