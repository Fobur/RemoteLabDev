using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Models
{
    public class OrganizationStand
    {
        [Key]
        public string? ID { get; set; }
        public int? StandID { get; set; }
        [Required, ForeignKey(nameof(StandID))]
        public Stand? Stand { get; set; }

        public string? OrganizationID { get; set; }
        [Required, ForeignKey(nameof(OrganizationID))]
        public Organization? Organization { get; set; }
    }
}
