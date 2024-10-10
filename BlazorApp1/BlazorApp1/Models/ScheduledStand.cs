using BlazorApp1.Client.Models;
using BlazorApp1.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Models
{
    public class ScheduledStand
    {
        [Key]
        public string? Id { get; set; }
        public int? StandId { get; set; }
        [Required, ForeignKey(nameof(StandId))]
        public Stand? Stand { get; set; }

        public string? SchedulerId { get; set; }
        [ForeignKey(nameof(SchedulerId))]
        public Scheduler? Scheduler { get; set; }
        public string? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser? User { get; set; }
        [Required]
        public DateTimeOffset SessionStartTime { get; set; }
        [Required]
        public DateTimeOffset SessionEndTime { get; set; }

        public static ScheduledStand GetFromAppointmentStand(AppointmentStand stand)
        {
            return new ScheduledStand
            {
                Id = stand.Id,
                StandId = stand.StandId,
                SchedulerId = stand.SchedulerId,
                UserId = stand.UserId,
                SessionStartTime = TimeZoneInfo.ConvertTimeToUtc(stand.StartAppointment, TimeZoneInfo.Local),
                SessionEndTime = TimeZoneInfo.ConvertTimeToUtc(stand.EndAppointment, TimeZoneInfo.Local)
            };
        }
    }
}
