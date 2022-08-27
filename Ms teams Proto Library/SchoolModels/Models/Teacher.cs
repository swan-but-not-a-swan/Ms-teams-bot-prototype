public class Teacher : Person, IAttendee, IEducator
{
    public Subjects Subject { get; set; }
    public Teacher() { }
    public Teacher(string name, string email, IDBconnection db, ILocalConnection local)//refactored and tested
    {
        Name = name;
        Email = email;
        Db = db;
        Excel = local;
    }
    public List<Batch> GetInfo()//refactored and tested
    {
        List<Batch> batches = Db.GetBatchByTeacherName(Name);
        if (batches.Count <= 0) throw new Exception("This Tr doesn't exist");
        else
        {
            foreach (Batch b in batches)
            {
                b.Grades = Db.GetGradeByTeacherNameandBatchId(Name, b.ID);//get grades that the tr teacher
                foreach (var g in b.Grades)
                {
                   g.Sections = Db.GetSectionByTeacherNameandGradeId(Name, g.ID);//get sections and students and a tr
                   foreach (Section s in g.Sections)
                   {
                        s.Teachers.Add(Db.GetTeachersByClassId(s.ID).FirstOrDefault(t => t.Name == Name));
                        s.Students = Db.GetStudentsByClassId(s.ID);
                   }
                }
            }
        }
        return batches;
    }
    public Teacher ShallowCopy()//refactored and tested
    {
        return (Teacher)this.MemberwiseClone();
    }
    public async Task CreateMeeting(Batch batch, Section section, Period period)//refactored and tested
    {
        FileInfo filepath = new FileInfo(Path.Combine(GlobalTools.ExcelPath, $"{batch.Name} {batch.Grades[0].Name} {section.Teachers[0].Name}.xlsx"));
        List <Task> tasks = new List<Task>();
        tasks.Add(Task.Run(() => Db.StorePeriod(period, section.ID)));
        tasks.Add(Task.Run(() => CommandAnalyzer.ShowMeetingInfoOnMessageForm(batch.Name, batch.Grades[0].Name, section, period)));
        //CommandAnalyzer.ShowMeetingInfoOnMessageForm(batch.Name, batch.Grades[0].Name, section, period)
        tasks.Add(Excel.SaveExcelAsync(batch.Name, batch.Grades[0].Name, section, period,filepath));
        await Task.WhenAll(tasks);
    }
    public List<string> GetAllCommands()
    {
        List<string> output = new List<string>();
        output.Add("-Create Meeting");
        output.Add("-Create Meeting [SectionName]");
        output.Add("-Create Excel [on/off]");
        output.Add("-Create Excel [PeriodId]");
        output.Add("-Create Feedback");
        output.Add("-Get Section [BatchName] [GradeName] [SectionName]");
        output.Add("-Get Attendance");
        output.Add("-Get Attendance [BatchName] [GradeName] [SectionName]");
        output.Add("-Get Attendance [BatchName] [GradeName] [SectionName] [Subject]");
        output.Add("-Get Attendance [BatchName] [GradeName] [SectionName] [Name] [Email] [Role]");
        output.Add("-Get Attendance [BatchName] [GradeName] [SectionName] [Subject] [Name] [Email] [Role]");
        output.Add("-Get Attendance [BatchName] [GradeName] [SectionName] [Month_]");
        output.Add("-Get Attendance [BatchName] [GradeName] [SectionName] [Subject] [Month_]");
        output.Add("-Get Attendance [BatchName] [GradeName] [SectionName] [Name] [Email] [Role] [Month_]");
        output.Add("-Get Attendance [BatchName] [GradeName] [SectionName] [Subject] [Name] [Email] [Role] [Month_]");
        output.Add("-Get Help");
        return output;
    }
}
