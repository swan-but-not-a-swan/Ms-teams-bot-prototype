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
    public virtual bool FurtherAnalyze(string[] inputs,Section section)
    {
        switch (inputs.Length)
        {
            case 5: //-g attendance Til Secondary2 F
                section.Periods = Db.GetMeetingInfoWithoutNameandEmail(DateTime.Today, DateTime.Now, section.ID);
                break;
            case 6: //-g attendance Til Secondary2 F August_, -get attendance Til Secondary2 F Science
                if (inputs[5].EndsWith("_"))
                {
                    try 
                    { 
                        var d = GetMonthStartAndEnd(inputs[5]);
                        section.Periods = Db.GetMeetingInfoWithoutNameandEmail(d.from, d.to, section.ID);
                    }
                    catch { return false; }
                }
                else 
                {
                    section.Periods = Db.GetMeetingInfoSubjectWithoutNameandEmail(DateTime.Today, DateTime.Now, section.ID, inputs[5]);
                }
                break;
            case 7: //-g attendance Til Secondary2 F Science August_
                if (inputs[6].EndsWith("_"))
                {
                    try
                    {
                        var d = GetMonthStartAndEnd(inputs[6]);
                        section.Periods = Db.GetMeetingInfoSubjectWithoutNameandEmail(d.from, d.to, section.ID, inputs[5]);
                    }
                    catch { return false; }
                }
                break;
            case 8: //-g attendance Til Secondary2 F SwanSettAung Swan@ilbc.edu.mm Student
                string name_ = GlobalTools.GetSpacedName(inputs[5]);
                section.Periods = Db.GetMeetingInfoWithNameandEmail( DateTime.Today, DateTime.Now, section.ID, name_, inputs[6], inputs[7]);
                break;
            case 9: //-g attendance Til Secondary2 F SwanSettAung Swan@ilbc.edu.mm Student August_ , -g attendance Til Secondary2 F Science SwanSettAung Swan@ilbc.edu.mm Student
                
                if (inputs[8].EndsWith("_"))
                {
                    string name = GlobalTools.GetSpacedName(inputs[5]);
                    try
                    {
                        var d = GetMonthStartAndEnd(inputs[8]);
                        section.Periods = Db.GetMeetingInfoWithNameandEmail(d.from, d.to, section.ID, name, inputs[6], inputs[7]);
                    }
                    catch { return false; }
                }
                else
                {
                    string name = GlobalTools.GetSpacedName(inputs[6]);
                    section.Periods = Db.GetMeetingInfoSubjectWithNameandEmail(DateTime.Today, DateTime.Now, section.ID, name, inputs[7], inputs[8], inputs[6]);
                }
                break;
            case 10: //-g attendance Til Secondary2 F Science SwanSettAung Swan@ilbc.edu.mm Student August_
                string name__ = GlobalTools.GetSpacedName(inputs[6]);
                if (inputs[9].EndsWith("_"))
                {
                    try
                    {
                        var d = GetMonthStartAndEnd(inputs[9]);
                        section.Periods = Db.GetMeetingInfoSubjectWithNameandEmail(d.from, d.to, section.ID, name__, inputs[7], inputs[8], inputs[5]);
                    }
                    catch { return false; }
                }
                break;
        }
        return true;
    }
    public void GetPeriods(string batchName, string GradeName,string name,string email, string subject,string Role,DateTime from,DateTime to,Section section)
    {
        if(name.Length <= 0  || email.Length <= 0)
        {
            GetPeriodsWithoutNameEmail( subject, from, to, section);
        }
        else
        {
            GetPeriodsWithNameEmail(name, email, subject, Role, from, to, section);   
        }
    }
    public void GetPeriodsWithoutNameEmail( string subject, DateTime from, DateTime to, Section section)
    {
        if (subject.Length <= 0)
        {
            section.Periods = Db.GetMeetingInfoWithoutNameandEmail(from, to, section.ID);
        }
        else
        {
            section.Periods = Db.GetMeetingInfoSubjectWithoutNameandEmail(from, to, section.ID, subject);
        }
    }
    public void GetPeriodsWithNameEmail( string name, string email, string subject, string Role, DateTime from, DateTime to, Section section)
    {
        if (subject.Length <= 0)
        {
            section.Periods = Db.GetMeetingInfoWithNameandEmail(from, to, section.ID, name, email, Role);
        }
        else
        {
            section.Periods = Db.GetMeetingInfoSubjectWithNameandEmail(from, to, section.ID, name, email, Role, subject);
        }
    }
    protected (DateTime from,DateTime to) GetMonthStartAndEnd(string month)
    {
        string Month = month.TrimEnd('_');
        DateTime from = DateTime.ParseExact(Month, "MMMM", null);
        int daysInMonth = DateTime.DaysInMonth(from.Year, from.Month);
        DateTime to = new DateTime(from.Year, from.Month, daysInMonth,12,0,0);
        return (from, to);
    }
    public async Task SaveIntoExcel(string BatchName, string GradeName, Section section,Period periood,FileInfo filepath)
    {
        await Task.Run(()=> Excel.SaveExcelAsync(BatchName, GradeName, section, periood,filepath));
    }
}