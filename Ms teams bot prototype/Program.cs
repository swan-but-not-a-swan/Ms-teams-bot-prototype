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
            string name = "Tr Moe Thida Tin";
            //CommandAnalyzer.ChooseMode(new Teacher(name, "Trmoe@icloud.com", GlobalTools.GetDb(), GlobalTools.GetLocal()));
            //CommandAnalyzer.ChooseMode(new Teacher(name, "Trmoe@icloud.com", GlobalTools.GetDb(), GlobalTools.GetLocal()));
            CommandAnalyzer.ChooseMode(new Teacher(name, "Trmoe@icloud.com", GlobalTools.GetDb(), GlobalTools.GetLocal()));
            //CommandAnalyzer.ChooseMode(new Student(name, "swan@icloud.com", GlobalTools.GetDb(), GlobalTools.GetLocal()));
            //CommandAnalyzer.ChooseMode(new Student(name, " ", GlobalTools.GetDb(), GlobalTools.GetLocal()));
            //CommandAnalyzer.ChooseMode(new Administrator(name, " ", GlobalTools.GetDb(), GlobalTools.GetLocal()));
            Application.Run(new MessageForm(name));
        }
    }
}