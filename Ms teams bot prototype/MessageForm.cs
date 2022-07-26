﻿namespace Ms_teams_bot_prototype;
public partial class MessageForm : Form
{
    private static IAttendee Attendee { get; set; }
    public MessageForm(IAttendee attendee)//final tested
    {
        InitializeComponent();
        label1.Text = attendee.Name;
        Attendee = attendee;
        WireUpForm();
    }
    private void WireUpForm()//final tested
    {
        CommandAnalyzer.ChooseMode(Attendee);
        GlobalTools.ShowText += GlobalTools_ShowText;
        CommandAnalyzer.CreateSection += CommandAnalyzer_CreateSection;
        CommandAnalyzer.MakeMeeting += CommandAnalyzer_MakeMeeting;
        CommandAnalyzer.CreateMeeting += CommandAnalyzer_CreateMeeting;
        CommandAnalyzer.GetExcelPath += CommandAnalyzer_GetExcelPath;
        CommandAnalyzer.GetAttendence += CommandAnalyzer_GetAttendence;
        CommandAnalyzer.GetExcelFilePath += CommandAnalyzer_GetExcelFilePath;
        intellisense.DataSource = Attendee.GetAllCommands();
    }
    private async void CommandAnalyzer_GetExcelFilePath(string BatchName,string GradeName,Section section, Period period, IAttendee attendee)//final tested
    {
        using(var openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = "excel files (*.xlsx;*.xls) |*.xlsx;*.xls"; 
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileInfo = openFileDialog.FileName;
                try
                {
                    await attendee.SaveIntoExcel(BatchName, GradeName, section, period, new FileInfo(fileInfo));
                }
                catch
                {
                    MessageBox.Show("Additional Excel file opened");
                }
            }
        }
    }
    private void CommandAnalyzer_GetAttendence(List<Batch> batches, IAttendee Attendee)//final tested
    {
        AttendanceForm frm = new AttendanceForm(batches,Attendee);
        frm.Show();
    }
    private void CommandAnalyzer_GetExcelPath()//final tested
    {
        DialogResult result = fbd.ShowDialog();
        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
        {
            GlobalTools.ExcelPath = fbd.SelectedPath;
        }
    }
    private void CommandAnalyzer_CreateMeeting(List<Batch> batches, IEducator educator)//final tested
    {
        CreateMeeting cm = new CreateMeeting(batches, educator);
        cm.Show();
    }
    private void CommandAnalyzer_MakeMeeting(string BatchName, string GradeName, Section section, IEducator educator)//final tested
    {
        Batch batch = new Batch { Name = BatchName};
        batch.Grades.Add(new Grade { Name = GradeName });
        batch.Grades[0].Sections.Add(section);
        MeetingInvitationForm frm = new MeetingInvitationForm(batch, educator);
        frm.Show();
    }
    private void CommandAnalyzer_CreateSection(List<Batch> batches, IExcuetive excuetive)//final tested
    {
        CreateSection cs = new CreateSection(batches, excuetive);
        cs.Show();
    }
    private void GlobalTools_ShowText(string comment)//final tested
    {
        if (messageShowerBox.InvokeRequired)
        {
            Action safeWrite = delegate { GlobalTools_ShowText(comment); };
            messageShowerBox.Invoke(safeWrite);
        }
        else messageShowerBox.Text += comment + Environment.NewLine;
    }
    private void sendButton_Click(object sender, EventArgs e)//final tested
    {
        string cwa = "";
        if(messageBox.Enabled == true)
        {
            cwa = messageBox.Text;
            messageBox.Text = "";
        }
        else if(intellisense.Enabled == true)
        {
            cwa = intellisense.Text;
            intellisense.Text = "";
        }
        messageShowerBox.Text += cwa + Environment.NewLine;
        if (cwa.Trim().StartsWith("-"))
        {
            cwa = CommandAnalyzer.Analyze(Attendee,cwa);
            if(cwa.Length > 0)
            {
                messageShowerBox.Text += cwa + Environment.NewLine;
            }
        }
        messageShowerBox.SelectionStart = messageShowerBox.Text.Length;
        messageShowerBox.ScrollToCaret();
    } 
    private void messageBox_TextChanged(object sender, EventArgs e)//final tested
    {
        if(messageBox.Text.StartsWith("-"))
        {
            messageBox.Enabled = false;
            messageBox.Visible = false;
            intellisense.Enabled = true;
            intellisense.Visible = true;
            intellisense.Text = messageBox.Text;
            intellisense.Focus();
            intellisense.SelectionStart = intellisense.Text.Length;         
        }
    }
    private void intellisensetextChanged(object sender, EventArgs e)//final tested
    {
        if(!intellisense.Text.StartsWith("-"))
        {
            messageBox.Enabled = true;
            messageBox.Visible = true;
            intellisense.Enabled = false;
            intellisense.Visible = false;
            messageBox.Text = intellisense.Text;
        }
    }
}
