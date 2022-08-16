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
    Section GetFullSection(int gradeId,char sectionName);
    void GetPeriods(string name, string email, string subject,string Role, DateTime from, DateTime to, Batch b);
}
