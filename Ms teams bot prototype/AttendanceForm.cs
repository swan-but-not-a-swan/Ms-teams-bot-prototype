namespace Ms_teams_bot_prototype
{
    public partial class AttendanceForm : Form
    {
        private IAttendee Attendee { get; set; }
        private List<Batch> Batches { get; set; }
        private Batch batch { get; set; }
        private Grade grade { get; set; }
        private List<string> roles = new List<string>{"Student","Teacher"};
        public AttendanceForm(List<Batch> Batches, IAttendee Attendee)
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
        private void WireUpForm()
        {
            ShowBatch();
            batch = (Batch)batchComboBox.SelectedItem;
            ShowGrade();
            grade = (Grade)gradeComboBox.SelectedItem;
            ShowSection();
        }
        private void batchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            batch = (Batch)batchComboBox.SelectedItem;
            ShowGrade();
            grade = (Grade)gradeComboBox.SelectedItem;
            ShowSection();
        }
        private void gradeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            grade = (Grade)gradeComboBox.SelectedItem;
            ShowSection();
        }
        private void ShowBatch()
        {
            batchComboBox.DataSource = Batches;
            batchComboBox.DisplayMember = "Name";
        }
        private void ShowGrade()
        {
            gradeComboBox.DataSource = batch.Grades;
            gradeComboBox.DisplayMember = "Name";
        }
        private void ShowSection()
        {
            if (grade.Sections.Count <= 0 )
            {
                ComboBox.DataSource = null;
            }
            ComboBox.DataSource = grade.Sections;
            ComboBox.DisplayMember = "Name";
        }
        private void getAttendanceButton_Click(object sender, EventArgs e)
        {
            Section section = (Section)ComboBox.SelectedItem;
            if ( section is null)
            {
                MessageBox.Show("No sections");
            }
            else
            {
                bool one = name.Text.Length <= 0;
                bool two = email.Text.Length <= 0 || (email.Text.Contains("@") == false);
                if (one == two)
                {
                    Batch b = batch;
                    b.Grades[0] = grade;
                    b.Grades[0].Sections[0] = section;
                    Attendee.GetPeriods(batch.Name,grade.Name,name.Text, email.Text, subjectComboBox.Text, roleComboBox.Text, fromDateTime.Value, toDataTime.Value, section);
                    this.Close();
                }
                else MessageBox.Show("Either name or email value needed");
            }
        }

        private void subjectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void name_TextChanged(object sender, EventArgs e)
        {
            if(name.Text.Length > 0 && email.Text.Length > 0)
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

        private void email_TextChanged(object sender, EventArgs e)
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
    }
}
