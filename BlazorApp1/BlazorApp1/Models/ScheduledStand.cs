using BlazorApp1.Components.Stands.Pages;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Models
{
    public class ScheduledStand
    {
        [Key]
        public string ID { get; set; }
        [Required]
        public Stand Stand { get; set; }
        [Required]
        public Scheduler? Scheduler { get; set; }
    }
}
