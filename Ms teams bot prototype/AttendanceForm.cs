namespace Ms_teams_bot_prototype
{
    public partial class AttendanceForm : Form
    {
        private IAttendee Attendee { get; set; }
        private List<Batch> Batches { get; set; }
        private Batch batch { get; set; }
        private Grade grade { get; set; }
        private List<string> roles = new List<string>{"Student","Teacher"};
        public AttendanceForm(List<Batch> Batches, IAttendee Attendee)//final tested
        {
            InitializeComponent(); 
            this.Attendee = Attendee;
            this.Batches = Batches;
            if(Attendee is Student s)
            {
                name.Text = s.Name;
                email.Text = s.Email;
                name.Enabled = false;
                email.Enabled = false;
            }
            roleComboBox.DataSource = roles;
            WireUpForm();
        }
        private void WireUpForm()//final tested
        {
            ShowBatch();
            batch = (Batch)batchComboBox.SelectedItem;
            ShowGrade();
            grade = (Grade)gradeComboBox.SelectedItem;
            ShowSection();
        }
        private void batchComboBox_SelectedIndexChanged(object sender, EventArgs e)//final tested
        {
            batch = (Batch)batchComboBox.SelectedItem;
            ShowGrade();
            grade = (Grade)gradeComboBox.SelectedItem;
            ShowSection();
        }
        private void gradeComboBox_SelectedIndexChanged(object sender, EventArgs e)//final tested
        {
            grade = (Grade)gradeComboBox.SelectedItem;
            ShowSection();
        }
        private void ShowBatch()//final tested
        {
            batchComboBox.DataSource = Batches;
            batchComboBox.DisplayMember = "Name";
        }
        private void ShowGrade()//final tested
        {
            gradeComboBox.DataSource = batch.Grades;
            gradeComboBox.DisplayMember = "Name";
        }
        private void ShowSection()//final tested
        {
            if (grade.Sections.Count <= 0)
            {
                ComboBox.DataSource = null;
                ComboBox.Enabled = false;
            }
            else
            {
                ComboBox.Enabled = true;
                ComboBox.DataSource = grade.Sections;
                ComboBox.DisplayMember = "Name";
            }
        }
        private void name_TextChanged(object sender, EventArgs e)//final tested
        {
            if (name.Text.Length > 0 && email.Text.Length > 0)
            {
                roleLabel.Visible = true;
                roleComboBox.Visible = true;
            }
            else
            {
                roleLabel.Visible = false;
                roleComboBox.Visible = false;
            }
        }
        private void email_TextChanged(object sender, EventArgs e)//final tested
        {
            if (name.Text.Length > 0 && email.Text.Length > 0)
            {
                roleLabel.Visible = true;
                roleComboBox.Visible = true;
            }
            else
            {
                roleLabel.Visible = false;
                roleComboBox.Visible = false;
            }
        }
        private void getAttendanceButton_Click(object sender, EventArgs e)//final tested
        {
            Section section = (Section)ComboBox.SelectedItem;
            if ( section is null)
            {
                MessageBox.Show("No sections");
                return;
            }
            bool one = name.Text.Length <= 0;
            bool two = email.Text.Length <= 0 || (email.Text.Contains("@") == false);
            if (one == two)
            {
                GetPeriods(name.Text, email.Text, subjectComboBox.Text, roleComboBox.Text, fromDateTime.Value, toDataTime.Value, section);
                section.Periods.Clear();
                this.Close();
            }
            else MessageBox.Show("Either name or email value needed");
        }
        private void GetPeriods(string name, string email, string subject, string Role, DateTime from, DateTime to, Section section)//final tested
        {
            if (name.Length <= 0 || email.Length <= 0)
                Attendee.GetPeriods(subject, from, to,section);
            else
                Attendee.GetPeriodsWithNameEmail(name, email, subject, Role, from, to,section);
            if (section.Periods.Count <= 0) return;
            foreach (Period pe in section.Periods)
            {
                GlobalTools.ShowMeetingInfoOnMessageForm(batch.Name, grade.Name, section, pe);
            }
        }
    }
}
