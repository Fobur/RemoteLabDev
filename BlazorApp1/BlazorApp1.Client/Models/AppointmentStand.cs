namespace BlazorApp1.Client.Models
{
    public class AppointmentStand
    {
        public string Id { get; set; }
        public int StandId{ get; set; }
        public string StandName { get; set; }
        public string? SchedulerId { get; set; }
        public DateTime StartAppointment { get; set; }
        public DateTime EndAppointment { get; set; }
        public string? Text { get; set; }
        public string? StudentGroupId { get; set; }
        public string? UserId { get; set; }

        public AppointmentStand(string id, int standId, string standName, string schedulerId,
            string studentGroupId, string userId, DateTime startAppointment, DateTime endAppointment)
        {
            Id = id;
            StandId = standId;
            StandName = standName;
            SchedulerId = schedulerId;
            StudentGroupId = studentGroupId;
            UserId = userId;
            StartAppointment = startAppointment;
            EndAppointment = endAppointment;
            Text = $"{StandName}";
        }

        public AppointmentStand() { }
    }
}
