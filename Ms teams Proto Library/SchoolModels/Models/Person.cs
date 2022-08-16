public abstract class Person
{
    public int ID { get; set; }
    public string Name { get; set  ; }
    public string Email { get; set; }
    public DateTime? JoinTime { get; set; } = null;
    public DateTime? LeaveTime { get; set; } = null;
    public TimeSpan? Duration { get; set; } = null;
    public string Status { get; set; }
    public IDBconnection Db { get; set; }
    public ILocalConnection Excel { get; set; }
    public virtual void GetPeriods(string name,string email, string subject,string Role,DateTime from,DateTime to,Batch b)
    {
        if(name.Length <= 0  || email.Length <= 0)
        {
            if (subject.Length <= 0)
            {
                List<Period> periods = Db.GetMeetingInfoWithoutNameandEmail(from, to, b.Grades[0].Sections[0].ID);
                if (periods.Count > 0)
                {
                    foreach (Period pe in periods)
                    {
                        CommandAnalyzer.ShowMeetingInfoOnMessageForm(b.Name, b.Grades[0].Name, b.Grades[0].Sections[0], pe);
                    }
                }
            }
            else
            {
                List<Period> periods = Db.GetMeetingInfoSubjectWithoutNameandEmail(from, to, b.Grades[0].Sections[0].ID,subject);
                if (periods.Count > 0)
                {
                    foreach (Period pe in periods)
                    {
                        CommandAnalyzer.ShowMeetingInfoOnMessageForm(b.Name, b.Grades[0].Name, b.Grades[0].Sections[0], pe);
                    }
                }
            }
        }
        else
        {
            if(subject.Length <= 0)
            {
                List<Period> periods = Db.GetMeetingInfoWithNameandEmail(from, to, b.Grades[0].Sections[0].ID,name,email,Role);
                if (periods.Count > 0)
                {
                    foreach (Period pe in periods)
                    {
                        CommandAnalyzer.ShowMeetingInfoOnMessageForm(b.Name, b.Grades[0].Name, b.Grades[0].Sections[0], pe);
                    }
                }
            }
            else
            {
                List<Period> periods = Db.GetMeetingInfoSubjectWithNameandEmail(from, to, b.Grades[0].Sections[0].ID, name, email, Role,subject);
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
}