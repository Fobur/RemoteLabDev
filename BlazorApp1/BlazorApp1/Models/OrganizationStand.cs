using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Models
{
    public class OrganizationStand
    {
        [Key]
        public string ID { get; set; }
        [Required]
        public Stand Stand { get; set; }
        [Required]
        public Organization Organization { get; set; }
    }
}
