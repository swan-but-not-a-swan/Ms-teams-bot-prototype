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
            string name = "Swan Sett Aung";
            //string name = "Swan Sett Aung";
            //CommandAnalyzer.ChooseMode(new Teacher(name, "Trmoe@icloud.com", GlobalTools.GetDb(), GlobalTools.GetLocal()));
            //CommandAnalyzer.ChooseMode(new Student(name, "Swan@ilbc.edu.mm", GlobalTools.GetDb(), GlobalTools.GetLocal()));
            //CommandAnalyzer.ChooseMode(new Administrator(name, " ", GlobalTools.GetDb(), GlobalTools.GetLocal()));
            //Application.Run(new MessageForm(new Teacher(name, "Trmoe@icloud.com", GlobalTools.GetDb(), GlobalTools.GetLocal())));
            //Application.Run(new MessageForm(new Student(name, "Swan@ilbc.edu.mm", GlobalTools.GetDb(), GlobalTools.GetLocal())));
            Application.Run(new MessageForm(new Administrator(name, " ", GlobalTools.GetDb(), GlobalTools.GetLocal())));
        }
    }
}