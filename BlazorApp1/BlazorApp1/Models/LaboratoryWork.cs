using BlazorApp1.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Models
{
    public class LaboratoryWork
    {
        [Key]
        public string Id { get; set; }

        public string UserId { get; set; }
        [Required, ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        public int? StandID { get; set; }
        [Required, ForeignKey(nameof(StandID))]
        public Stand? Stand { get; set; }

        [Required]
        public string? PathToCodeFile { get; set; }
    }
}
