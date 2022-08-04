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
            this.batchLabel = new System.Windows.Forms.Label();
            this.toLabel = new System.Windows.Forms.Label();
            this.toDataTime = new System.Windows.Forms.DateTimePicker();
            this.fromLabel = new System.Windows.Forms.Label();
            this.gradeLabel = new System.Windows.Forms.Label();
            this.sectionLabel = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.fromDateTime = new System.Windows.Forms.DateTimePicker();
            this.attendanceLabel = new System.Windows.Forms.Label();
            this.batchComboBox = new System.Windows.Forms.ComboBox();
            this.gradeComboBox = new System.Windows.Forms.ComboBox();
            this.subjectComboBox = new System.Windows.Forms.ComboBox();
            this.periodLabel = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ComboBox = new System.Windows.Forms.ComboBox();
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
            this.getAttendanceButton.Location = new System.Drawing.Point(310, 323);
            this.getAttendanceButton.Name = "getAttendanceButton";
            this.getAttendanceButton.Size = new System.Drawing.Size(234, 84);
            this.getAttendanceButton.TabIndex = 69;
            this.getAttendanceButton.Text = "Get Attendance";
            this.getAttendanceButton.UseVisualStyleBackColor = false;
            this.getAttendanceButton.Click += new System.EventHandler(this.getAttendanceButton_Click);
            // 
            // batchLabel
            // 
            this.batchLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.batchLabel.AutoSize = true;
            this.batchLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.batchLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.batchLabel.Location = new System.Drawing.Point(28, 253);
            this.batchLabel.Name = "batchLabel";
            this.batchLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.batchLabel.Size = new System.Drawing.Size(129, 37);
            this.batchLabel.TabIndex = 67;
            this.batchLabel.Text = "Section : ";
            this.batchLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toLabel
            // 
            this.toLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.toLabel.AutoSize = true;
            this.toLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.toLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.toLabel.Location = new System.Drawing.Point(510, 196);
            this.toLabel.Name = "toLabel";
            this.toLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toLabel.Size = new System.Drawing.Size(66, 37);
            this.toLabel.TabIndex = 64;
            this.toLabel.Text = "To : ";
            this.toLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toDataTime
            // 
            this.toDataTime.CustomFormat = "MM/dd/yyyy H:mm";
            this.toDataTime.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toDataTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.toDataTime.Location = new System.Drawing.Point(576, 198);
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
            this.fromLabel.Location = new System.Drawing.Point(474, 145);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fromLabel.Size = new System.Drawing.Size(102, 37);
            this.fromLabel.TabIndex = 62;
            this.fromLabel.Text = "From : ";
            this.fromLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradeLabel
            // 
            this.gradeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gradeLabel.AutoSize = true;
            this.gradeLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gradeLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.gradeLabel.Location = new System.Drawing.Point(46, 145);
            this.gradeLabel.Name = "gradeLabel";
            this.gradeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gradeLabel.Size = new System.Drawing.Size(107, 37);
            this.gradeLabel.TabIndex = 58;
            this.gradeLabel.Text = "Batch : ";
            this.gradeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sectionLabel
            // 
            this.sectionLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sectionLabel.AutoSize = true;
            this.sectionLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sectionLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.sectionLabel.Location = new System.Drawing.Point(44, 196);
            this.sectionLabel.Name = "sectionLabel";
            this.sectionLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sectionLabel.Size = new System.Drawing.Size(111, 37);
            this.sectionLabel.TabIndex = 56;
            this.sectionLabel.Text = "Grade : ";
            this.sectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // name
            // 
            this.name.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.name.ForeColor = System.Drawing.Color.Black;
            this.name.Location = new System.Drawing.Point(155, 96);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(255, 36);
            this.name.TabIndex = 55;
            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nameLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.nameLabel.Location = new System.Drawing.Point(46, 93);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nameLabel.Size = new System.Drawing.Size(111, 37);
            this.nameLabel.TabIndex = 54;
            this.nameLabel.Text = "Name : ";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fromDateTime
            // 
            this.fromDateTime.CustomFormat = "MM/dd/yyyy H:mm";
            this.fromDateTime.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fromDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fromDateTime.Location = new System.Drawing.Point(576, 146);
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
            // batchComboBox
            // 
            this.batchComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.batchComboBox.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.batchComboBox.FormattingEnabled = true;
            this.batchComboBox.Location = new System.Drawing.Point(155, 144);
            this.batchComboBox.Name = "batchComboBox";
            this.batchComboBox.Size = new System.Drawing.Size(200, 38);
            this.batchComboBox.TabIndex = 71;
            this.batchComboBox.SelectedIndexChanged += new System.EventHandler(this.batchComboBox_SelectedIndexChanged);
            // 
            // gradeComboBox
            // 
            this.gradeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gradeComboBox.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gradeComboBox.FormattingEnabled = true;
            this.gradeComboBox.Location = new System.Drawing.Point(155, 199);
            this.gradeComboBox.Name = "gradeComboBox";
            this.gradeComboBox.Size = new System.Drawing.Size(200, 38);
            this.gradeComboBox.TabIndex = 72;
            this.gradeComboBox.SelectedIndexChanged += new System.EventHandler(this.gradeComboBox_SelectedIndexChanged);
            // 
            // subjectComboBox
            // 
            this.subjectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subjectComboBox.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.subjectComboBox.FormattingEnabled = true;
            this.subjectComboBox.Items.AddRange(new object[] {
            "Myanmarsar",
            "English",
            "Maths",
            "Science",
            "History",
            "Geography",
            "Physics",
            "Chemistry",
            "Biology",
            "IT",
            "FineArts",
            "PE"});
            this.subjectComboBox.Location = new System.Drawing.Point(576, 253);
            this.subjectComboBox.Name = "subjectComboBox";
            this.subjectComboBox.Size = new System.Drawing.Size(204, 38);
            this.subjectComboBox.TabIndex = 74;
            this.subjectComboBox.SelectedIndexChanged += new System.EventHandler(this.subjectComboBox_SelectedIndexChanged);
            // 
            // periodLabel
            // 
            this.periodLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.periodLabel.AutoSize = true;
            this.periodLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.periodLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.periodLabel.Location = new System.Drawing.Point(448, 250);
            this.periodLabel.Name = "periodLabel";
            this.periodLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.periodLabel.Size = new System.Drawing.Size(129, 37);
            this.periodLabel.TabIndex = 73;
            this.periodLabel.Text = "Subject : ";
            this.periodLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // email
            // 
            this.email.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.email.ForeColor = System.Drawing.Color.Black;
            this.email.Location = new System.Drawing.Point(576, 96);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(255, 36);
            this.email.TabIndex = 76;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(472, 93);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(104, 37);
            this.label1.TabIndex = 75;
            this.label1.Text = "Email : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ComboBox
            // 
            this.ComboBox.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ComboBox.FormattingEnabled = true;
            this.ComboBox.Location = new System.Drawing.Point(155, 256);
            this.ComboBox.Name = "ComboBox";
            this.ComboBox.Size = new System.Drawing.Size(200, 38);
            this.ComboBox.TabIndex = 77;
            // 
            // AttendanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 436);
            this.Controls.Add(this.ComboBox);
            this.Controls.Add(this.email);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.subjectComboBox);
            this.Controls.Add(this.periodLabel);
            this.Controls.Add(this.gradeComboBox);
            this.Controls.Add(this.batchComboBox);
            this.Controls.Add(this.getAttendanceButton);
            this.Controls.Add(this.batchLabel);
            this.Controls.Add(this.toLabel);
            this.Controls.Add(this.toDataTime);
            this.Controls.Add(this.fromLabel);
            this.Controls.Add(this.gradeLabel);
            this.Controls.Add(this.sectionLabel);
            this.Controls.Add(this.name);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.fromDateTime);
            this.Controls.Add(this.attendanceLabel);
            this.MaximizeBox = false;
            this.Name = "AttendanceForm";
            this.Text = "AttendanceForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button getAttendanceButton;
        private Label batchLabel;
        private Label toLabel;
        private DateTimePicker toDataTime;
        private Label fromLabel;
        private Label gradeLabel;
        private Label sectionLabel;
        private TextBox name;
        private Label nameLabel;
        private DateTimePicker fromDateTime;
        private Label attendanceLabel;
        private ComboBox batchComboBox;
        private ComboBox gradeComboBox;
        private ComboBox subjectComboBox;
        private Label periodLabel;
        private TextBox email;
        private Label label1;
        private ComboBox ComboBox;
    }
}