using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Models
{
    public class OrganizationStand
    {
        [Key]
        public string? Id { get; set; }
        public int? StandId { get; set; }
        [Required, ForeignKey(nameof(StandId))]
        public Stand? Stand { get; set; }

        public string? OrganizationID { get; set; }
        [Required, ForeignKey(nameof(OrganizationID))]
        public Organization? Organization { get; set; }
    }
}
