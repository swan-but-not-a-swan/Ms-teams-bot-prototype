public interface ILocalConnection
{
    Task SaveExcelAsync(string BatchName, string GradeName, Section section, Period period);
}