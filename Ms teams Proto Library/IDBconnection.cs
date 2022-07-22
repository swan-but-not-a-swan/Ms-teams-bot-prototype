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
    List<Batch> GetBatchByStudentName(string StudentName);
    List<Grade> GetGradeByStudentNameandBatchId(string StudentName, int BatchId);
    List<Section> GetSectionByStudentNameandGradeId(string StudentName, int GradeId);
    List<Section> GetFullSectionByTeacherNameandGradeId(string TeacherName, int GradeId);
    void CreateBatch(Batch batch);
    void CreateGrade(Grade grade, int BatchId);
    void CreateSection(Section section, int GradeId);
    void StorePeriod(Period period, int SectionId);
    void CreateTeacher(Teacher teacher, int sectionId);
}