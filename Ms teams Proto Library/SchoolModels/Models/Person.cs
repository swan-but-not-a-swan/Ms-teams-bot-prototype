public abstract class Person
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime? JoinTime { get; set; } = null;
    public DateTime? LeaveTime { get; set; } = null;
    public TimeSpan? Duration { get; set; } = null;
    public string Status { get; set; }
    public IDBconnection Db { get; set; }
    public ILocalConnection Excel { get; set; }
    public void GetPeriods(string name,string email, string subject,DateTime from,DateTime to,Batch b)
    {
        if(!(name is null || email is null || subject is null))
        {
            List<Period> periods = Db.GetPeriodsWithoutNameEmailSubject(from, to, b.Grades[0].Sections[0].ID);
            if (periods.Count > 0)
            {
                foreach (Period pe in periods)
                {
                    CommandAnalyzer.ShowMeetingInfoOnMessageForm(b.Name, b.Grades[0].Name, b.Grades[0].Sections[0], pe);
                }
            }
        }
        
    }
}