using System.Text;

public static class GlobalTools
{
    public static bool Excel { get; set; } = false;
    public static string ExcelPath { get; set; }
    public const string ReadMeFilePath = @"C:\Users\acer\source\repos\Ms teams bot prototype\Documentation.md";

    public delegate void showText(string comment);
    public static event showText ShowText;
    public static bool ValidateData(string Name, string Email)//final tested
    {
        if (Name.Length <= 0) return false;
        if (Email.Length <= 0 || (Email.EndsWith("@ilbc.edu.mm") == false)) return false;
        return true;
    }
    public static string GetSpacedName(string name)//final tested
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < name.Length; i++)
        {
            if (char.IsUpper(name[i]))
            {
                sb.Append(" ");
            }
            sb.Append(name[i]);
        }
        return sb.ToString().Trim();
    }
    public static void ShowTextFromDocumentation()//final tested
    {
        var lines = File.ReadAllLines(GlobalTools.ReadMeFilePath);
        StringBuilder text = new();
        for (int i = 0; i < lines.Length; i++)
        {
            text.AppendLine(lines[i]);
        }
        ShowText?.Invoke(text.ToString());
    }
    public static void ShowMeetingInfoOnMessageForm(string BatchName, string GradeName, Section section, Period period)//final tested
    {
        StringBuilder info = new StringBuilder();
        info.AppendLine($"ID : {period.ID} {period.StartTime.ToShortDateString()} {BatchName} {GradeName} {section.Name} " +
                    $"{period.Subject} {period.StartTime.ToShortTimeString()} - {period.EndTime.ToShortTimeString()}");
        foreach (var a in period.Attendees)
        {
            info.AppendLine($"ID:{a.ID} Name:{a.Name} JoinTime:{(a.JoinTime.HasValue ? a.JoinTime.GetValueOrDefault().ToShortTimeString() : "null")} " +
                $"LeaveTime:{(a.LeaveTime.HasValue ? a.LeaveTime.GetValueOrDefault().ToShortTimeString() : "null")}" +
                $" Duration:{a.Duration.GetValueOrDefault().Hours}:{a.Duration.GetValueOrDefault().Minutes}:{a.Duration.GetValueOrDefault().Seconds} Status:{a.Status}");
        }
        ShowText?.Invoke(info.ToString());
    }
    public static void ShowGradeInfoOnMeetingForm(string BatchName, Grade grade)//final tested
    {
        StringBuilder info = new StringBuilder();
        info.AppendLine($"{BatchName} {grade.Name}");
        foreach (var s in grade.Sections)
        {
            info.AppendLine($"{s.Name} Class, Teachers : {s.Teachers.Count} Students : {s.Students.Count}");
        }
        ShowText?.Invoke(info.ToString());
    }
    public static void ShowSectionInfoOnMeetingForm(string BatchName, string gradeName, Section section)//final tested
    {
        StringBuilder info = new StringBuilder();
        info.AppendLine($"{BatchName} {gradeName} {section.Name}");
        foreach (var t in section.Teachers)
        {
            info.AppendLine($"Name : {t.Name}, Email : {t.Email}, Subject : {t.Subject}");
        }
        foreach (var s in section.Students)
        {
            info.AppendLine($"Name : {s.Name}, Email : {s.Email}");
        }
        ShowText?.Invoke(info.ToString());
    }
}