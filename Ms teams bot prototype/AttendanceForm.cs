namespace Ms_teams_bot_prototype
{
    public partial class AttendanceForm : Form
    {
        private IAttendee Attendee { get; set; }
        private List<Batch> Batches { get; set; }
        private Batch batch { get; set; }
        private Grade grade { get; set; }
        public AttendanceForm(List<Batch> Batches, IAttendee Attendee)
        {
            InitializeComponent(); 
            this.Attendee = Attendee;
            this.Batches = Batches;
            if(Attendee is IExcuetive e)
            {
                foreach (var b in Batches)
                {
                    foreach (var g in b.Grades)
                    {
                        g.Sections = e.GetSections(g.ID);
                    }
                }
            }
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
                Batch b = batch;
                b.Grades[0] = grade;
                b.Grades[0].Sections[0] = section;
                Attendee.GetPeriods(name.Text, email.Text, subjectComboBox.Text, fromDateTime.Value, toDataTime.Value,b);
                this.Close();
            }
        }

        private void subjectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
