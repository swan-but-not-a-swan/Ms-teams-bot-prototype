public interface IAttendee
{
    int ID { get; set; }
    string Name { get; set; }
    string Email { get; set; }
    DateTime? JoinTime { get; set; }
    DateTime? LeaveTime { get; set; }
    TimeSpan? Duration { get; set; }
    string Status { get; set; }
    List<Batch> GetInfo();
    Section GetFullSection(Grade grade,char sectionName);
}
