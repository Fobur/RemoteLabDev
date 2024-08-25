using BlazorApp1.Client.Models;
using BlazorApp1.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Models
{
    public class ScheduledStand
    {
        [Key]
        public string? ID { get; set; }
        public int? StandID { get; set; }
        [Required, ForeignKey(nameof(StandID))]
        public Stand? Stand { get; set; }

        public string? SchedulerID { get; set; }
        [ForeignKey(nameof(SchedulerID))]
        public Scheduler? Scheduler { get; set; }
        public string? UserID { get; set; }
        [ForeignKey(nameof(UserID))]
        public ApplicationUser? User { get; set; }
        [Required]
        public DateTimeOffset SessionStartTime { get; set; }
        [Required]
        public DateTimeOffset SessionEndTime { get; set; }

        public static ScheduledStand GetFromAppointmentStand(AppointmentStand stand)
        {
            return new ScheduledStand
            {
                ID = stand.ID,
                StandID = stand.StandID,
                SchedulerID = stand.SchedulerID,
                UserID = stand.UserID,
                SessionStartTime = stand.StartAppointment.ToUniversalTime(),
                SessionEndTime = stand.EndAppointment.ToUniversalTime()
            };
        }
    }
}
