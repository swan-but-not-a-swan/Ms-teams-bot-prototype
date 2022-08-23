using System.Globalization;

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
    public bool FurtherAnalyze(string[] inputs,Section section)
    {
        switch (inputs.Length)
        {
            case 5: //-g attendance Til Secondary2 F
                GetPeriods(inputs[2], inputs[3], "", "", "", "", DateTime.Today, DateTime.Now, section);
                break;
            case 6: //-g attendance Til Secondary2 F 21/8/2022, , -g attendance Til Secondary2 F Science
                if (inputs[5].EndsWith("_"))
                {
                    try 
                    { 
                        var d = GetMonthStartAndEnd(inputs[5]);
                        GetPeriods(inputs[2], inputs[3], "", "", "", "", d.from, d.to, section);
                    }
                    catch { return false; }
                    
                }
                else 
                {
                    GetPeriods(inputs[2], inputs[3], "", "", inputs[5], "", DateTime.Today, DateTime.Now, section);
                }
                break;
            case 7: //-g attendance Til Secondary2 F Science August_
                if (inputs[6].EndsWith("_"))
                {
                    try
                    {
                        var d = GetMonthStartAndEnd(inputs[6]);
                        GetPeriods(inputs[2], inputs[3], "", "", inputs[5], "", d.from, d.to, section);
                    }
                    catch { return false; }
                }
                break;
            case 8: //-g attendance Til Secondary2 F SwanSettAung Swan@ilbc.edu.mm Student
                string name_ = GlobalTools.GetSpacedName(inputs[5]);
                GetPeriods(inputs[2], inputs[3], name_, inputs[6], "", inputs[7], DateTime.Today, DateTime.Now, section);
                break;
            case 9: //-g attendance Til Secondary2 F SwanSettAung Swan@ilbc.edu.mm Student August_ , -g attendance Til Secondary2 F Science SwanSettAung Swan@ilbc.edu.mm Student
                
                if (inputs[8].EndsWith("_"))
                {
                    string name = GlobalTools.GetSpacedName(inputs[5]);
                    try
                    {
                        var d = GetMonthStartAndEnd(inputs[8]);
                        GetPeriods(inputs[2], inputs[3], name, inputs[6], "", inputs[7], d.from, d.to, section);
                    }
                    catch { return false; }
                }
                else
                {
                    string name = GlobalTools.GetSpacedName(inputs[6]);
                    GetPeriods(inputs[2], inputs[3], name, inputs[7], inputs[5], inputs[8], DateTime.Today, DateTime.Now, section);
                }
                break;
            case 10: //-g attendance Til Secondary2 F Science SwanSettAung Swan@ilbc.edu.mm Student August_
                string name__ = GlobalTools.GetSpacedName(inputs[6]);
                if (inputs[9].EndsWith("_"))
                {
                    try
                    {
                        var d = GetMonthStartAndEnd(inputs[9]);
                        GetPeriods(inputs[2], inputs[3], name__, inputs[7], inputs[5], inputs[8], d.from, d.to, section);
                    }
                    catch { return false; }
                }
                break;
        }
        return true;
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
    private (DateTime from,DateTime to) GetMonthStartAndEnd(string month)
    {
        string Month = month.TrimEnd('_');
        DateTime from = DateTime.ParseExact(Month, "MMMM", null);
        int daysInMonth = DateTime.DaysInMonth(from.Year, from.Month);
        DateTime to = new DateTime(from.Year, from.Month, daysInMonth,12,0,0);
        return (from, to);
    }
}