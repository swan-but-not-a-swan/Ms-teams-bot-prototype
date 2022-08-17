public interface IExcuetive
{
    Batch CreateBatch(string BatchName);
    void CreateGrade(string GradeName, Batch batch);
    List<Section> GetSections(int gradeId);
    List<Section> GetFullSections(int gradeId);
    void CreateSection(Section section, int gradeId);
    void CreateTeacher(string Name, string Email, string subject, int sectionId);
}