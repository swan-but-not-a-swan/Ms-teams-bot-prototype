
using System.Text;

public static class CommandAnalyzer
{
    private static IExcuetive Executive { get; set; }
    private static IEducator Educator { get; set; }
    private static IStudent Student { get; set; }
    private static IAttendee Attendee { get; set; }

    private static List<Batch> Info = new List<Batch>();

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
    private static Section s = new();
    public static string Analyze(IAttendee attendee,string command)
    {
        string[] inputs = command.Trim().Split(" ");
        string comment = "";
        string error = "Invalid Arugments or This command needs higher Authority to use" + Environment.NewLine;
        string nullerror = "The value doesn't exist or is duplicated values" + Environment.NewLine;
        
        if (inputs[0].ToLower() == "-get" || inputs[0].ToLower() == "-g")
        {
            switch (inputs[1].ToLower())
            {
                case "grade":
                    if (Executive is null || inputs.Length < 4) return error;
                    Batch? batch = Info.FirstOrDefault(x => x.Name == inputs[2]);//get one batch
                    if (batch is null) return nullerror;
                    Grade? grade = batch.Grades.FirstOrDefault(x => x.Name == inputs[3]);//get one grade
                    if (grade is null) return nullerror;
                    Executive.GetFullSections(grade);
                    GlobalTools.ShowGradeInfoOnMeetingForm(inputs[2], grade);
                    break;
                case "section":
                    if (Attendee is Student)
                    {
                        GlobalTools.ShowSectionInfoOnMeetingForm(Info[0].Name, Info[0].Grades[0].Name, Info[0].Grades[0].Sections[0]);
                    }
                    else 
                    {
                        if (inputs.Length < 4) return error;
                        Batch? batch__ = Info.FirstOrDefault(x => x.Name == inputs[2]);//get one batch
                        if (batch__ is null) return nullerror;
                        Grade? grade__ = batch__.Grades.FirstOrDefault(x => x.Name == inputs[3]);//get one grade, change here
                        if (grade__ is null) return nullerror;
                        if(char.TryParse(inputs[4], out char sectionName__))
                        {
                            try
                            {
                                Section? section_ = grade__.Sections.FirstOrDefault(x => x.Name == sectionName__);//get one section
                                if (section_ is null) return nullerror;
                                GlobalTools.ShowSectionInfoOnMeetingForm(inputs[2], inputs[3], Attendee.GetFullSection(grade__.ID, section_));
                            }
                            catch { return error; }
                        }
                        else return error;
                    }
                    break;
                case "attendance":
                    if (inputs.Length < 5)
                    {
                        GetAttendence?.Invoke(Info, Attendee);
                        break;
                    }
                    Batch? batch_ = Info.FirstOrDefault(x => x.Name == inputs[2]);//get one batch
                    if (batch_ is null) return nullerror;
                    Grade? grade_ = batch_.Grades.FirstOrDefault(x => x.Name == inputs[3]);
                    if (grade_ is null) return nullerror;
                    if (char.TryParse(inputs[4], out char sectionName))
                    {
                        Section? section_ = grade_.Sections.FirstOrDefault(x => x.Name == sectionName);//get one section
                        if (section_ is null) return nullerror;
                        if(!Attendee.FurtherAnalyze(inputs, section_) || section_.Periods.Count <= 0) return nullerror;
                        foreach (Period pe in section_.Periods)
                        {
                            GlobalTools.ShowMeetingInfoOnMessageForm(batch_.Name, grade_.Name, section_, pe);
                        }
                        s.Name = section_.Name;
                        s.Periods = section_.Periods;
                        batchName = batch_.Name;
                        gradeName = grade_.Name;
                    }
                    else return error;
                    break;
                case "help":
                    GlobalTools.ShowTextFromDocumentation();
                    break;
            }
        }
        if ((inputs[0].ToLower() == "-create" || inputs[0].ToLower() == "-c") && inputs.Length >= 2)
        {
            switch (inputs[1].ToLower())
            {
                case "batch":
                    if ((Executive is null || inputs.Length < 3) || Info.Any(b => b.Name.ToLower() == inputs[2].ToLower())) return error;
                    Info.Add(Executive.CreateBatch(inputs[2]));
                    break;
                case "grade":
                    if (Executive is null || inputs.Length < 4) return error;
                    Batch? batch = Info.FirstOrDefault(x => x.Name == inputs[2]);
                    if (batch is null || batch.Grades.Any(g => g.Name.ToLower() == inputs[3].ToLower())) return nullerror;
                    Executive.CreateGrade(inputs[3], batch);
                    break;
                case "section":
                    if (Executive is null) return error;
                    CreateSection?.Invoke(Info, Executive);
                    break;
                case "meeting":
                    if (Educator is null) return error;
                    if (Info.Count == 1 && Info[0].Grades.Count == 1 && Info[0].Grades[0].Sections.Count == 1)// a tr who teaches in only batch, grade and class
                    {
                        MakeMeeting?.Invoke(Info[0].Name, Info[0].Grades[0].Name, Info[0].Grades[0].Sections[0], Educator);
                    }
                    else if (Info.Count == 1 && Info[0].Grades.Count == 1)// a tr who teaches in only batch and grade
                    {
                        if (inputs.Length < 3) return error;
                        if (char.TryParse(inputs[2], out char sectionName))
                        {
                            Section? section_ = Info[0].Grades[0].Sections.FirstOrDefault(x => x.Name == sectionName);//get one section
                            if (section_ is null) return nullerror;
                            MakeMeeting?.Invoke(Info[0].Name, Info[0].Grades[0].Name, section_, Educator);
                        }
                        else return error;
                    }
                    else
                    {
                        CreateMeeting?.Invoke(Info, Educator);
                    }
                    break;
                case "tr":
                    if (Executive is null || inputs.Length < 8) return error;  
                    Batch? batch_ = Info.FirstOrDefault(x => x.Name == inputs[3]);//get one batch
                    if (batch_ is null) return nullerror;
                    Grade? grade = batch_.Grades.FirstOrDefault(x => x.Name == inputs[4]);//get one grade
                    if (grade is null) return nullerror;
                    if (char.TryParse(inputs[5], out char sectionName_))
                    {
                        Section? section = grade.Sections.FirstOrDefault(x => x.Name == sectionName_);
                        if (section is null) return nullerror;
                        try { Executive.CreateTeacher(inputs[2], inputs[7], inputs[6], section.ID); }
                        catch { return nullerror; }
                    }
                    else return error;
                    break;
                case "excel":
                    if (inputs.Length < 2) return error;
                    if (inputs[2].ToLower() == "on")
                    {
                        GlobalTools.Excel = true;
                        GetExcelPath?.Invoke();
                    }
                    if (inputs[2].ToLower() == "off")
                    {
                        GlobalTools.Excel = false;
                    }
                    if (int.TryParse(inputs[2],out int periodId))
                    {
                        Period? p = s.Periods.Where(pe => pe.ID == periodId).FirstOrDefault();
                        if (p is null) break;
                        GetExcelFilePath?.Invoke(batchName,gradeName,s,p,Attendee);
                    }
                    break;

            }
        }
        return comment;
    }
    public static void ChooseMode(IAttendee person)//refactored and tested
    {
        Attendee = person; 
        if (person is Student s)
            Student = s;
        if (person is Teacher t)
            Educator = t;
        if (person is Administrator a)
            Executive = a;
        Info = person.GetInfo();//gets info
    }
}

