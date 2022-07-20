public class Period
{
    public int ID { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Subjects Subject { get; set; }
    public List<IAttendee> Attendees { get; set; } = new List<IAttendee>();
}