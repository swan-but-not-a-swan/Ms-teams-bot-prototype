﻿namespace Ms_teams_bot_prototype;
public partial class CreateMeeting : Form
{
    private List<Batch> Batches { get; set; }
    private Batch batch { get; set; }
    private Grade grade { get; set; }
    private Section section { get; set; }
    private IEducator Educator { get; set; }
    public CreateMeeting(List<Batch> info, IEducator educator)//final tested
    {
        InitializeComponent();
        Batches = info;
        Educator = educator;
        WireUpForm();
    }
    private void WireUpForm()//final tested
    {
        ShowBatch();
        batch = (Batch)batchComboBox.SelectedItem;
        ShowGrade();
        grade = (Grade)gradeComboBox.SelectedItem;
        ShowSection();
        ShowInfoOnTextBox();
    }
    private void batchComboBox_SelectedIndexChanged(object sender, EventArgs e)//final tested
    {
        batch = (Batch)batchComboBox.SelectedItem;
        ShowGrade();
        grade = (Grade)gradeComboBox.SelectedItem;
        ShowSection();
        ShowInfoOnTextBox();
    }
    private void gradeComboBox_SelectedIndexChanged(object sender, EventArgs e)//final tested
    {
        grade = (Grade)gradeComboBox.SelectedItem;
        ShowSection();
        ShowInfoOnTextBox();
    }
    private void sectionComboBox_SelectedIndexChanged(object sender, EventArgs e)//final tested
    {
        ShowInfoOnTextBox();
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
        sectionComboBox.DataSource = grade.Sections;
        sectionComboBox.DisplayMember = "Name";
    }
    private void ShowInfoOnTextBox()//final tested
    {
        section = (Section)sectionComboBox.SelectedItem;
        meetingInfoValue.Text = $"{batch.Name} {grade.Name} {section.Name} {section.Teachers[0].Subject}";
    }
    private void createMeetingButton_Click(object sender, EventArgs e)//final tested
    {
        Batch b = new Batch { Name = batch.Name};
        b.Grades.Insert(0, new Grade { Name = grade.Name });
        b.Grades[0].Sections.Add(section);
        MeetingInvitationForm frm = new MeetingInvitationForm(b, Educator);
        frm.Show();
        this.Close();
    }
}
