public class Student : Person, IAttendee, IStudent
{
    public Student() { }
    public Student(string name, string email, IDBconnection db, ILocalConnection local)
    {
        Name = name;
        Email = email;
        Db = db;
        Excel = local;
    }

    public override Section GetFullSection(int gradeId, Section section)
    {
        throw new NotImplementedException();
    }

    public List<Batch> GetInfo()
    {
        List<Batch> batches = Db.GetBatchByStudentName(Name);
        if (batches.Count <= 0 || batches.Count > 1) throw new Exception("This Student doesn't exist");
        else
        {
            batches[0].Grades = Db.GetGradeByStudentNameandBatchId(Name, batches[0].ID);
            batches[0].Grades[0].Sections = Db.GetSectionByStudentNameandGradeId(Name, batches[0].Grades[0].ID);
        }
        return batches;
    }
    public override bool FurtherAnalyze(string[] inputs, Section section)
    {
        switch (inputs.Length)
        {
            case 5: //-g attendance Til Secondary2 F
                section.Periods = Db.GetMeetingInfoWithNameandEmail(DateTime.Today, DateTime.Now, section.ID,Name,Email,"Student");
                break;
            case 6: //-g attendance Til Secondary2 F August_, -g attendance Til Secondary2 F Science
                if (inputs[5].EndsWith("_"))
                {
                    try
                    {
                        var d = GetMonthStartAndEnd(inputs[5]);
                        section.Periods = Db.GetMeetingInfoWithNameandEmail(d.from, d.to, section.ID, Name, Email, "Student");
                    }
                    catch { return false; }
                }
                else
                {
                    section.Periods = Db.GetMeetingInfoSubjectWithNameandEmail(DateTime.Today, DateTime.Now, section.ID, inputs[5], Name, Email, "Student");
                }
                break;
            case 7: //-g attendance Til Secondary2 F Science August_
                if (inputs[6].EndsWith("_"))
                {
                    try
                    {
                        var d = GetMonthStartAndEnd(inputs[6]);
                        section.Periods = Db.GetMeetingInfoSubjectWithNameandEmail(d.from, d.to, section.ID, inputs[5], Name, Email, "Student");
                    }
                    catch { return false; }
                }
                break;
        }
        return true;
    }
    public List<string> GetAllCommands()
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