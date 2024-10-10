using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Models
{
    public class Organization
    {
        [Key]
        public string? Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string[]? StandsId { get; set; }
        [Required, ForeignKey(nameof(StandsId))]
        public Stand[]? Stands { get; set; }
        [Required]
        public DateTime CreationTime { get; set; }
    }
}
