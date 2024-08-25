namespace BlazorApp1.Client.Models
{
    public class AppointmentStand
    {
        public string ID { get; set; }
        public int StandID { get; set; }
        public string StandName { get; set; }
        public string? SchedulerID { get; set; }
        public DateTime StartAppointment { get; set; }
        public DateTime EndAppointment { get; set; }
        public string? Text { get; set; }
        public string? StudentGroupID { get; set; }
        public string? UserID { get; set; }

        public AppointmentStand(string id, int standID, string standName, string schedulerID,
            string studentGroupID, string userID, DateTime startAppointment, DateTime endAppointment)
        {
            ID = id;
            StandID = standID;
            StandName = standName;
            SchedulerID = schedulerID;
            StudentGroupID = StudentGroupID;
            UserID = userID;
            StartAppointment = startAppointment;
            EndAppointment = endAppointment;
            Text = $"{StandName}";
        }

        public AppointmentStand() { }
    }
}
