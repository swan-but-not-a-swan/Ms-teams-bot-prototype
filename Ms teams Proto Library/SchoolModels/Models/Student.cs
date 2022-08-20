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
    public override void GetPeriods(string batchName, string GradeName, string name, string email, string subject, string Role, DateTime from, DateTime to, Batch b, Section section)
    {
        if (subject.Length <= 0)
        {
            List<Period> periods = Db.GetMeetingInfoWithNameandEmail(from, to, b.Grades[0].Sections[0].ID, name, email, Role);
            if (periods.Count > 0)
            {
                foreach (Period pe in periods)
                {
                    CommandAnalyzer.ShowMeetingInfoOnMessageForm(b.Name, b.Grades[0].Name, b.Grades[0].Sections[0], pe);
                }
            }
        }
        else
        {
            List<Period> periods = Db.GetMeetingInfoSubjectWithNameandEmail(from, to, b.Grades[0].Sections[0].ID, name, email, Role, subject);
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