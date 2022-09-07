public class Teacher : Person, IAttendee, IEducator
{
    public Subjects Subject { get; set; }
    public Teacher() { }
    public Teacher(string name, string email, IDBconnection db, ILocalConnection local)
    {
        Name = name;
        Email = email;
        Db = db;
        Excel = local;
    }
    public List<Batch> GetInfo()//final tested
    {
        List<Batch> batches = Db.GetBatchByPerson(this);
        if (batches.Count <= 0) throw new Exception("This Tr doesn't exist");
        foreach (Batch b in batches)
        {
            b.Grades = Db.GetGradeByPersonandBatchId(this, b.ID);//get grades that the tr teacher
            foreach (var g in b.Grades)
            {
                g.Sections = Db.GetSectionByPersonandGradeId(this, g.ID);//get sections and students and a tr
                foreach (Section s in g.Sections)
                {
                    s.Teachers.Add(Db.GetTeachersByClassId(s.ID).FirstOrDefault(t => t.Name == Name && t.Email == Email));
                    s.Students = Db.GetStudentsByClassId(s.ID);
                }
            }
        }
        return batches;
    }
    public Section GetFullSection(Section section)//final tested
    {
        Section output = new Section { ID = section.ID, Name = section.Name, Students = section.Students };
        output.Teachers = Db.GetTeachersByClassId(section.ID);
        return output;
    }
    public Teacher ShallowCopy()//final tested
    {
        return (Teacher)this.MemberwiseClone();
    }
    public async Task CreateMeeting(Batch batch, Section section, Period period)//final tested
    {
        List <Task> tasks = new List<Task>();
        tasks.Add(Task.Run(() => Db.StorePeriod(period, section.ID)));
        tasks.Add(Task.Run(() => GlobalTools.ShowMeetingInfoOnMessageForm(batch.Name, batch.Grades[0].Name, section, period)));
        if (GlobalTools.Excel == true)
        {
            FileInfo filepath = new FileInfo(Path.Combine(GlobalTools.ExcelPath, $"{batch.Name} {batch.Grades[0].Name} {section.Teachers[0].Name}.xlsx"));
            tasks.Add(Excel.SaveExcelAsync(batch.Name, batch.Grades[0].Name, section, period, filepath));
        }
        await Task.WhenAll(tasks);
    }
    public List<string> GetAllCommands()//final tested
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
