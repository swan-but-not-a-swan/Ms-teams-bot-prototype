using System.Configuration;
using System.Data;
using Dapper;
public class SqlConnector : IDBconnection
{
    private const string name = "Ms teams Bot Prototype";
    private string CnnString = ConfigurationManager.ConnectionStrings[name].ConnectionString;//gets string cnnstring
    public List<Batch> GetBatches()//final tested
    {
        List<Batch> output = new List<Batch>();
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnString))
        {
            output = connection.Query<Batch>("GetBatch", commandType: CommandType.StoredProcedure).ToList();
        }
        return output;
    }
    public List<Grade> GetGrades(int BatchId)//final tested
    {
        List<Grade> output = new List<Grade>();
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnString))
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@BatchID", BatchId);
            output = connection.Query<Grade>("dbo.GetGrade", p, commandType: CommandType.StoredProcedure).ToList();
        }
        return output;
    }
    public List<Section> GetSections(int GradeId)//final tested
    {
        List<Section> output = new List<Section>();
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnString))
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@GradeId", GradeId);
            output = connection.Query<Section>("dbo.GetSections", p, commandType: CommandType.StoredProcedure).ToList();
        }
        return output;
    }
    public List<Batch> GetBatchByPerson(IAttendee attendee)//final tested
    {
        List<Batch> output = new List<Batch>();
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnString))
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@Name", attendee.Name);
            p.Add("@Email", attendee.Email);
            p.Add("@Role", attendee is Teacher ? "Teacher" : "Student");
            output = connection.Query<Batch>("dbo.GetBatchByPerson", p, commandType: CommandType.StoredProcedure).ToList();
        }
        return output;
    }
    public List<Grade> GetGradeByPersonandBatchId(IAttendee attendee, int BatchId)//final tested
    {
        List<Grade> output = new List<Grade>();
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnString))
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@Name",attendee.Name);
            p.Add("@Email", attendee.Email);
            p.Add("@BatchId", BatchId);
            p.Add("@Role", attendee is Teacher ? "Teacher" : "Student");
            output = connection.Query<Grade>("dbo.GetGradeByPersonandBatchId", p, commandType: CommandType.StoredProcedure).ToList();
        }
        return output;
    }
    public List<Section> GetSectionByPersonandGradeId(IAttendee attendee, int GradeId)//final tested
    {
        List<Section> sections = new List<Section>();
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnString))
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@Name", attendee.Name);
            p.Add("@Email", attendee.Email);
            p.Add("@GradeId", GradeId);
            p.Add("@Role", attendee is Teacher ? "Teacher" : "Student");
            sections = connection.Query<Section>("GetSectionByPersonandGradeId", p, commandType: CommandType.StoredProcedure).ToList();
        }
        return sections;
    }
    public List<Student> GetStudentsByClassId(int sectionId)//final tested
    {
        List<Student> output = new List<Student>();
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnString))
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@ClassId", sectionId );
            output = connection.Query<Student>("dbo.GetStudentByClassId", p, commandType: CommandType.StoredProcedure).ToList();
        }
        return output;
    }
    public List<Teacher> GetTeachersByClassId(int sectionId)//final tested
    {
        List<Teacher> output = new List<Teacher>();
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnString))
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@ClassId", sectionId);
            output = connection.Query<Teacher>("dbo.GetTeacherByClassId", p, commandType: CommandType.StoredProcedure).ToList();
        }
        return output;
    }
    public void GetPersonIntoSection(Section section)//final tested
    {
        if (section is null) throw new Exception();
        section.Teachers = GetTeachersByClassId(section.ID);
        section.Students = GetStudentsByClassId(section.ID);
    }
    public List<Period> GetPeriods(DateTime from, DateTime to, int sectionId)//final tested
    {
        List<Period> periods = new List<Period>();
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnString))
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@from", from);
            p.Add("@to", to);
            p.Add("@classId", sectionId);
            periods = connection.Query<Period>("GetPeriods", p, commandType: CommandType.StoredProcedure).ToList();
        }
        return periods;
    }
    public void GetAttendess(List<Period> periods)//final tested
    {
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnString))
        {
            if (periods.Count <= 0) return;
            foreach (Period pe in periods)
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@PeriodId", pe.ID);
                var t = connection.Query<Teacher>("GetTeachersByPeriodId", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
                pe.Attendees.Insert(0, t);
                pe.Attendees.AddRange(connection.Query<Student>("GetStudentsByPeriodId", p, commandType: CommandType.StoredProcedure).OrderByDescending(a => a.Status));
            }
        }
    }
    public List<Period> GetPeriodsWithNameandEmail(DateTime from, DateTime to, int sectionId,string Name,string Email,string Role)//final tested
    {
        List<Period> periods = new List<Period>();
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnString))
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@from", from);
            p.Add("@to", to);
            p.Add("@classId", sectionId);
            p.Add("@Name", Name);
            p.Add("@Email", Email);
            p.Add("@Role",Role);
            periods = connection.Query<Period>("GetPeriodsWithNameEmail", p, commandType: CommandType.StoredProcedure).ToList();
        }
        return periods;
    }
    public void GetAttendeesWithNameandEmail(List<Period> periods,string Name,string Email,string Role)//final tested
    {
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnString))
        {
            IAttendee s;
            if (periods.Count <= 0) return;
            foreach (Period pe in periods)
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@PeriodId", pe.ID);
                if (Role == "Teacher")
                    s = connection.Query<Teacher>("GetTeachersByPeriodId", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
                else
                    s = connection.Query<Student>("GetStudentsByPeriodId", p, commandType: CommandType.StoredProcedure).FirstOrDefault(s => s.Name == Name && s.Email == Email);
                pe.Attendees.Insert(0, s);
            }
        }
    }
    public void CreateBatch(Batch batch)//final tested
    {
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnString))
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@id", 0, DbType.Int32, ParameterDirection.Output);
            p.Add("@BatchName", batch.Name);
            connection.Execute("dbo.CreateBatch", p, commandType: CommandType.StoredProcedure);
            batch.ID = p.Get<int>("@id");
        }
    }
    public void CreateGrade(Grade grade, int BatchId)//final tested
    {
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnString))
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@id", 0, DbType.Int32, ParameterDirection.Output);
            p.Add("@GradeName", grade.Name);
            p.Add("@BatchId", BatchId);
            connection.Execute("dbo.CreateGrade", p, commandType: CommandType.StoredProcedure);
            grade.ID = p.Get<int>("@id");
        }
    }
    public void CreateSection(Section section, int GradeId)//final tested
    {
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnString))
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@id", 0, DbType.Int32, ParameterDirection.Output);
            p.Add("@SectionName", section.Name);
            p.Add("@GradeId", GradeId);
            connection.Execute("dbo.CreateSection", p, commandType: CommandType.StoredProcedure);
            section.ID = p.Get<int>("@id");
            foreach (var t in section.Teachers)
            {
                CreateTeacher(t, section.ID);
            }
            foreach (var s in section.Students)
            {
                CreateStudent(s, section.ID);
            }
        }
    }
    public void StorePeriod(Period period, int SectionId)//final tested
    {
        using (IDbConnection connetion = new System.Data.SqlClient.SqlConnection(CnnString))
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@id", 0, DbType.Int32, ParameterDirection.Output);
            p.Add("@StartTime", period.StartTime);
            p.Add("@EndTime", period.EndTime);
            p.Add("@Subject", period.Subject.ToString());
            p.Add("@ClassId", SectionId);
            connetion.Execute("dbo.StorePeriod", p, commandType: CommandType.StoredProcedure);
            period.ID = p.Get<int>("@id");
            foreach (var a in period.Attendees)
            {
                p = new DynamicParameters();
                p.Add("@StudentandTeacherId", a.ID);
                p.Add("@JoinTime", a.JoinTime);
                p.Add("@LeaveTime", a.LeaveTime);
                p.Add("@Duration", a.Duration);
                p.Add("@Status", a.Status);
                if (a is Student) p.Add("@Role", "Student");
                if (a is Teacher) p.Add("@Role", "Teacher");
                p.Add("PeriodId", period.ID);
                connetion.Execute("dbo.StoreParticipant", p, commandType: CommandType.StoredProcedure);
            }
        }
    }
    public void CreateTeacher(Teacher teacher, int sectionId)//final tested
    {
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnString))
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@id", 0, DbType.Int32, ParameterDirection.Output);
            p.Add("@Name", teacher.Name);
            p.Add("@Email", teacher.Email);
            p.Add("@Subject", teacher.Subject.ToString());
            p.Add("@ClassId", sectionId);
            connection.Execute("dbo.CreateTeacher", p, commandType: CommandType.StoredProcedure);
            teacher.ID = p.Get<int>("@id");
        }
    }
    public void CreateStudent(Student student,int sectionId)//final tested
    {
        using(IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnString))
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@id", 0, DbType.Int32, ParameterDirection.Output);
            p.Add("@Name", student.Name);
            p.Add("@Email", student.Email);
            p.Add("@ClassId", sectionId);
            connection.Execute("dbo.CreateStudent", p, commandType: CommandType.StoredProcedure);
            student.ID = p.Get<int>("@id");
        }
    }
}