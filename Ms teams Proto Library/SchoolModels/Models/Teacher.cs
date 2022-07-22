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
        List<Task> tasks = new List<Task>();
        tasks.Add(Task.Run(() => Db.StorePeriod(period, section.ID)));
        tasks.Add(Task.Run(() => CommandAnalyzer.ShowMeetingInfoOnMessageForm(batch.Name, batch.Grades[0].Name, section, period)));
        //CommandAnalyzer.ShowMeetingInfoOnMessageForm(batch.Name, batch.Grades[0].Name, section, period)
        tasks.Add(Excel.SaveExcelAsync(batch.Name, batch.Grades[0].Name, section, period));
        await Task.WhenAll(tasks);
    }

    public Section GetFullSection(Grade grade, char sectionName)
    {
        Section? section = Db.GetFullSectionByTeacherNameandGradeId(Name, grade.ID).FirstOrDefault(x => x.Name == sectionName);
        if (section is not null)
        {
            section.Teachers = Db.GetTeachersByClassId(section.ID);
            section.Students = Db.GetStudentsByClassId(section.ID);
        }
        else throw new Exception();
        return section;
    }
}
