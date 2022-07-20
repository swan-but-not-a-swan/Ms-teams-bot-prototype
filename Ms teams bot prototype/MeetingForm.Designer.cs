namespace Ms_teams_bot_prototype
{
    partial class MeetingForm
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.schoolLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ParticipantFormGroupBox = new System.Windows.Forms.GroupBox();
            this.emailValue = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.nameValue = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.attendeesListBox = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.joinButton = new System.Windows.Forms.Button();
            this.leaveButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.ParticipantFormGroupBox.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(676, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.schoolLabel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(276, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(123, 37);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // schoolLabel
            // 
            this.schoolLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.schoolLabel.AutoSize = true;
            this.schoolLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.schoolLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.schoolLabel.Location = new System.Drawing.Point(3, 0);
            this.schoolLabel.Name = "schoolLabel";
            this.schoolLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.schoolLabel.Size = new System.Drawing.Size(117, 37);
            this.schoolLabel.TabIndex = 0;
            this.schoolLabel.Text = "<none>";
            this.schoolLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.1194F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.8806F));
            this.tableLayoutPanel2.Controls.Add(this.ParticipantFormGroupBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.attendeesListBox, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 48);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(670, 309);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // ParticipantFormGroupBox
            // 
            this.ParticipantFormGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ParticipantFormGroupBox.Controls.Add(this.emailValue);
            this.ParticipantFormGroupBox.Controls.Add(this.emailLabel);
            this.ParticipantFormGroupBox.Controls.Add(this.nameValue);
            this.ParticipantFormGroupBox.Controls.Add(this.nameLabel);
            this.ParticipantFormGroupBox.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ParticipantFormGroupBox.ForeColor = System.Drawing.Color.DimGray;
            this.ParticipantFormGroupBox.Location = new System.Drawing.Point(3, 3);
            this.ParticipantFormGroupBox.Name = "ParticipantFormGroupBox";
            this.ParticipantFormGroupBox.Size = new System.Drawing.Size(369, 303);
            this.ParticipantFormGroupBox.TabIndex = 0;
            this.ParticipantFormGroupBox.TabStop = false;
            this.ParticipantFormGroupBox.Text = "Pariticipant Form";
            // 
            // emailValue
            // 
            this.emailValue.Location = new System.Drawing.Point(95, 122);
            this.emailValue.Name = "emailValue";
            this.emailValue.Size = new System.Drawing.Size(268, 43);
            this.emailValue.TabIndex = 3;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.emailLabel.ForeColor = System.Drawing.Color.Black;
            this.emailLabel.Location = new System.Drawing.Point(6, 129);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(83, 32);
            this.emailLabel.TabIndex = 2;
            this.emailLabel.Text = "Email :";
            // 
            // nameValue
            // 
            this.nameValue.Location = new System.Drawing.Point(95, 50);
            this.nameValue.Name = "nameValue";
            this.nameValue.Size = new System.Drawing.Size(268, 43);
            this.nameValue.TabIndex = 1;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nameLabel.ForeColor = System.Drawing.Color.Black;
            this.nameLabel.Location = new System.Drawing.Point(6, 57);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(90, 32);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name :";
            // 
            // attendeesListBox
            // 
            this.attendeesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.attendeesListBox.FormattingEnabled = true;
            this.attendeesListBox.ItemHeight = 15;
            this.attendeesListBox.Location = new System.Drawing.Point(378, 10);
            this.attendeesListBox.Name = "attendeesListBox";
            this.attendeesListBox.Size = new System.Drawing.Size(289, 289);
            this.attendeesListBox.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel2.Controls.Add(this.joinButton);
            this.flowLayoutPanel2.Controls.Add(this.leaveButton);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(135, 363);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(406, 84);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // joinButton
            // 
            this.joinButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.joinButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.joinButton.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.joinButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.joinButton.Location = new System.Drawing.Point(3, 3);
            this.joinButton.Name = "joinButton";
            this.joinButton.Size = new System.Drawing.Size(197, 72);
            this.joinButton.TabIndex = 0;
            this.joinButton.Text = "Join";
            this.joinButton.UseVisualStyleBackColor = false;
            this.joinButton.Click += new System.EventHandler(this.joinButton_Click);
            // 
            // leaveButton
            // 
            this.leaveButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.leaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leaveButton.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.leaveButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.leaveButton.Location = new System.Drawing.Point(206, 3);
            this.leaveButton.Name = "leaveButton";
            this.leaveButton.Size = new System.Drawing.Size(197, 72);
            this.leaveButton.TabIndex = 1;
            this.leaveButton.Text = "Leave";
            this.leaveButton.UseVisualStyleBackColor = false;
            this.leaveButton.Click += new System.EventHandler(this.leaveButton_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 300000;
            // 
            // MeetingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MeetingForm";
            this.Text = "MeetingForm";
            this.Load += new System.EventHandler(this.MeetingForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ParticipantFormGroupBox.ResumeLayout(false);
            this.ParticipantFormGroupBox.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private GroupBox ParticipantFormGroupBox;
        private ListBox attendeesListBox;
        private Label schoolLabel;
        private Label nameLabel;
        private TextBox emailValue;
        private Label emailLabel;
        private TextBox nameValue;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button joinButton;
        private Button leaveButton;
        private System.Windows.Forms.Timer timer;
    }
}