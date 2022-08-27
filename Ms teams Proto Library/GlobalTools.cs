using System.Text;

public static class GlobalTools
{
    public static bool Excel = false;
    public static string ExcelPath { get; set; }
    public const string ReadMeFilePath = @"C:\Users\acer\source\repos\Ms teams bot prototype\Documentation.md";
    public static bool ValidateData(string Name, string Email)
    {
        if (Name.Length <= 0) return false;
        if (Email.Length <= 0 || (Email.EndsWith("@ilbc.edu.mm") == false)) return false;
        return true;
    }
    public static IDBconnection GetDb()
    {
        return new SqlConnector();
    }
    public static ILocalConnection GetLocal()
    {
        return new ExcelConnector();
    }
    public static string GetSpacedName(string name)
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
    public static List<string> GetAllCommands()
    {
        List<string> output = new List<string>();
        output.Add("-Create Batch [BatchName]");
        output.Add("-Create Grade [BatchName] [GradeName]");
        output.Add("-Create Section");
        output.Add("-Create Tr [Name] [BatchName] [GradeName] [SectionName] [Email] [Subject]");
        output.Add("-Create Meeting");
        output.Add("-Create Meeting [SectionName]");
        output.Add("-Create Excel [On/Off]");
        output.Add("-Create Excel [PeriodId]");
        output.Add("-Create Feedback");
        output.Add("-Get Grade [BatchName] [GradeName]");
        output.Add("-Get Section [BatchName] [GradeName] [SectionName]");
        output.Add("-Get Section");
        output.Add("-Get Attendance");
        output.Add("-Get Attendance [BatchName] [GradeName] [SectionName]");
        output.Add("-Get Attendance [BatchName] [GradeName] [SectionName] [Subject]");
        output.Add("-Get Attendance [BatchName] [GradeName] [SectionName] [Name] [Email] [Role]");
        output.Add("-Get Attendance [BatchName] [GradeName] [SectionName] [Subject] [Name] [Email] [Role]");
        output.Add("-Get Attendance [BatchName] [GradeName] [SectionName] [Month_]");
        output.Add("-Get Attendance [BatchName] [GradeName] [SectionName] [Subject] [Month_]");
        output.Add("-Get Attendance [BatchName] [GradeName] [SectionName] [Name] [Email] [Role] [Month_]");
        output.Add("-Get Attendance [BatchName] [GradeName] [SectionName] [Subject] [Name] [Email] [Role] [Month_]");
        output.Add("-Get Help");
        return output;
    }
}