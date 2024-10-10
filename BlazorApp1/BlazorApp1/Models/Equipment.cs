using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Models
{
    public class Equipment
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}
