public class Administrator : Person, IAttendee, IExcuetive
{
    public Administrator(string name, string email, IDBconnection db, ILocalConnection local)
    {
        Name = name;
        Email = email;
        Db = db;
        Excel = local;
    }
    public List<Batch> GetInfo()//final tested
    {
        List<Batch> batches = Db.GetBatches();
        foreach (var b in batches)
        {
            b.Grades = Db.GetGrades(b.ID);
            foreach(Grade g in b.Grades )
            {
                 g.Sections = Db.GetSections(g.ID);
            }
        }
        return batches;
    }
    public Section GetFullSection(Section section)//final tested
    {
        Section output = new Section { ID = section.ID, Name = section.Name };
        Db.GetPersonIntoSection(output);
        return output;
    }
    public Batch CreateBatch(string BatchName)//final tested
    {
        Batch output = new();
        output.Name = BatchName;
        Db.CreateBatch(output);
        return output;
    }
    public void CreateGrade(string GradeName, Batch batch)//final tested
    {
        Grade grade = new();
        grade.Name = GradeName;
        Db.CreateGrade(grade, batch.ID);
        batch.Grades.Add(grade);
    }
    public void GetFullSections(Grade grade)//final tested 
    {
        foreach(var s in grade.Sections)
        {
            Db.GetPersonIntoSection(s);
        }
        grade.Sections.OrderBy(s => s.Name).ToList();
    }
    public void CreateSection(Section section, Grade grade)//final tested
    {
        Db.CreateSection(section, grade.ID);
        grade.Sections.Add(section);
    }
    public void CreateTeacher(string Name, string Email, string subject, int sectionID)//final tested
    {
        string name = GlobalTools.GetSpacedName(Name);
        Teacher? teacher = Db.GetTeachersByClassId(sectionID).FirstOrDefault(t => t.Name == $"Tr {name}" && t.Email == Email);
        bool validate = Email.StartsWith("Tr") && Email.EndsWith("@ilbc.edu.mm");
        if (teacher is not null || (validate == false)) throw new Exception();
        teacher = new Teacher { Name = $"Tr {name}", Email = Email, Subject = (Subjects)Enum.Parse(typeof(Subjects), subject) };
        Db.CreateTeacher(teacher, sectionID);
    }
    public List<string> GetAllCommands()//final tested
    {
        List<string> output = new List<string>();
        output.Add("-Create Batch [BatchName]");
        output.Add("-Create Grade [BatchName] [GradeName]");
        output.Add("-Create Section");
        output.Add("-Create Tr [Name] [BatchName] [GradeName] [SectionName] [Email] [Subject]");
        output.Add("-Create Excel [PeriodId]");
        output.Add("-Create Feedback");
        output.Add("-Get Grade [BatchName] [GradeName]");
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
