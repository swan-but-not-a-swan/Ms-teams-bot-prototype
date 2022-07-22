public class Administrator : Person, IAttendee, IExcuetive
{
    public Administrator(string name, string email, IDBconnection db, ILocalConnection local)//refactored and tested
    {
        Name = name;
        Email = email;
        Db = db;
        Excel = local;
    }
    public List<Batch> GetInfo()//refactored and tested
    {
        List<Batch> batches = Db.GetBatches();//get all the batches
        foreach (var b in batches)
        {
            b.Grades = Db.GetGrades(b.ID);//get all the grades in a certain batch
        }
        return batches;
    }
    public Batch CreateBatch(string BatchName)//refactored and tested
    {
        Batch output = new Batch();
        output.Name = BatchName;
        Db.CreateBatch(output);
        return output;
    }
    public Grade CreateGrade(string GradeName, int BatchId)//refactored and tested
    {
        Grade output = new Grade();
        output.Name = GradeName;
        Db.CreateGrade(output, BatchId);
        return output;
    }
    public List<Section> GetSections(int gradeId)//refactored and tested
    {
        return Db.GetSections(gradeId);
    }
    public List<Section> GetFullSections(int gradeId)//refactored and tested
    {
        List<Section> sections= GetSections(gradeId);
        foreach(var s in sections)
        {
            s.Teachers = Db.GetTeachersByClassId(s.ID);
            s.Students = Db.GetStudentsByClassId(s.ID);
        }
        return sections;
    }
    public void CreateSection(Section section, int gradeId)//refactored and tested
    {
        Db.CreateSection(section, gradeId);
    }
    public void CreateTeacher(string Name, string Email, string subject, int sectionId)
    {
        string name = GlobalTools.GetSpacedName(Name);
        Teacher? teacher = Db.GetTeachersByClassId(sectionId).FirstOrDefault(t => t.Name == Name);
        if (teacher is null && Email.Contains("@"))//check whether a teacher is null and email has @
        {
            teacher = new Teacher { Name = $"Tr {name}", Email = Email, Subject = (Subjects)Enum.Parse(typeof(Subjects), subject) };
            Db.CreateTeacher(teacher, sectionId);
        }
        else throw new Exception();
    }

    public Section GetFullSection(Grade grade, char sectionName)
    {
        Section? section = GetSections(grade.ID).FirstOrDefault(x => x.Name == sectionName);
        if (section is not null)
        {
            section.Teachers = Db.GetTeachersByClassId(section.ID);
            section.Students = Db.GetStudentsByClassId(section.ID);
        }
        else throw new Exception();
        return section;
    }
}
