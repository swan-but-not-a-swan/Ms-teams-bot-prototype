using System.Configuration;
using System.Data;
using Dapper;
public class SqlConnector : IDBconnection
{
    private const string name = "Ms teams Bot Prototype";
    private string CnnString = ConfigurationManager.ConnectionStrings[name].ConnectionString;//gets string cnnstring
    public List<Batch> GetBatches()//refactored and tested
    {
        List<Batch> output = new List<Batch>();
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnString))
        {
            output = connection.Query<Batch>("GetBatch", commandType: CommandType.StoredProcedure).ToList();
        }
        return output;
    }
    public List<Grade> GetGrades(int BatchId)//refactored and tested
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
    public List<Section> GetSections(int GradeId)//refactored and tested
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
    public List<Batch> GetBatchByTeacherName(string TeacherName)//refactored and tested
    {
        List<Batch> output = new List<Batch>();
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnString))
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@TeacherName", TeacherName);
            output = connection.Query<Batch>("dbo.GetBatchByTeacherName", p, commandType: CommandType.StoredProcedure).ToList();
        }
        return output;
    }
    public List<Grade> GetGradeByTeacherNameandBatchId(string TeacherName, int BatchId)//refactored and tested
    {
        List<Grade> output = new List<Grade>();
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnString))
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@TeacherName", TeacherName);
            p.Add("@BatchId", BatchId);
            output = connection.Query<Grade>("dbo.GetGradeByTeacherNameandBatchId", p, commandType: CommandType.StoredProcedure).ToList();
        }
        return output;
    }
    public List<Section> GetSectionByTeacherNameandGradeId(string TeacherName, int GradeId)
    {
        List<Section> sections = new List<Section>();
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnString))
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@TeacherName", TeacherName);
            p.Add("@GradeId", GradeId);
            sections = connection.Query<Section>("GetClassByTeacherNameandGradeId", p, commandType: CommandType.StoredProcedure).ToList();
        }
        return sections;
    }
    public List<Student> GetStudentsByClassId(int sectionId)
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
    public List<Teacher> GetTeachersByClassId(int sectionId)
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

    public void GetPersonIntoSection(Section section)
    {
        if (section is not null)
        {
            section.Teachers = GetTeachersByClassId(section.ID);
            section.Students = GetStudentsByClassId(section.ID);
        }
        else throw new Exception();
    }
    public List<Batch> GetBatchByStudentName(string StudentName)
    {
        List<Batch> output = new List<Batch>();
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnString))
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@StudentName", StudentName);
            output = connection.Query<Batch>("dbo.GetBatchByStudentName", p, commandType: CommandType.StoredProcedure).ToList();
        }
        return output;
    }
    public List<Grade> GetGradeByStudentNameandBatchId(string StudentName, int BatchId)
    {
        List<Grade> output = new List<Grade>();
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnString))
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@StudentName", StudentName);
            p.Add("@BatchId", BatchId);
            output = connection.Query<Grade>("dbo.GetGradeByStudentNameandBatchId", p, commandType: CommandType.StoredProcedure).ToList();
        }
        return output;
    }
    public List<Section> GetSectionByStudentNameandGradeId(string StudentName, int GradeId)
    {
        List<Section> section = new List<Section>();
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnString))
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@StudentName", StudentName);
            p.Add("@GradeId", GradeId);
            section = connection.Query<Section>("GetClassByStudentNameandGradeId", p, commandType: CommandType.StoredProcedure).ToList();
            section[0].Teachers = GetTeachersByClassId(section[0].ID);
            section[0].Students = GetStudentsByClassId(section[0].ID); 
        }
        return section;
    }
    public List<Period> GetPeriods(DateTime from, DateTime to, int sectionId)
    {
        List<Period> periods = new List<Period>();
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnString))
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@from", from);
            p.Add("@to", to);
            p.Add("@classId", sectionId);
            periods = connection.Query<Period>("GetPeriodsWithoutNameEmailSubject", p, commandType: CommandType.StoredProcedure).ToList();
        }
        return periods;
    }
    public List<Period> GetMeetingInfoWithoutNameandEmail(DateTime from, DateTime to, int sectionId)
    {
        List<Period> periods = GetPeriods(from, to, sectionId);
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnString))
        {
            if (periods.Count > 0)
            {
                foreach (Period pe in periods)
                {
                    DynamicParameters p = new DynamicParameters();
                    p.Add("@PeriodId", pe.ID);
                    var t = connection.Query<Teacher>("GetTeachersWithPeriodId", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    pe.Attendees.Insert(0, t);
                    pe.Attendees.AddRange(connection.Query<Student>("GetStudentsWithPeriodId", p, commandType: CommandType.StoredProcedure));
                }
            }
        }
        return periods;
    }
    public List<Period> GetMeetingInfoSubjectWithoutNameandEmail(DateTime from, DateTime to, int sectionId,string subject)
    {
        List<Period> periods = GetPeriods(from, to, sectionId).Where(pe => pe.Subject.ToString() == subject).ToList();
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnString))
        {
            if (periods.Count > 0)
            {
                foreach (Period pe in periods)
                {
                    DynamicParameters p = new DynamicParameters();
                    p.Add("@PeriodId", pe.ID);
                    var t = connection.Query<Teacher>("GetTeachersWithPeriodId", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    pe.Attendees.Insert(0, t);
                    pe.Attendees.AddRange(connection.Query<Student>("GetStudentsWithPeriodId", p, commandType: CommandType.StoredProcedure));
                }
            }
        }
        return periods;
    }
    public List<Period> GetPeriodsWithNameandEmail(DateTime from, DateTime to, int sectionId,string Name,string Email,string Role)
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
    public List<Period> GetMeetingInfoWithNameandEmail(DateTime from, DateTime to, int sectionId,string Name,string Email,string Role)
    {
        List<Period> periods = GetPeriodsWithNameandEmail(from, to, sectionId,Name,Email,Role);
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnString))
        {
            IAttendee s;
            if (periods.Count > 0)
            {
                foreach (Period pe in periods)
                {
                    DynamicParameters p = new DynamicParameters();
                    p.Add("@PeriodId", pe.ID);   
                    if (Role == "Teacher")
                        s = connection.Query<Teacher>("GetTeachersWithPeriodId", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    else
                        s = connection.Query<Student>("GetStudentsWithPeriodId", p, commandType: CommandType.StoredProcedure).FirstOrDefault(s => s.Name == Name && s.Email == Email);
                    pe.Attendees.Insert(0, s);
                }
            }
        }
        return periods;
    }
    public List<Period> GetMeetingInfoSubjectWithNameandEmail(DateTime from, DateTime to, int sectionId, string Name, string Email, string Role,string subject)
    {
        List<Period> periods = GetPeriodsWithNameandEmail(from, to, sectionId, Name, Email, Role).Where(pe => pe.Subject.ToString() == subject).ToList();
        using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnString))
        {
            IAttendee s;
            if (periods.Count > 0)
            {
                foreach (Period pe in periods)
                {
                    DynamicParameters p = new DynamicParameters();
                    p.Add("@PeriodId", pe.ID);
                    if (Role == "Teacher")
                        s = connection.Query<Teacher>("GetTeachersWithPeriodId", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    else
                        s = connection.Query<Student>("GetStudentsWithPeriodId", p, commandType: CommandType.StoredProcedure).FirstOrDefault(s => s.Name == Name && s.Email == Email);
                    pe.Attendees.Insert(0, s);
                }
            }
        }
        return periods;
    }
    public void CreateBatch(Batch batch)//refactored and tested
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
    public void CreateGrade(Grade grade, int BatchId)//refactord and tested
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
    public void CreateSection(Section section, int GradeId)
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
                p = new DynamicParameters();
                p.Add("@id", 0, DbType.Int32, ParameterDirection.Output);
                p.Add("@Name", s.Name);
                p.Add("@Email", s.Email);
                p.Add("@ClassId", section.ID);
                connection.Execute("dbo.CreateStudent", p, commandType: CommandType.StoredProcedure);
                s.ID = p.Get<int>("@id");
            }
        }
    }
    public void StorePeriod(Period period, int SectionId)//refactored and tested
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
    public void CreateTeacher(Teacher teacher, int sectionId)
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
}