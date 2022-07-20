using System.Text;

public static class GlobalTools
{
    public static bool Excel = false;
    public static string ExcelPath { get; set; }
    public static bool ValidateData(string Name, string Email)//refactored and tested
    {
        bool output = true;
        if (Name.Length <= 0)
        {
            output = false;
        }
        if (Email.Length <= 0 || (Email.Contains("@") == false))
        {
            output = false;
        }
        return output;
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
}