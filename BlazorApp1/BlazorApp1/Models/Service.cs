using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Models
{
    public class Service
    {
        [Key]
        public string? Id { get; set; }
        [Required]
        public Stand? Stand { get; set; }
        public int? ServiceTypeId { get; set; }
        [Required, ForeignKey(nameof(ServiceTypeId))]
        public ServiceType? ServiceType { get; set; }
        [Required]
        public DateTime TimeStartService { get; set; }
        [Required]
        public DateTime TimeStopService { get; set; }
        [Required]
        public string? DockerPort { get; set; }
    }
}
