public interface IExcuetive
{
    Batch CreateBatch(string BatchName);
    Grade CreateGrade(string GradeName, int batchId);
    List<Section> GetSections(int gradeId);
    List<Section> GetFullSections(int gradeId);
    void CreateSection(Section section, int gradeId);
    void CreateTeacher(string Name, string Email, string subject, int sectionId);
}