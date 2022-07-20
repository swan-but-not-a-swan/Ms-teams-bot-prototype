namespace Ms_teams_bot_prototype;

partial class CreateMeeting
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.batchComboBox = new System.Windows.Forms.ComboBox();
            this.gradeComboBox = new System.Windows.Forms.ComboBox();
            this.sectionComboBox = new System.Windows.Forms.ComboBox();
            this.meetingInfoValue = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.createMeetingButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // batchComboBox
            // 
            this.batchComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.batchComboBox.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.batchComboBox.FormattingEnabled = true;
            this.batchComboBox.Location = new System.Drawing.Point(12, 49);
            this.batchComboBox.Name = "batchComboBox";
            this.batchComboBox.Size = new System.Drawing.Size(121, 45);
            this.batchComboBox.TabIndex = 46;
            this.batchComboBox.SelectedIndexChanged += new System.EventHandler(this.batchComboBox_SelectedIndexChanged);
            // 
            // gradeComboBox
            // 
            this.gradeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gradeComboBox.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gradeComboBox.FormattingEnabled = true;
            this.gradeComboBox.Location = new System.Drawing.Point(139, 49);
            this.gradeComboBox.Name = "gradeComboBox";
            this.gradeComboBox.Size = new System.Drawing.Size(225, 45);
            this.gradeComboBox.TabIndex = 47;
            this.gradeComboBox.SelectedIndexChanged += new System.EventHandler(this.gradeComboBox_SelectedIndexChanged);
            // 
            // sectionComboBox
            // 
            this.sectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sectionComboBox.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sectionComboBox.FormattingEnabled = true;
            this.sectionComboBox.Location = new System.Drawing.Point(370, 49);
            this.sectionComboBox.Name = "sectionComboBox";
            this.sectionComboBox.Size = new System.Drawing.Size(73, 45);
            this.sectionComboBox.TabIndex = 48;
            this.sectionComboBox.SelectedIndexChanged += new System.EventHandler(this.sectionComboBox_SelectedIndexChanged);
            // 
            // meetingInfoValue
            // 
            this.meetingInfoValue.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.meetingInfoValue.Location = new System.Drawing.Point(12, 112);
            this.meetingInfoValue.Name = "meetingInfoValue";
            this.meetingInfoValue.ReadOnly = true;
            this.meetingInfoValue.Size = new System.Drawing.Size(431, 43);
            this.meetingInfoValue.TabIndex = 49;
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.titleLabel.Location = new System.Drawing.Point(131, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.titleLabel.Size = new System.Drawing.Size(205, 37);
            this.titleLabel.TabIndex = 50;
            this.titleLabel.Text = "Create Meeting";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // createMeetingButton
            // 
            this.createMeetingButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.createMeetingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createMeetingButton.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.createMeetingButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.createMeetingButton.Location = new System.Drawing.Point(103, 161);
            this.createMeetingButton.Name = "createMeetingButton";
            this.createMeetingButton.Size = new System.Drawing.Size(230, 52);
            this.createMeetingButton.TabIndex = 53;
            this.createMeetingButton.Text = "Create Meeting";
            this.createMeetingButton.UseVisualStyleBackColor = false;
            this.createMeetingButton.Click += new System.EventHandler(this.createMeetingButton_Click);
            // 
            // CreateMeeting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 225);
            this.Controls.Add(this.createMeetingButton);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.meetingInfoValue);
            this.Controls.Add(this.sectionComboBox);
            this.Controls.Add(this.gradeComboBox);
            this.Controls.Add(this.batchComboBox);
            this.Name = "CreateMeeting";
            this.Text = "CreateMeeting";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private ComboBox batchComboBox;
    private ComboBox gradeComboBox;
    private ComboBox sectionComboBox;
    private TextBox meetingInfoValue;
    private Label titleLabel;
    private Button createMeetingButton;
}
