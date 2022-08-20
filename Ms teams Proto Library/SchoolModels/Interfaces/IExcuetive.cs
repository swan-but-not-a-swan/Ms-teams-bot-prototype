public interface IExcuetive
{
    Batch CreateBatch(string BatchName);
    void CreateGrade(string GradeName, Batch batch);
    void GetFullSections(Grade grade);
    void CreateSection(Section section, Grade grade);
    void CreateTeacher(string Name, string Email, string subject, int sectionId);
}