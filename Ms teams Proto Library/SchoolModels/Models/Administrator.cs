public class Administrator : Person, IAttendee, IExcuetive
{
    public Administrator(string name, string email, IDBconnection db, ILocalConnection local)//refactored and tested
    {
        Name = name;
        Email = email;
        Db = db;
        Excel = local;
    }
    public List<Batch> GetInfo()
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
    public Batch CreateBatch(string BatchName)//refactored and tested
    {
        Batch output = new Batch();
        output.Name = BatchName;
        Db.CreateBatch(output);
        return output;
    }
    public void CreateGrade(string GradeName, Batch batch)
    {
        Grade grade = new Grade();
        grade.Name = GradeName;
        Db.CreateGrade(grade, batch.ID);
        batch.Grades.Add(grade);
    }
    public void GetFullSections(Grade grade) 
    {
        foreach(var s in grade.Sections)
        {
            Db.GetPersonIntoSection(s);
        }
        grade.Sections.OrderBy(s => s.Name).ToList();
    }
    public void CreateSection(Section section, Grade grade)//refactored and tested
    {
        Db.CreateSection(section, grade.ID);
        grade.Sections.Add(section);
    }
    public void CreateTeacher(string Name, string Email, string subject, int sectionID)
    {
        string name = GlobalTools.GetSpacedName(Name);
        Teacher? teacher = Db.GetTeachersByClassId(sectionID).FirstOrDefault(t => t.Name == $"Tr {name}");
        bool validate = GlobalTools.ValidateData(Name, Email) && Email.StartsWith("Tr");
        if (teacher is null && validate)//check whether a teacher is null and email has @
        {
            teacher = new Teacher { Name = $"Tr {name}", Email = Email, Subject = (Subjects)Enum.Parse(typeof(Subjects), subject) };
            Db.CreateTeacher(teacher, sectionID);
        }
        else throw new Exception();
    }
    //public List<Period> 
}
