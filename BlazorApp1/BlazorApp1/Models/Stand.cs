using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Models
{
    public class Stand
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? VideoUrl { get; set; }
        public string[]? EquipmentID { get; set; }
        [ForeignKey(nameof(EquipmentID))]
        public Equipment[]? Equipment { get; set; }
        [Required]
        public string? AnsibleScript { get; set; }
    }
}
