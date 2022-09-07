public class Student : Person, IAttendee
{
    public Student() { }
    public Student(string name, string email, IDBconnection db, ILocalConnection local)
    {
        Name = name;
        Email = email;
        Db = db;
        Excel = local;
    }

    public List<Batch> GetInfo()//final tested
    {
        List<Batch> batches = Db.GetBatchByPerson(this);
        if (batches.Count != 1) throw new Exception("This Student doesn't exist");
        batches[0].Grades = Db.GetGradeByPersonandBatchId(this, batches[0].ID);
        batches[0].Grades[0].Sections = Db.GetSectionByPersonandGradeId(this, batches[0].Grades[0].ID);
        Db.GetPersonIntoSection(batches[0].Grades[0].Sections[0]);
        return batches;
    }
    public Section GetFullSection(Section section)//final tested
    {
        throw new Exception();
    }
    public override bool FurtherAnalyze(string[] inputs, Section section)//final tested
    {
        switch (inputs.Length)
        {
            case 5: //-g attendance Til Secondary2 F
                GetPeriodsWithNameEmail(Name, Email, "", "Student", DateTime.Today, DateTime.Now, section);
                break;
            case 6: //-g attendance Til Secondary2 F August_, -g attendance Til Secondary2 F Science
                if (inputs[5].EndsWith("_"))
                {
                    try
                    {
                        var d = GetMonthStartAndEnd(inputs[5]);
                        GetPeriodsWithNameEmail(Name, Email, "", "Student", d.from, d.to, section);
                    }
                    catch { return false; }
                }
                else
                {
                    GetPeriodsWithNameEmail(Name, Email, inputs[5], "Student", DateTime.Today, DateTime.Now, section);
                }
                break;
            case 7: //-g attendance Til Secondary2 F Science August_
                if (inputs[6].EndsWith("_"))
                {
                    try
                    {
                        var d = GetMonthStartAndEnd(inputs[6]);
                        GetPeriodsWithNameEmail(Name, Email, inputs[5], "Student", d.from, d.to, section);
                    }
                    catch { return false; }
                }
                break;
        }
        return true;
    }
    public List<string> GetAllCommands()//final tested
    {
        List<string> output = new List<string>();
        output.Add("-Create Excel [PeriodId]");
        output.Add("-Create Feedback");
        output.Add("-Get Section");
        output.Add("-Get Attendance");
        output.Add("-Get Attendance [BatchName] [GradeName] [SectionName]");
        output.Add("-Get Attendance [BatchName] [GradeName] [SectionName] [Subject]");
        output.Add("-Get Attendance [BatchName] [GradeName] [SectionName] [Month_]");
        output.Add("-Get Attendance [BatchName] [GradeName] [SectionName] [Subject] [Month_]");
        output.Add("-Get Help");
        return output;
    }
}