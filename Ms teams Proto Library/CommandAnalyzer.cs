
using System.Text;

public static class CommandAnalyzer
{
    private static string Command { get; set; }
    private static IExcuetive Excuetive { get; set; }
    private static IEducator Educator { get; set; }
    private static IStudent Student { get; set; }
    private static IAttendee Attendee { get; set; }

    private static List<Batch> Info = new List<Batch>();

    public delegate void makeMeeting(string BatchName, string GradeName, Section section, IEducator educator);
    public static event makeMeeting MakeMeeting;
    public delegate void showText(string comment);
    public static event showText ShowText;
    public delegate void createSection(List<Batch> batches, IExcuetive excuetive);
    public static event createSection CreateSection;
    public delegate void createMeeting(List<Batch> batches, IEducator educator);
    public static event createMeeting CreateMeeting;
    public delegate void getAttendence(List<Batch> batches, IAttendee Attendee);
    public static event getAttendence GetAttendence;
    public delegate void getExcelPath();
    public static event getExcelPath GetExcelPath;
    public static string Analyze(string command)
    {
        Validation();
        Command = command;
        string[] inputs = Command.Split(" ");
        string comment = "";
        string error = "Invalid Arugments or This command needs higher Authority to use" + Environment.NewLine;
        string nullerror = "The value doesn't exist or is duplicated values" + Environment.NewLine;
        if (inputs[0].ToLower() == "-get" || inputs[0].ToLower() == "-g")
        {
            switch (inputs[1].ToLower())
            {
                case "grade":
                    if (Excuetive is not null && inputs.Length >= 4)
                    {
                        Batch? batch_ = Info.FirstOrDefault(x => x.Name == inputs[2]);//get one batch
                        if (batch_ is not null)
                        {
                            Grade? grade = batch_.Grades.FirstOrDefault(x => x.Name == inputs[3]);//get one grade
                            if (grade is not null)
                            {
                                grade.Sections = Excuetive.GetFullSections(grade.ID).OrderBy(s => s.Name).ToList();
                                ShowGradeInfoOnMeetingForm(inputs[2], grade);
                            }
                            else ShowText?.Invoke(nullerror);
                        }
                        else ShowText?.Invoke(nullerror);
                    }
                    else ShowText?.Invoke(error);
                    break;
                case "section":
                    if (Attendee is Student)
                    {
                        Section? section = Info[0].Grades[0].Sections[0];
                        ShowSectionInfoOnMeetingForm(Info[0].Name, Info[0].Grades[0].Name, section);
                    }
                    else 
                    {
                        if (inputs.Length >= 4)
                        {
                            Batch? batch = Info.FirstOrDefault(x => x.Name == inputs[2]);//get one batch
                            if (batch is not null)
                            {
                                Grade? grade = batch.Grades.FirstOrDefault(x => x.Name == inputs[3]);//get one grade, change here
                                if (grade is not null && char.TryParse(inputs[4], out char sectionName))
                                {
                                    try
                                    {
                                        Section section = Attendee.GetFullSection(grade.ID, sectionName);
                                        ShowSectionInfoOnMeetingForm(inputs[2], inputs[3], section);
                                    }
                                    catch { ShowText?.Invoke(error); }
                                }
                                else ShowText?.Invoke(nullerror);
                            }
                            else ShowText?.Invoke(nullerror);
                        }
                        else ShowText?.Invoke(error);
                    }
                    break;
                case "attendance":
                    GetAttendence?.Invoke(Info,Attendee);
                    break;
                default:
                    break;
            }
        }
        if ((inputs[0].ToLower() == "-create" || inputs[0].ToLower() == "-c") && inputs.Length >= 2)
        {
            switch (inputs[1].ToLower())
            {
                case "batch"://refactored and tested
                    if ((Excuetive is not null && inputs.Length >= 3) && !Info.Any(b => b.Name.ToLower() == inputs[2].ToLower()))//check whether E is not null,check input length, and check for duplication
                    {
                        Batch batch = Excuetive.CreateBatch(inputs[2]);
                        Info.Add(batch);
                    }else ShowText?.Invoke(error);
                    break;
                case "grade"://refactored and tested
                    if (Excuetive is not null && inputs.Length >= 4)//check whether E is not null, and check input length
                    {
                        Batch? batch = Info.FirstOrDefault(x => x.Name == inputs[2]);//get one batch
                        if (batch is not null && !batch.Grades.Any(g => g.Name.ToLower() == inputs[3].ToLower()))//check whether b is null and check for duplication
                        {
                            Grade grade = Excuetive.CreateGrade(inputs[3], batch.ID);
                            batch.Grades.Add(grade);
                        }else ShowText?.Invoke(nullerror);
                    }else ShowText?.Invoke(error);
                    break;
                case "section"://refactored and tested
                    if (Excuetive is not null)//check whether E is not null
                    {
                        CreateSection?.Invoke(Info, Excuetive);
                    }else ShowText?.Invoke(error);
                    break;
                case "meeting"://refactored and tested
                    if (Educator is not null)//check whether Edu is not null
                    {
                        if (Info.Count == 1 && Info[0].Grades.Count == 1 && Info[0].Grades[0].Sections.Count == 1)// a tr who teaches in only batch, grade and class
                        {
                            MakeMeeting?.Invoke(Info[0].Name, Info[0].Grades[0].Name, Info[0].Grades[0].Sections[0], Educator);
                        }
                        else if (Info.Count == 1 && Info[0].Grades.Count == 1)// a tr who teaches in only batch and grade
                        {
                            if (inputs.Length >= 3 && char.TryParse(inputs[2], out char sectionName))//checks the input length and whether sectionName is valid
                            {
                                Section? section = Info[0].Grades[0].Sections.FirstOrDefault(x => x.Name == sectionName);//get one section
                                if (section is not null)
                                {
                                    MakeMeeting?.Invoke(Info[0].Name, Info[0].Grades[0].Name, section, Educator);
                                }else ShowText?.Invoke(nullerror);
                            }else ShowText?.Invoke(error);
                        }else CreateMeeting?.Invoke(Info, Educator);
                    }else ShowText?.Invoke(error);
                    break;
                case "tr":
                    if (Excuetive is not null && inputs.Length >= 8)
                    {
                        Batch? batch = Info.FirstOrDefault(x => x.Name == inputs[3]);//get one batch
                        if (batch is not null)
                        {
                            Grade? grade = batch.Grades.FirstOrDefault(x => x.Name == inputs[4]);//get one grade
                            if (grade is not null)
                            {
                                Section? section = Excuetive.GetSections(grade.ID).FirstOrDefault(x => x.Name.ToString() == inputs[5]);
                                if (section is not null)
                                {
                                    try { Excuetive.CreateTeacher(inputs[2], inputs[7], inputs[6], section.ID); }
                                    catch { ShowText?.Invoke(error); }
                                }else ShowText?.Invoke(nullerror);
                            }else ShowText?.Invoke(nullerror);
                        }else ShowText?.Invoke(nullerror);
                    }else ShowText?.Invoke(error);
                    break;
                case "excel"://refactored and tested
                    if (inputs.Length > 2)
                    {
                        if (inputs[2].ToLower() == "on")
                        {
                            GlobalTools.Excel = true;
                            GetExcelPath?.Invoke();
                        }
                        if (inputs[2].ToLower() == "off")
                            GlobalTools.Excel = false;
                    }
                    break;
            }
        }
        return comment;
    }
    public static void Validation()//refactored and tested
    {
        if (Excuetive is null && Educator is null && Student is null) throw new Exception("No modes are selected");
        if ((Excuetive is not null && Educator is not null) || (Educator is not null && Student is not null) || (Excuetive is not null && Student is not null))
            throw new Exception("Two modes are selected");
    }
    public static void ChooseMode(IAttendee person)//refactored and tested
    {
        Attendee = person; 
        if (person is Student s)
            Student = s;
        if (person is Teacher t)
            Educator = t;
        if (person is Administrator a)
            Excuetive = a;
        Info = person.GetInfo();//gets info
    }
    public static void ShowMeetingInfoOnMessageForm(string BatchName, string GradeName, Section section, Period period)//refactored and tested
    {
        StringBuilder info = new StringBuilder();
        info.AppendLine($"{period.StartTime.ToShortDateString()} {BatchName} {GradeName} {section.Name} " +
                    $"{period.Subject} {period.StartTime.ToShortTimeString()} - {period.EndTime.ToShortTimeString()}");
        foreach (var a in period.Attendees)
        {
            info.AppendLine($"ID:{a.ID} Name:{a.Name} JoinTime:{(a.JoinTime.HasValue ? a.JoinTime.GetValueOrDefault().ToShortTimeString() : "null")} " +
                $"LeaveTime:{(a.LeaveTime.HasValue ? a.LeaveTime.GetValueOrDefault().ToShortTimeString() : "null")}" +
                $" Duration:{a.Duration.GetValueOrDefault().Hours}:{a.Duration.GetValueOrDefault().Minutes}:{a.Duration.GetValueOrDefault().Seconds} Status:{a.Status}");
        }
        ShowText?.Invoke(info.ToString());
    }
    public static void ShowGradeInfoOnMeetingForm(string BatchName,Grade grade)
    {
        StringBuilder info = new StringBuilder();
        info.AppendLine($"{BatchName} {grade.Name}");
        foreach(var s in grade.Sections)
        {
            info.AppendLine($"{s.Name} Class, Teachers : {s.Teachers.Count} Students : {s.Students.Count}");
        }
        ShowText?.Invoke(info.ToString());
    }
    public static void ShowSectionInfoOnMeetingForm(string BatchName,string gradeName, Section section)
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

