namespace Ms_teams_bot_prototype;

partial class CreateSection
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
            this.createSectionButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.sectionNameValue = new System.Windows.Forms.TextBox();
            this.roleComboBox = new System.Windows.Forms.ComboBox();
            this.roleLabel = new System.Windows.Forms.Label();
            this.sectionNameLabel = new System.Windows.Forms.Label();
            this.gradeComboBox = new System.Windows.Forms.ComboBox();
            this.batchComboBox = new System.Windows.Forms.ComboBox();
            this.gradeLabel = new System.Windows.Forms.Label();
            this.batchLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.formGroupBox = new System.Windows.Forms.GroupBox();
            this.addButton = new System.Windows.Forms.Button();
            this.subjectLabel = new System.Windows.Forms.Label();
            this.subjectComboBox = new System.Windows.Forms.ComboBox();
            this.emailValue = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.nameValue = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.attendeesListBox = new System.Windows.Forms.ListBox();
            this.formGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // createSectionButton
            // 
            this.createSectionButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.createSectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createSectionButton.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.createSectionButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.createSectionButton.Location = new System.Drawing.Point(375, 470);
            this.createSectionButton.Name = "createSectionButton";
            this.createSectionButton.Size = new System.Drawing.Size(244, 72);
            this.createSectionButton.TabIndex = 52;
            this.createSectionButton.Text = "Create Section";
            this.createSectionButton.UseVisualStyleBackColor = false;
            this.createSectionButton.Click += new System.EventHandler(this.createSectionButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.deleteButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.deleteButton.Location = new System.Drawing.Point(745, 266);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(173, 72);
            this.deleteButton.TabIndex = 51;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // sectionNameValue
            // 
            this.sectionNameValue.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sectionNameValue.Location = new System.Drawing.Point(394, 116);
            this.sectionNameValue.Name = "sectionNameValue";
            this.sectionNameValue.Size = new System.Drawing.Size(72, 43);
            this.sectionNameValue.TabIndex = 50;
            // 
            // roleComboBox
            // 
            this.roleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roleComboBox.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.roleComboBox.FormattingEnabled = true;
            this.roleComboBox.Location = new System.Drawing.Point(590, 116);
            this.roleComboBox.Name = "roleComboBox";
            this.roleComboBox.Size = new System.Drawing.Size(158, 45);
            this.roleComboBox.TabIndex = 49;
            this.roleComboBox.SelectedIndexChanged += new System.EventHandler(this.roleComboBox_SelectedIndexChanged);
            // 
            // roleLabel
            // 
            this.roleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.roleLabel.AutoSize = true;
            this.roleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.roleLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.roleLabel.Location = new System.Drawing.Point(491, 116);
            this.roleLabel.Name = "roleLabel";
            this.roleLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.roleLabel.Size = new System.Drawing.Size(91, 37);
            this.roleLabel.TabIndex = 48;
            this.roleLabel.Text = "Role : ";
            this.roleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sectionNameLabel
            // 
            this.sectionNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sectionNameLabel.AutoSize = true;
            this.sectionNameLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sectionNameLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.sectionNameLabel.Location = new System.Drawing.Point(193, 116);
            this.sectionNameLabel.Name = "sectionNameLabel";
            this.sectionNameLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sectionNameLabel.Size = new System.Drawing.Size(209, 37);
            this.sectionNameLabel.TabIndex = 47;
            this.sectionNameLabel.Text = "Section Name : ";
            this.sectionNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradeComboBox
            // 
            this.gradeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gradeComboBox.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gradeComboBox.FormattingEnabled = true;
            this.gradeComboBox.Location = new System.Drawing.Point(491, 57);
            this.gradeComboBox.Name = "gradeComboBox";
            this.gradeComboBox.Size = new System.Drawing.Size(282, 45);
            this.gradeComboBox.TabIndex = 46;
            // 
            // batchComboBox
            // 
            this.batchComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.batchComboBox.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.batchComboBox.FormattingEnabled = true;
            this.batchComboBox.Location = new System.Drawing.Point(266, 57);
            this.batchComboBox.Name = "batchComboBox";
            this.batchComboBox.Size = new System.Drawing.Size(121, 45);
            this.batchComboBox.TabIndex = 45;
            this.batchComboBox.SelectedIndexChanged += new System.EventHandler(this.batchComboBox_SelectedIndexChanged);
            // 
            // gradeLabel
            // 
            this.gradeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gradeLabel.AutoSize = true;
            this.gradeLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gradeLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.gradeLabel.Location = new System.Drawing.Point(392, 57);
            this.gradeLabel.Name = "gradeLabel";
            this.gradeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gradeLabel.Size = new System.Drawing.Size(111, 37);
            this.gradeLabel.TabIndex = 44;
            this.gradeLabel.Text = "Grade : ";
            this.gradeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // batchLabel
            // 
            this.batchLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.batchLabel.AutoSize = true;
            this.batchLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.batchLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.batchLabel.Location = new System.Drawing.Point(171, 57);
            this.batchLabel.Name = "batchLabel";
            this.batchLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.batchLabel.Size = new System.Drawing.Size(107, 37);
            this.batchLabel.TabIndex = 43;
            this.batchLabel.Text = "Batch : ";
            this.batchLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.titleLabel.Location = new System.Drawing.Point(391, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.titleLabel.Size = new System.Drawing.Size(194, 37);
            this.titleLabel.TabIndex = 41;
            this.titleLabel.Text = "Create Section";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // formGroupBox
            // 
            this.formGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.formGroupBox.Controls.Add(this.addButton);
            this.formGroupBox.Controls.Add(this.subjectLabel);
            this.formGroupBox.Controls.Add(this.subjectComboBox);
            this.formGroupBox.Controls.Add(this.emailValue);
            this.formGroupBox.Controls.Add(this.emailLabel);
            this.formGroupBox.Controls.Add(this.nameValue);
            this.formGroupBox.Controls.Add(this.nameLabel);
            this.formGroupBox.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.formGroupBox.ForeColor = System.Drawing.Color.DimGray;
            this.formGroupBox.Location = new System.Drawing.Point(20, 161);
            this.formGroupBox.Name = "formGroupBox";
            this.formGroupBox.Size = new System.Drawing.Size(443, 303);
            this.formGroupBox.TabIndex = 40;
            this.formGroupBox.TabStop = false;
            this.formGroupBox.Text = "Create Student";
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.addButton.Location = new System.Drawing.Point(128, 222);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(197, 72);
            this.addButton.TabIndex = 26;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // subjectLabel
            // 
            this.subjectLabel.AutoSize = true;
            this.subjectLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.subjectLabel.ForeColor = System.Drawing.Color.Black;
            this.subjectLabel.Location = new System.Drawing.Point(6, 178);
            this.subjectLabel.Name = "subjectLabel";
            this.subjectLabel.Size = new System.Drawing.Size(105, 32);
            this.subjectLabel.TabIndex = 17;
            this.subjectLabel.Text = "Subject :";
            // 
            // subjectComboBox
            // 
            this.subjectComboBox.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.subjectComboBox.FormattingEnabled = true;
            this.subjectComboBox.Location = new System.Drawing.Point(111, 171);
            this.subjectComboBox.Name = "subjectComboBox";
            this.subjectComboBox.Size = new System.Drawing.Size(158, 45);
            this.subjectComboBox.TabIndex = 16;
            // 
            // emailValue
            // 
            this.emailValue.Location = new System.Drawing.Point(111, 111);
            this.emailValue.Name = "emailValue";
            this.emailValue.Size = new System.Drawing.Size(290, 43);
            this.emailValue.TabIndex = 3;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.emailLabel.ForeColor = System.Drawing.Color.Black;
            this.emailLabel.Location = new System.Drawing.Point(6, 118);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(83, 32);
            this.emailLabel.TabIndex = 2;
            this.emailLabel.Text = "Email :";
            // 
            // nameValue
            // 
            this.nameValue.Location = new System.Drawing.Point(111, 50);
            this.nameValue.Name = "nameValue";
            this.nameValue.Size = new System.Drawing.Size(290, 43);
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
            this.attendeesListBox.Location = new System.Drawing.Point(475, 175);
            this.attendeesListBox.Name = "attendeesListBox";
            this.attendeesListBox.Size = new System.Drawing.Size(264, 289);
            this.attendeesListBox.TabIndex = 42;
            // 
            // CreateSection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 549);
            this.Controls.Add(this.createSectionButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.sectionNameValue);
            this.Controls.Add(this.roleComboBox);
            this.Controls.Add(this.roleLabel);
            this.Controls.Add(this.sectionNameLabel);
            this.Controls.Add(this.gradeComboBox);
            this.Controls.Add(this.batchComboBox);
            this.Controls.Add(this.gradeLabel);
            this.Controls.Add(this.batchLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.formGroupBox);
            this.Controls.Add(this.attendeesListBox);
            this.Name = "CreateSection";
            this.Text = "CreateSection";
            this.formGroupBox.ResumeLayout(false);
            this.formGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private Button createSectionButton;
    private Button deleteButton;
    private TextBox sectionNameValue;
    private ComboBox roleComboBox;
    private Label roleLabel;
    private Label sectionNameLabel;
    private ComboBox gradeComboBox;
    private ComboBox batchComboBox;
    private Label gradeLabel;
    private Label batchLabel;
    private Label titleLabel;
    private GroupBox formGroupBox;
    private Button addButton;
    private Label subjectLabel;
    private ComboBox subjectComboBox;
    private TextBox emailValue;
    private Label emailLabel;
    private TextBox nameValue;
    private Label nameLabel;
    private ListBox attendeesListBox;
}
