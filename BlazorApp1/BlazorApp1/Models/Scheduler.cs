using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BlazorApp1.Models
{
    public class Scheduler
    {
        [Key]
        public string ID { get; set; }
        [Required]
        public StudentGroup StudentGroup { get; set; }
        [Required]
        public DateTime SessionStartTime { get; set; }
        [Required]
        public DateTime SessionEndTime { get; set; }
        [Required]
        public DateTime SessionDayOfWeek { get; set; }
        [Required]
        public DateTime StartPeriodDatetime { get; set; }
        [Required]
        public DateTime EndPeriodDatetime { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
