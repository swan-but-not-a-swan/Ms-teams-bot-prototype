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

    public Section GetFullSection(int gradeId, char sectionName)
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
    public override void GetPeriods(string name,string email, string subject, DateTime from, DateTime to, Batch b)
    {
        if (!(name is null || email is null || subject is null))
        {
            List<Period> periods = Db.GetPeriodsWithoutNameEmailSubject(from, to, b.Grades[0].Sections[0].ID);
            if (periods.Count > 0)
            {
                foreach (Period pe in periods)
                {
                    CommandAnalyzer.ShowMeetingInfoOnMessageForm(b.Name, b.Grades[0].Name, b.Grades[0].Sections[0], pe);
                }
            }
        }
    }
}