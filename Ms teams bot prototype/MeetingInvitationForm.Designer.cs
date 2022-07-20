namespace Ms_teams_bot_prototype
{
    partial class MeetingInvitationForm
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
            this.declineButton = new System.Windows.Forms.Button();
            this.acceptButton = new System.Windows.Forms.Button();
            this.meetingInvitationLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // declineButton
            // 
            this.declineButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.declineButton.AutoSize = true;
            this.declineButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.declineButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.declineButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.declineButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.declineButton.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.declineButton.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.declineButton.Location = new System.Drawing.Point(214, 132);
            this.declineButton.Name = "declineButton";
            this.declineButton.Size = new System.Drawing.Size(180, 76);
            this.declineButton.TabIndex = 77;
            this.declineButton.Text = "Decline";
            this.declineButton.UseVisualStyleBackColor = false;
            this.declineButton.Click += new System.EventHandler(this.declineButton_Click);
            // 
            // acceptButton
            // 
            this.acceptButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.acceptButton.AutoSize = true;
            this.acceptButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.acceptButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.acceptButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.acceptButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.acceptButton.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.acceptButton.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.acceptButton.Location = new System.Drawing.Point(12, 132);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(185, 76);
            this.acceptButton.TabIndex = 76;
            this.acceptButton.Text = "Accept";
            this.acceptButton.UseVisualStyleBackColor = false;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // meetingInvitationLabel
            // 
            this.meetingInvitationLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.meetingInvitationLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.meetingInvitationLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.meetingInvitationLabel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.meetingInvitationLabel.Location = new System.Drawing.Point(0, 0);
            this.meetingInvitationLabel.Name = "meetingInvitationLabel";
            this.meetingInvitationLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.meetingInvitationLabel.Size = new System.Drawing.Size(406, 74);
            this.meetingInvitationLabel.TabIndex = 75;
            this.meetingInvitationLabel.Text = "<none>";
            this.meetingInvitationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MeetingInvitationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 267);
            this.Controls.Add(this.declineButton);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.meetingInvitationLabel);
            this.Name = "MeetingInvitationForm";
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button declineButton;
        private Button acceptButton;
        private Label meetingInvitationLabel;
    }
}