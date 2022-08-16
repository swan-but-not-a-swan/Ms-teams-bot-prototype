public interface IDBconnection
{
    List<Batch> GetBatches();
    List<Grade> GetGrades(int BatchId);
    List<Section> GetSections(int GradeId);
    List<Batch> GetBatchByTeacherName(string TeacherName);
    List<Grade> GetGradeByTeacherNameandBatchId(string TeacherName, int BatchName);
    List<Section> GetSectionByTeacherNameandGradeId(string TeacherName, int GradeId);
    List<Student> GetStudentsByClassId(int sectionId);
    List<Teacher> GetTeachersByClassId(int sectionId);
    public void GetPersonIntoSection(Section section);
    List<Batch> GetBatchByStudentName(string StudentName);
    List<Grade> GetGradeByStudentNameandBatchId(string StudentName, int BatchId);
    List<Section> GetSectionByStudentNameandGradeId(string StudentName, int GradeId);
    List<Period> GetMeetingInfoWithoutNameandEmail(DateTime from, DateTime to, int sectionId);
    List<Period> GetMeetingInfoWithNameandEmail(DateTime from, DateTime to, int sectionId, string Name, string Email, string Role);
    List<Period> GetMeetingInfoSubjectWithoutNameandEmail(DateTime from, DateTime to, int sectionId, string subject);
    List<Period> GetMeetingInfoSubjectWithNameandEmail(DateTime from, DateTime to, int sectionId, string Name, string Email, string Role, string subject);
    void CreateBatch(Batch batch);
    void CreateGrade(Grade grade, int BatchId);
    void CreateSection(Section section, int GradeId);
    void StorePeriod(Period period, int SectionId);
    void CreateTeacher(Teacher teacher, int sectionId);
}