public interface IDBconnection
{
    List<Batch> GetBatches();
    List<Grade> GetGrades(int BatchId); 
    List<Section> GetSections(int GradeId);
    public List<Batch> GetBatchByPerson(IAttendee attendee);
    List<Grade> GetGradeByPersonandBatchId(IAttendee attendee, int BatchId);
    List<Section> GetSectionByPersonandGradeId(IAttendee attendee, int GradeId);
    List<Student> GetStudentsByClassId(int sectionId);
    List<Teacher> GetTeachersByClassId(int sectionId);
    public void GetPersonIntoSection(Section section);
    List<Period> GetPeriods(DateTime from, DateTime to, int sectionId);
    void GetAttendess(List<Period> periods);
    List<Period> GetPeriodsWithNameandEmail(DateTime from, DateTime to, int sectionId, string Name, string Email, string Role);
    void GetAttendeesWithNameandEmail(List<Period> periods, string Name, string Email, string Role);
    void CreateBatch(Batch batch);
    void CreateGrade(Grade grade, int BatchId);
    void CreateSection(Section section, int GradeId);
    void StorePeriod(Period period, int SectionId);
    void CreateTeacher(Teacher teacher, int sectionId);
}