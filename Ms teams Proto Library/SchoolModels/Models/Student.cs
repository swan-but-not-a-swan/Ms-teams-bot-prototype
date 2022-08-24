﻿public class Student : Person, IAttendee, IStudent
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
    public override void GetPeriods(string batchName, string GradeName, string name , string email, string subject, string Role, DateTime from, DateTime to, Section section)
    {
        if (subject.Length <= 0)
        {
            section.Periods = Db.GetMeetingInfoWithNameandEmail(from, to, section.ID, Name, Email, "Student");
            if (section.Periods.Count > 0)
            {
                foreach (Period pe in section.Periods)
                {
                    CommandAnalyzer.ShowMeetingInfoOnMessageForm(batchName, GradeName, section, pe);
                }
            }
        }
        else
        {
            section.Periods = Db.GetMeetingInfoSubjectWithNameandEmail(from, to, section.ID, Name, Email, Role, subject);
            if (section.Periods.Count > 0)
            {
                foreach (Period pe in section.Periods)
                {
                    CommandAnalyzer.ShowMeetingInfoOnMessageForm(batchName, GradeName,section, pe);
                }
            }
        }
    }
}