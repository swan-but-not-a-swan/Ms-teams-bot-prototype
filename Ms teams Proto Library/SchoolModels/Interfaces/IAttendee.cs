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
    Task SaveIntoExcel(string BatchName, string GradeName, Section section,Period period,FileInfo filepath);
    Section GetFullSection(Section section);
    bool FurtherAnalyze(string[] inputs, Section section);
    void GetPeriods(string subject, DateTime from, DateTime to,Section section);
    void GetPeriodsWithNameEmail(string name, string email, string subject, string Role, DateTime from, DateTime to,Section section);
    List<string> GetAllCommands();
}
