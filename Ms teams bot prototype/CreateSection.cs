namespace Ms_teams_bot_prototype;
public partial class CreateSection : Form
{
    private IExcuetive Excuetive { get; set; }
    private List<Batch> Batches { get; set; }
    private List<IAttendee> roles = new List<IAttendee> { new Student(), new Teacher() };
    private IAttendee role { get; set; }
    private BindingSource membersBinding = new BindingSource();
    private List<IAttendee> person = new List<IAttendee>();
    private List<Teacher> teachers = new List<Teacher>();
    private List<Student> students = new List<Student>();
    public CreateSection(List<Batch> batches, IExcuetive excuetive)//refactored and tested
    {
        InitializeComponent();
        Batches = batches;
        WireUpForm();
        Excuetive = excuetive;
    }
    private void WireUpForm()//refactord and tested
    {
        batchComboBox.DataSource = Batches;
        batchComboBox.DisplayMember = "Name";
        Batch batch = (Batch)batchComboBox.SelectedItem;
        gradeComboBox.DataSource = batch.Grades;
        gradeComboBox.DisplayMember = "Name";
        roleComboBox.DataSource = roles;
        subjectComboBox.DataSource = Enum.GetNames(typeof(Subjects));
        membersBinding.DataSource = person;
        attendeesListBox.DataSource = membersBinding;
        attendeesListBox.DisplayMember = "Name";
    }
    private void batchComboBox_SelectedIndexChanged(object sender, EventArgs e)//refactored and tested
    {
        Batch batch = (Batch)batchComboBox.SelectedItem;
        gradeComboBox.DataSource = batch.Grades;
        if (gradeComboBox.Items.Count <= 0)
        {
            gradeComboBox.DisplayMember = "";
        }
    }
    private void addButton_Click(object sender, EventArgs e)
    {
        bool validation = GlobalTools.ValidateData(nameValue.Text, emailValue.Text);
        bool duplicateChecker = !person.Any(p => p.Name == nameValue.Text || p.Email == emailValue.Text);
        if (validation && duplicateChecker )//value validation and duplication checker
        {
            if (role is Teacher)
            {
                if (emailValue.Text.StartsWith("Tr"))
                {
                    Teacher t = new Teacher { Name = nameValue.Text, Email = emailValue.Text };
                    string subject = (string)subjectComboBox.SelectedItem;
                    t.Subject = (Subjects)Enum.Parse(typeof(Subjects), subject);
                    person.Add(t);
                    teachers.Add(t);
                }
                else MessageBox.Show("Tr's Email needs to start with Tr", "Input Error");
            }
            if (role is Student)
            {
                Student s = new Student { Name = nameValue.Text, Email = emailValue.Text };
                person.Add(s);
                students.Add(s);
            }
        }
        else MessageBox.Show("Invalid Input", "Input-Error");
        membersBinding.ResetBindings(false);
    }
    private void roleComboBox_SelectedIndexChanged(object sender, EventArgs e)//refactored and tested
    {
        role = (IAttendee)roleComboBox.SelectedItem;
        if (role is Teacher)
        {
            subjectLabel.Visible = true;
            subjectComboBox.Visible = true;
            formGroupBox.Name = "Create Teacher";
        }
        if (role is Student)
        {
            subjectLabel.Visible = false;
            subjectComboBox.Visible = false;
            formGroupBox.Name = "Create Student";
        }
    }
    private void deleteButton_Click(object sender, EventArgs e)//refactored and tested
    {
        IAttendee p = (IAttendee)attendeesListBox.SelectedItem;
        person.Remove(p);
        if (p is Teacher t)
        {
            teachers.Remove(t);
        }
        if (p is Student s)
        {
            students.Remove(s);
        }
        membersBinding.ResetBindings(false);
    }
    private void createSectionButton_Click(object sender, EventArgs e)
    {
        Grade grade = (Grade)gradeComboBox.SelectedItem;
        char.TryParse(sectionNameValue.Text, out char sectionName);
        if (char.IsUpper(sectionName) && !grade.Sections.Any(s => s.Name == sectionName))//checking whether sectionName is in caps and checking for duplication
        {
            if (teachers.Count > 0 && students.Count > 0)//checking whether teacherList and studentsList have value
            {
                Section section = new Section();
                section.Name = sectionName;
                section.Teachers = teachers;
                section.Students = students;
                Excuetive.CreateSection(section, grade);
                this.Close();
            }
            else MessageBox.Show("There's either no teacher or student information", "Input-Error");
        }
        else MessageBox.Show("Invalid SectionName value", "Input-Error");
    }
}
