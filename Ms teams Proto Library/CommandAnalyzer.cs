using System.Diagnostics;
public static class CommandAnalyzer
{
    private static IExcuetive Executive { get; set; }
    private static IEducator Educator { get; set; }
    private static IAttendee Attendee { get; set; }

    private static List<Batch> Info = new List<Batch>();

    static string error = "Invalid Arugments or This command needs higher Authority to use" + Environment.NewLine;
    static string nullerror = "The value doesn't exist or is duplicated values" + Environment.NewLine;
    static string successful = "Command Successful!";
    public delegate void makeMeeting(string BatchName, string GradeName, Section section, IEducator educator);
    public static event makeMeeting MakeMeeting;
    public delegate void createSection(List<Batch> batches, IExcuetive excuetive);
    public static event createSection CreateSection; 
    public delegate void createMeeting(List<Batch> batches, IEducator educator);
    public static event createMeeting CreateMeeting;
    public delegate void getAttendence(List<Batch> batches, IAttendee Attendee);
    public static event getAttendence GetAttendence;
    public delegate void getExcelPath();
    public static event getExcelPath GetExcelPath;
    public delegate void getExcelFilePath(string batchName,string gradeName,Section section,Period period,IAttendee attendee);
    public static event getExcelFilePath GetExcelFilePath;
    private static string batchName = "";
    private static string gradeName = "";
    private static Section s;
    public static string Analyze(IAttendee attendee,string command)//final tested
    {
        string[] inputs = command.Trim().Split(" ");
        string comment = "";
        if (inputs[0].ToLower() == "-get" || inputs[0].ToLower() == "-g")
        {
            comment = GetCommands(inputs);
        }
          if ((inputs[0].ToLower() == "-create" || inputs[0].ToLower() == "-c") && inputs.Length >= 2)
        {
            comment = CreateCommands(inputs);
        }
        return comment;
    }
    private static string GetCommands(string[] inputs)//final tested
    {
        switch (inputs[1].ToLower())
        {
            case "grade":
                if (Executive is null || inputs.Length < 4) return error;
                var g = GetGrade(inputs[2], inputs[3]);
                if (!g.status) return nullerror;
                Executive.GetFullSections(g.grade);
                GlobalTools.ShowGradeInfoOnMeetingForm(inputs[2], g.grade);
                break;
            case "section":
                if (Attendee is Student)
                {
                    GlobalTools.ShowSectionInfoOnMeetingForm(Info[0].Name, Info[0].Grades[0].Name, Info[0].Grades[0].Sections[0]);
                    break;
                }
                if (inputs.Length < 5) return error;
                var g_ = GetGrade(inputs[2], inputs[3]);
                if (!g_.status) return nullerror;
                Section? section__ = g_.grade.Sections.FirstOrDefault(x => x.Name.ToString() == inputs[4]);
                if (section__ is null) return nullerror;
                GlobalTools.ShowSectionInfoOnMeetingForm(inputs[2], inputs[3], Attendee.GetFullSection(section__));
                break;
            case "attendance":
                if (inputs.Length < 5)
                {
                    GetAttendence?.Invoke(Info, Attendee);
                    break;
                }
                var g__ = GetGrade(inputs[2], inputs[3]);
                if (!g__.status) return nullerror;
                Section? section_ = g__.grade.Sections.FirstOrDefault(x => x.Name.ToString() == inputs[4]);//get one section
                if (section_ is null) return nullerror;
                if (!Attendee.FurtherAnalyze(inputs, section_) || section_.Periods.Count <= 0) return nullerror;
                foreach (Period pe in section_.Periods)
                {
                    GlobalTools.ShowMeetingInfoOnMessageForm(inputs[2], inputs[3], section_, pe);
                }
                s = new Section { Name = section_.Name, Periods = section_.Periods };
                batchName = inputs[2];
                gradeName = inputs[3];
                break;
            case "help":
                GlobalTools.ShowTextFromDocumentation();
                break;
        }
        return "";
    }
    private static string CreateCommands(string[] inputs)//final tested
    {
        switch (inputs[1].ToLower())
        {
            case "batch":
                if ((Executive is null || inputs.Length < 3) || Info.Any(b => b.Name.ToLower() == inputs[2].ToLower())) return error;
                Info.Add(Executive.CreateBatch(inputs[2]));
                return successful;
            case "grade":
                if (Executive is null || inputs.Length < 4) return error;
                Batch? batch = Info.FirstOrDefault(x => x.Name == inputs[2]);
                if (batch is null || batch.Grades.Any(g => g.Name.ToLower() == inputs[3].ToLower())) return nullerror;
                Executive.CreateGrade(inputs[3], batch);
                return successful;
            case "section":
                if (Executive is null) return error;
                CreateSection?.Invoke(Info, Executive);
                return successful;
            case "tr":
                if (Executive is null || inputs.Length < 8) return error;
                var g = GetGrade(inputs[3], inputs[4]);
                if (!g.status) return nullerror;
                Section? section = g.grade.Sections.FirstOrDefault(x => x.Name.ToString() == inputs[5]);
                if (section is null) return nullerror;
                try { Executive.CreateTeacher(inputs[2], inputs[7], inputs[6], section.ID); }
                catch { return nullerror; }
                return successful;
            case "meeting":
                if (Educator is null) return error;
                if (Info.Count == 1 && Info[0].Grades.Count == 1 && Info[0].Grades[0].Sections.Count == 1)// a tr who teaches in only batch, grade and class
                {
                    MakeMeeting?.Invoke(Info[0].Name, Info[0].Grades[0].Name, Info[0].Grades[0].Sections[0], Educator);
                }
                else if (Info.Count == 1 && Info[0].Grades.Count == 1)// a tr who teaches in only batch and grade
                {
                    if (inputs.Length < 3) return error;
                    Section? section_ = Info[0].Grades[0].Sections.FirstOrDefault(x => x.Name.ToString() == inputs[2]);//get one section
                    if (section_ is null) return nullerror;
                    MakeMeeting?.Invoke(Info[0].Name, Info[0].Grades[0].Name, section_, Educator);
                }
                else
                {
                    CreateMeeting?.Invoke(Info, Educator);
                }
                break;
            case "excel":
                if (inputs.Length < 2) return error;
                if (inputs[2].ToLower() == "on")
                {
                    GlobalTools.Excel = true;
                    GetExcelPath?.Invoke();
                    break;
                }
                if (inputs[2].ToLower() == "off")
                {
                    GlobalTools.Excel = false;
                    return "Auto Excel Disabled";
                }
                Period? p = s.Periods.Where(pe => pe.ID.ToString() == inputs[2]).FirstOrDefault();
                if (p is null) break;
                GetExcelFilePath?.Invoke(batchName, gradeName, s, p, Attendee);
                break;
            case "feedback":
                Process.Start(new ProcessStartInfo("https://suggestionwebsie.netlify.app") { UseShellExecute = true });
                break;
        }
        return "";
    }
    public static (bool status,Grade grade) GetGrade(string batchName,string gradeName)//final tested
    {
        Batch? batch = Info.FirstOrDefault(x => x.Name == batchName);//get one batch
        if (batch is null) return (false, new Grade()); 
        Grade? grade = batch.Grades.FirstOrDefault(x => x.Name == gradeName);//get one grade
        if (grade is null) return (false,new Grade());
        return (true, grade);
    }
    public static void ChooseMode(IAttendee person)//final tested
    {
        Attendee = person; 
        if (person is Teacher t) Educator = t;
        if (person is Administrator a) Executive = a;
        Info = person.GetInfo();
    }
}

