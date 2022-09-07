//using Ms_teams_Proto_Library;

namespace Ms_teams_bot_prototype
{
    public partial class MeetingForm : Form
    {
        private IEducator Educator { get; set; }
        private Period period { get; set; } = new Period();
        private Batch Batch { get; set; }
        private Section section { get; set; }
        private BindingSource attendeeBinding = new BindingSource();
        private const string Present = "Present";
        private const string Absent = "Absent";
        public MeetingForm(Batch batch, IEducator educator)//final tested
        {
            InitializeComponent();
            Batch = batch;
            section = batch.Grades[0].Sections[0];
            period.Subject = section.Teachers[0].Subject;
            Educator = educator;
            WireUpForm();
        }
        public void WireUpForm()//final tested
        {
            schoolLabel.Text = $"{Batch.Name} {Batch.Grades[0].Name} {section.Name} {period.Subject}";
            Teacher teacher = section.Teachers[0].ShallowCopy();
            teacher.Status = Present;
            teacher.JoinTime = DateTime.Now;
            period.Attendees.Add(teacher);
            attendeeBinding.DataSource = period.Attendees;
            attendeesListBox.DataSource = attendeeBinding;
            attendeesListBox.DisplayMember = "Name";
        }
        private void MeetingForm_Load(object sender, EventArgs e) //final tested
        {
            period.StartTime = DateTime.Now;
            timer.Start();
            timer.Interval = (2 * 60 * 1000);
            timer.Tick += Timer_Tick;
        }
        private async void Timer_Tick(object? sender, EventArgs e)//final tested
        {
            timer.Stop();
            await MeetingEnd();
        }
        private async Task MeetingEnd()//final tested
        {
            period.EndTime = DateTime.Now;
            foreach (var a in period.Attendees)
            {
                if (a.LeaveTime is not null) continue;
                a.LeaveTime = DateTime.Now;
                a.Duration = a.LeaveTime - a.JoinTime;
            }
            var firstNotSecond = section.Students.Except(period.Attendees);
            foreach (var s in firstNotSecond)
            {
                s.Status = Absent;
                period.Attendees.Add(s);
            }
            try { await Educator.CreateMeeting(Batch, section, period); }
            catch { MessageBox.Show("Additional excel file opened"); }
            CleanUp();
            this.Close();
        }
        private void joinButton_Click(object sender, EventArgs e)//final tested
        {
            Student? s = section.Students.FirstOrDefault(x => x.Name == nameValue.Text && x.Email == emailValue.Text);
            if (s is not null && !period.Attendees.Any(a => a.Name == s.Name || a.Email == s.Email))
            {
                s.JoinTime = DateTime.Now;
                s.Status = Present;
                period.Attendees.Add(s);
                attendeeBinding.DataSource = period.Attendees.Where(x => x.LeaveTime is null).ToList();
                attendeeBinding.ResetBindings(false);
            }
            else MessageBox.Show("Invalid Input", "Input-Error");
        }
        private async void leaveButton_Click(object sender, EventArgs e)//final tested
        {
            var attendee = (IAttendee)attendeesListBox.SelectedItem;
            int index = period.Attendees.FindIndex(x => x.Name == attendee.Name);
            period.Attendees[index].LeaveTime = DateTime.Now;
            period.Attendees[index].Duration = period.Attendees[index].LeaveTime - period.Attendees[index].JoinTime;
            attendeeBinding.DataSource = period.Attendees.Where(x => x.LeaveTime is null).ToList();
            attendeeBinding.ResetBindings(false);
            if (attendeeBinding.Count < 1)
            {
                await MeetingEnd();
            }
        }
        private void CleanUp()//final tested
        {
            foreach (var s in section.Students)
            {
                if (s.JoinTime is not null)
                {
                    s.JoinTime = null;
                    s.LeaveTime = null;
                    s.Duration = null;
                    s.Status = Absent;
                }
            }
        }
    }
}
