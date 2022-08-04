namespace Ms_teams_bot_prototype
{
    public partial class MessageForm : Form
    {
        private MeetingForm meetingForm = new MeetingForm();
        public MessageForm(string name)
        {
            InitializeComponent();
            label1.Text = name;
            WireUpForm();
        }
        private void WireUpForm()
        {
            CommandAnalyzer.ShowText += CommandAnalyzer_ShowText;
            CommandAnalyzer.CreateSection += CommandAnalyzer_CreateSection;
            CommandAnalyzer.MakeMeeting += CommandAnalyzer_MakeMeeting1;
            CommandAnalyzer.CreateMeeting += CommandAnalyzer_CreateMeeting;
            CommandAnalyzer.GetExcelPath += CommandAnalyzer_GetExcelPath;
            CommandAnalyzer.GetAttendence += CommandAnalyzer_GetAttendence;
        }

        private void CommandAnalyzer_GetAttendence(List<Batch> batches, IAttendee Attendee)
        {
            AttendanceForm frm = new AttendanceForm(batches,Attendee);
            frm.Show();
        }

        private void CommandAnalyzer_GetExcelPath()//refactored and tested
        {
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                GlobalTools.ExcelPath = fbd.SelectedPath;
            }
        }
        private void CommandAnalyzer_CreateMeeting(List<Batch> batches, IEducator educator)//refactored and tested
        {
            CreateMeeting cm = new CreateMeeting(batches, educator);
            cm.Show();
        }
        private void CommandAnalyzer_MakeMeeting1(string BatchName, string GradeName, Section section, IEducator educator)//refactored and tested
        {
            Batch batch = new Batch();
            batch.Name = BatchName;
            batch.Grades.Add(new Grade { Name = GradeName });
            batch.Grades[0].Sections.Add(section);
            MeetingInvitationForm frm = new MeetingInvitationForm(batch, educator);
            frm.Show();
        }
        private void CommandAnalyzer_CreateSection(List<Batch> batches, IExcuetive excuetive)//refactored and tested
        {
            CreateSection cs = new CreateSection(batches, excuetive);
            cs.Show();
        }
        private void CommandAnalyzer_ShowText(string comment)//refactored and tested
        {
            if (messageShowerBox.InvokeRequired)
            {
                Action safeWrite = delegate { CommandAnalyzer_ShowText(comment); };
                messageShowerBox.Invoke(safeWrite);
            }
            else messageShowerBox.Text += comment + Environment.NewLine;
        }
        private void MessageForm_Load(object sender, EventArgs e)
        {
        }
        private void sendButton_Click(object sender, EventArgs e)
        {
            string command = messageBox.Text;
            messageBox.Text = "";
            messageShowerBox.Text += command + Environment.NewLine;
            if (command.StartsWith("-"))
            {
                CommandAnalyzer.Analyze(command);
            }
        }
        private void messageFormLabel_Click(object sender, EventArgs e)
        {
        }
    }
}
