﻿public abstract class Person
{
    public int ID { get; set; }
    public string Name { get; set ; }
    public string Email { get; set; }
    public DateTime? JoinTime { get; set; } = null;
    public DateTime? LeaveTime { get; set; } = null;
    public TimeSpan? Duration { get; set; } = null;
    public string Status { get; set; }
    public IDBconnection Db { get; set; }
    public ILocalConnection Excel { get; set; }
    public virtual bool FurtherAnalyze(string[] inputs,Section section)//final tested
    {
        switch (inputs.Length)
        {
            case 5: //-g attendance Til Secondary2 F
                GetPeriods("", DateTime.Today, DateTime.Now, section);
                break;
            case 6: //-g attendance Til Secondary2 F August_, -get attendance Til Secondary2 F Science
                if (inputs[5].EndsWith("_"))
                {
                    try 
                    { 
                        var d = GetMonthStartAndEnd(inputs[5]);
                        GetPeriods("", d.from, d.to, section);
                    }
                    catch { return false; }
                }
                else 
                {
                    GetPeriods(inputs[5], DateTime.Today, DateTime.Now, section);
                }
                break;
            case 7: //-g attendance Til Secondary2 F Science August_
                if (inputs[6].EndsWith("_"))
                {
                    try
                    {
                        var d = GetMonthStartAndEnd(inputs[6]);
                        GetPeriods(inputs[5], d.from, d.to, section);
                    }
                    catch { return false; }
                }
                break;
            case 8: //-g attendance Til Secondary2 F SwanSettAung Swan@ilbc.edu.mm Student
                string name_ = GlobalTools.GetSpacedName(inputs[5]);
                GetPeriodsWithNameEmail(name_, inputs[6], "", inputs[7], DateTime.Today, DateTime.Now, section);
                break;
            case 9: //-g attendance Til Secondary2 F SwanSettAung Swan@ilbc.edu.mm Student August_ , -g attendance Til Secondary2 F Science SwanSettAung Swan@ilbc.edu.mm Student
                if (inputs[8].EndsWith("_"))
                {
                    string name = GlobalTools.GetSpacedName(inputs[5]);
                    try
                    {
                        var d = GetMonthStartAndEnd(inputs[8]);
                        GetPeriodsWithNameEmail(name, inputs[6], "", inputs[7], d.from, d.to, section);
                    }
                    catch { return false; }
                }
                else
                {
                    string name = GlobalTools.GetSpacedName(inputs[6]);
                    GetPeriodsWithNameEmail(name, inputs[7], inputs[5], inputs[8], DateTime.Today, DateTime.Now,section);
                }
                break;
            case 10: //-g attendance Til Secondary2 F Science SwanSettAung Swan@ilbc.edu.mm Student August_
                string name__ = GlobalTools.GetSpacedName(inputs[6]);
                if (inputs[9].EndsWith("_"))
                {
                    try
                    {
                        var d = GetMonthStartAndEnd(inputs[9]);
                        GetPeriodsWithNameEmail(name__, inputs[7], inputs[5], inputs[8], d.from, d.to, section);
                    }
                    catch { return false; }
                }
                break;
        }
        return true;
    }
    public void GetPeriods(string subject, DateTime from, DateTime to, Section section)//final tested
    {
        if (subject.Length <= 0)
            section.Periods = Db.GetPeriods(from, to, section.ID);
        else
            section.Periods = Db.GetPeriods(from, to, section.ID).Where(pe => pe.Subject.ToString() == subject).ToList();
        Db.GetAttendess(section.Periods);
    }
    public void GetPeriodsWithNameEmail( string name, string email, string subject, string Role, DateTime from, DateTime to, Section section)//final tested
    {
        if (subject.Length <= 0)
            section.Periods = Db.GetPeriodsWithNameandEmail(from, to, section.ID, name, email, Role);
        else
            section.Periods = Db.GetPeriodsWithNameandEmail(from, to, section.ID, name, email, Role).Where(pe => pe.Subject.ToString() == subject).ToList();
        Db.GetAttendeesWithNameandEmail(section.Periods,name,email,Role);
    }
    protected (DateTime from,DateTime to) GetMonthStartAndEnd(string month)//final tested
    {
        string Month = month.TrimEnd('_');
        DateTime from = DateTime.ParseExact(Month, "MMMM", null);
        int daysInMonth = DateTime.DaysInMonth(from.Year, from.Month);
        DateTime to = new DateTime(from.Year, from.Month, daysInMonth,12,0,0);
        return (from, to);
    }
    public async Task SaveIntoExcel(string BatchName, string GradeName, Section section,Period periood,FileInfo filepath)//final tested
    {
        await Task.Run(()=> Excel.SaveExcelAsync(BatchName, GradeName, section, periood,filepath));
    }
}