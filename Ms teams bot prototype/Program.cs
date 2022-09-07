using OfficeOpenXml;
namespace Ms_teams_bot_prototype
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application. 
        /// </summary>
        [STAThread]
        private static void Main()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ApplicationConfiguration.Initialize();
            string name = "Tr Aye Aye Aung";
            Application.Run(new MessageForm(new Teacher(name, "TrAye@ilbc.edu.mm", new SqlConnector(), new ExcelConnector())));
           // Application.Run(new MessageForm(new Student(name, "Chit@ilbc.edu.mm", new SqlConnector(), new ExcelConnector())));
            //Application.Run(new MessageForm(new Administrator(name, " ", new SqlConnector(), new ExcelConnector())));
        }
    }
}