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
    public virtual Section GetFullSection(int gradeId, Section section)
    {
        Section output = new Section { ID = section.ID, Name = section.Name };
        Db.GetPersonIntoSection(output);
        return output;
    }
    public virtual void GetPeriods(string batchName, string GradeName,string name,string email, string subject,string Role,DateTime from,DateTime to,Section section)
    {
        if(name.Length <= 0  || email.Length <= 0)
        {
            if (subject.Length <= 0)
            {
                List<Period> periods = Db.GetMeetingInfoWithoutNameandEmail(from, to, section.ID);
                if (periods.Count > 0)
                {
                    foreach (Period pe in periods)
                    {
                        CommandAnalyzer.ShowMeetingInfoOnMessageForm(batchName, GradeName, section, pe);
                    }
                }
            }
            else
            {
                List<Period> periods = Db.GetMeetingInfoSubjectWithoutNameandEmail(from, to, section.ID,subject);
                if (periods.Count > 0)
                {
                    foreach (Period pe in periods)
                    {
                        CommandAnalyzer.ShowMeetingInfoOnMessageForm(batchName, GradeName, section, pe);
                    }
                }
            }
        }
        else
        {
            if(subject.Length <= 0)
            {
                List<Period> periods = Db.GetMeetingInfoWithNameandEmail(from, to, section.ID,name,email,Role);
                if (periods.Count > 0)
                {
                    foreach (Period pe in periods)
                    {
                        CommandAnalyzer.ShowMeetingInfoOnMessageForm(batchName, GradeName, section, pe);
                    }
                }
            }
            else
            {
                List<Period> periods = Db.GetMeetingInfoSubjectWithNameandEmail(from, to, section.ID, name, email, Role,subject);
                if (periods.Count > 0)
                {
                    foreach (Period pe in periods)
                    {
                        CommandAnalyzer.ShowMeetingInfoOnMessageForm(batchName, GradeName, section, pe);
                    }
                }
            }
        }
    }
}