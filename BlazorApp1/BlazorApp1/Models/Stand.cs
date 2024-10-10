using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Models
{
    public class Stand
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? VideoUrl { get; set; }
        public string[]? EquipmentId { get; set; }
        [ForeignKey(nameof(EquipmentId))]
        public Equipment[]? Equipment { get; set; }
        [Required]
        public string? AnsibleScript { get; set; }
    }
}
