namespace Ms_teams_bot_prototype
{
    partial class MessageForm
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
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.messageShowerBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // messageBox
            // 
            this.messageBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.messageBox.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.messageBox.Location = new System.Drawing.Point(1, 467);
            this.messageBox.Multiline = true;
            this.messageBox.Name = "messageBox";
            this.messageBox.PlaceholderText = "Type here";
            this.messageBox.Size = new System.Drawing.Size(795, 41);
            this.messageBox.TabIndex = 4;
            // 
            // sendButton
            // 
            this.sendButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sendButton.AutoSize = true;
            this.sendButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.sendButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.sendButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.sendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendButton.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sendButton.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.sendButton.Location = new System.Drawing.Point(809, 467);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(117, 43);
            this.sendButton.TabIndex = 5;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // messageShowerBox
            // 
            this.messageShowerBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.messageShowerBox.Location = new System.Drawing.Point(3, 45);
            this.messageShowerBox.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.messageShowerBox.Multiline = true;
            this.messageShowerBox.Name = "messageShowerBox";
            this.messageShowerBox.ReadOnly = true;
            this.messageShowerBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.messageShowerBox.Size = new System.Drawing.Size(932, 415);
            this.messageShowerBox.TabIndex = 6;
            this.messageShowerBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(374, 4);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(208, 37);
            this.label1.TabIndex = 53;
            this.label1.Text = "Get Attendance";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(932, 514);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.messageShowerBox);
            this.MdiChildrenMinimizedAnchorBottom = false;
            this.Name = "MessageForm";
            this.Text = "MessageForm";
            this.Load += new System.EventHandler(this.MessageForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FolderBrowserDialog fbd;
        private TextBox messageBox;
        private Button sendButton;
        private TextBox messageShowerBox;
        private Label label1;
    }
}