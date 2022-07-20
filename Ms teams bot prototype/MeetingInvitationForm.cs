namespace Ms_teams_bot_prototype
{
    public partial class MeetingInvitationForm : Form
    {
        private Batch Batch { get; set; }
        private IEducator Educator { get; set; }
        public MeetingInvitationForm(Batch batch, IEducator educator)//refactored and tested
        {
            InitializeComponent();
            Batch = batch;
            Educator = educator;
            meetingInvitationLabel.Text = $"{batch.Name} {batch.Grades[0].Name} {batch.Grades[0].Sections[0].Name} {batch.Grades[0].Sections[0].Teachers[0].Subject}";
        }
        private void acceptButton_Click(object sender, EventArgs e)//refactored and tested
        {
            MeetingForm frm = new MeetingForm(Batch, Educator);
            frm.Show();
            this.Close();
        }
        private void declineButton_Click(object sender, EventArgs e)//refactored and tested
        {
            this.Close();
        }
    }
}
