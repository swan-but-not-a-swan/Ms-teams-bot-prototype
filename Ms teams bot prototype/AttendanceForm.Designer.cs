namespace Ms_teams_bot_prototype
{
    partial class AttendanceForm
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
            this.getAttendanceButton = new System.Windows.Forms.Button();
            this.batchComboBox = new System.Windows.Forms.ComboBox();
            this.batchLabel = new System.Windows.Forms.Label();
            this.schoolComboBox = new System.Windows.Forms.ComboBox();
            this.schoolLabel = new System.Windows.Forms.Label();
            this.toLabel = new System.Windows.Forms.Label();
            this.toDataTime = new System.Windows.Forms.DateTimePicker();
            this.fromLabel = new System.Windows.Forms.Label();
            this.period = new System.Windows.Forms.TextBox();
            this.periodLabel = new System.Windows.Forms.Label();
            this.grade = new System.Windows.Forms.TextBox();
            this.gradeLabel = new System.Windows.Forms.Label();
            this.section = new System.Windows.Forms.TextBox();
            this.sectionLabel = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.fromDateTime = new System.Windows.Forms.DateTimePicker();
            this.attendanceLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // getAttendanceButton
            // 
            this.getAttendanceButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.getAttendanceButton.AutoSize = true;
            this.getAttendanceButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.getAttendanceButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.getAttendanceButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.getAttendanceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.getAttendanceButton.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.getAttendanceButton.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.getAttendanceButton.Location = new System.Drawing.Point(331, 325);
            this.getAttendanceButton.Name = "getAttendanceButton";
            this.getAttendanceButton.Size = new System.Drawing.Size(234, 84);
            this.getAttendanceButton.TabIndex = 69;
            this.getAttendanceButton.Text = "Get Attendance";
            this.getAttendanceButton.UseVisualStyleBackColor = false;
            // 
            // batchComboBox
            // 
            this.batchComboBox.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.batchComboBox.FormattingEnabled = true;
            this.batchComboBox.Items.AddRange(new object[] {
            "TIL",
            "HBL"});
            this.batchComboBox.Location = new System.Drawing.Point(625, 253);
            this.batchComboBox.Name = "batchComboBox";
            this.batchComboBox.Size = new System.Drawing.Size(200, 38);
            this.batchComboBox.TabIndex = 68;
            // 
            // batchLabel
            // 
            this.batchLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.batchLabel.AutoSize = true;
            this.batchLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.batchLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.batchLabel.Location = new System.Drawing.Point(518, 253);
            this.batchLabel.Name = "batchLabel";
            this.batchLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.batchLabel.Size = new System.Drawing.Size(107, 37);
            this.batchLabel.TabIndex = 67;
            this.batchLabel.Text = "Batch : ";
            this.batchLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // schoolComboBox
            // 
            this.schoolComboBox.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.schoolComboBox.FormattingEnabled = true;
            this.schoolComboBox.Items.AddRange(new object[] {
            "ILBC"});
            this.schoolComboBox.Location = new System.Drawing.Point(625, 198);
            this.schoolComboBox.Name = "schoolComboBox";
            this.schoolComboBox.Size = new System.Drawing.Size(200, 38);
            this.schoolComboBox.TabIndex = 66;
            // 
            // schoolLabel
            // 
            this.schoolLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.schoolLabel.AutoSize = true;
            this.schoolLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.schoolLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.schoolLabel.Location = new System.Drawing.Point(504, 196);
            this.schoolLabel.Name = "schoolLabel";
            this.schoolLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.schoolLabel.Size = new System.Drawing.Size(121, 37);
            this.schoolLabel.TabIndex = 65;
            this.schoolLabel.Text = "School : ";
            this.schoolLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toLabel
            // 
            this.toLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.toLabel.AutoSize = true;
            this.toLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.toLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.toLabel.Location = new System.Drawing.Point(559, 148);
            this.toLabel.Name = "toLabel";
            this.toLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toLabel.Size = new System.Drawing.Size(66, 37);
            this.toLabel.TabIndex = 64;
            this.toLabel.Text = "To : ";
            this.toLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toDataTime
            // 
            this.toDataTime.CustomFormat = "yyyy-MM-dd";
            this.toDataTime.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toDataTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.toDataTime.Location = new System.Drawing.Point(625, 148);
            this.toDataTime.Name = "toDataTime";
            this.toDataTime.Size = new System.Drawing.Size(200, 36);
            this.toDataTime.TabIndex = 63;
            // 
            // fromLabel
            // 
            this.fromLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fromLabel.AutoSize = true;
            this.fromLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.fromLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.fromLabel.Location = new System.Drawing.Point(522, 96);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fromLabel.Size = new System.Drawing.Size(102, 37);
            this.fromLabel.TabIndex = 62;
            this.fromLabel.Text = "From : ";
            this.fromLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // period
            // 
            this.period.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.period.ForeColor = System.Drawing.Color.Black;
            this.period.Location = new System.Drawing.Point(155, 252);
            this.period.Name = "period";
            this.period.Size = new System.Drawing.Size(290, 36);
            this.period.TabIndex = 61;
            // 
            // periodLabel
            // 
            this.periodLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.periodLabel.AutoSize = true;
            this.periodLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.periodLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.periodLabel.Location = new System.Drawing.Point(47, 249);
            this.periodLabel.Name = "periodLabel";
            this.periodLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.periodLabel.Size = new System.Drawing.Size(116, 37);
            this.periodLabel.TabIndex = 60;
            this.periodLabel.Text = "Period : ";
            this.periodLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grade
            // 
            this.grade.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grade.ForeColor = System.Drawing.Color.Black;
            this.grade.Location = new System.Drawing.Point(155, 148);
            this.grade.Name = "grade";
            this.grade.Size = new System.Drawing.Size(290, 36);
            this.grade.TabIndex = 59;
            // 
            // gradeLabel
            // 
            this.gradeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gradeLabel.AutoSize = true;
            this.gradeLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gradeLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.gradeLabel.Location = new System.Drawing.Point(51, 145);
            this.gradeLabel.Name = "gradeLabel";
            this.gradeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gradeLabel.Size = new System.Drawing.Size(111, 37);
            this.gradeLabel.TabIndex = 58;
            this.gradeLabel.Text = "Grade : ";
            this.gradeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // section
            // 
            this.section.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.section.ForeColor = System.Drawing.Color.Black;
            this.section.Location = new System.Drawing.Point(155, 199);
            this.section.Name = "section";
            this.section.Size = new System.Drawing.Size(290, 36);
            this.section.TabIndex = 57;
            // 
            // sectionLabel
            // 
            this.sectionLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sectionLabel.AutoSize = true;
            this.sectionLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sectionLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.sectionLabel.Location = new System.Drawing.Point(33, 196);
            this.sectionLabel.Name = "sectionLabel";
            this.sectionLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sectionLabel.Size = new System.Drawing.Size(129, 37);
            this.sectionLabel.TabIndex = 56;
            this.sectionLabel.Text = "Section : ";
            this.sectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // name
            // 
            this.name.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.name.ForeColor = System.Drawing.Color.Black;
            this.name.Location = new System.Drawing.Point(155, 96);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(290, 36);
            this.name.TabIndex = 55;
            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nameLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.nameLabel.Location = new System.Drawing.Point(50, 93);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nameLabel.Size = new System.Drawing.Size(111, 37);
            this.nameLabel.TabIndex = 54;
            this.nameLabel.Text = "Name : ";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fromDateTime
            // 
            this.fromDateTime.CustomFormat = "yyyy-MM-dd";
            this.fromDateTime.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fromDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fromDateTime.Location = new System.Drawing.Point(625, 96);
            this.fromDateTime.Name = "fromDateTime";
            this.fromDateTime.Size = new System.Drawing.Size(200, 36);
            this.fromDateTime.TabIndex = 53;
            // 
            // attendanceLabel
            // 
            this.attendanceLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.attendanceLabel.AutoSize = true;
            this.attendanceLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.attendanceLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.attendanceLabel.Location = new System.Drawing.Point(357, 27);
            this.attendanceLabel.Name = "attendanceLabel";
            this.attendanceLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.attendanceLabel.Size = new System.Drawing.Size(208, 37);
            this.attendanceLabel.TabIndex = 52;
            this.attendanceLabel.Text = "Get Attendance";
            this.attendanceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AttendanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 436);
            this.Controls.Add(this.getAttendanceButton);
            this.Controls.Add(this.batchComboBox);
            this.Controls.Add(this.batchLabel);
            this.Controls.Add(this.schoolComboBox);
            this.Controls.Add(this.schoolLabel);
            this.Controls.Add(this.toLabel);
            this.Controls.Add(this.toDataTime);
            this.Controls.Add(this.fromLabel);
            this.Controls.Add(this.period);
            this.Controls.Add(this.periodLabel);
            this.Controls.Add(this.grade);
            this.Controls.Add(this.gradeLabel);
            this.Controls.Add(this.section);
            this.Controls.Add(this.sectionLabel);
            this.Controls.Add(this.name);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.fromDateTime);
            this.Controls.Add(this.attendanceLabel);
            this.MaximizeBox = false;
            this.Name = "AttendanceForm";
            this.Text = "AttendanceForm";
            this.Load += new System.EventHandler(this.AttendanceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button getAttendanceButton;
        private ComboBox batchComboBox;
        private Label batchLabel;
        private ComboBox schoolComboBox;
        private Label schoolLabel;
        private Label toLabel;
        private DateTimePicker toDataTime;
        private Label fromLabel;
        private TextBox period;
        private Label periodLabel;
        private TextBox grade;
        private Label gradeLabel;
        private TextBox section;
        private Label sectionLabel;
        private TextBox name;
        private Label nameLabel;
        private DateTimePicker fromDateTime;
        private Label attendanceLabel;
    }
}