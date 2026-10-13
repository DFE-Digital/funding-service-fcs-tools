namespace ReleaseBranchUtility
{
    partial class MainForm
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
            this.tbOrganisationUri = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTeamProject = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCommitId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbReleaseNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbReleaseLetter = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnValidate = new System.Windows.Forms.Button();
            this.cbForce = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCreateBranch = new System.Windows.Forms.Button();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.tbRepository = new System.Windows.Forms.TextBox();
            this.btnNextMajor = new System.Windows.Forms.Button();
            this.btnNextMinor = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbOrganisationUri
            // 
            this.tbOrganisationUri.Location = new System.Drawing.Point(118, 9);
            this.tbOrganisationUri.Name = "tbOrganisationUri";
            this.tbOrganisationUri.ReadOnly = true;
            this.tbOrganisationUri.Size = new System.Drawing.Size(289, 20);
            this.tbOrganisationUri.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Organisation Uri";
            // 
            // tbTeamProject
            // 
            this.tbTeamProject.Location = new System.Drawing.Point(118, 36);
            this.tbTeamProject.Name = "tbTeamProject";
            this.tbTeamProject.ReadOnly = true;
            this.tbTeamProject.Size = new System.Drawing.Size(289, 20);
            this.tbTeamProject.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Team Project";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Repository";
            // 
            // tbCommitId
            // 
            this.tbCommitId.Location = new System.Drawing.Point(118, 135);
            this.tbCommitId.MaxLength = 40;
            this.tbCommitId.Name = "tbCommitId";
            this.tbCommitId.Size = new System.Drawing.Size(289, 20);
            this.tbCommitId.TabIndex = 6;
            this.tbCommitId.TextChanged += new System.EventHandler(this.tbCommitId_TextChanged);
            this.tbCommitId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCommitId_KeyDown);
            this.tbCommitId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCommitId__KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Source Changeset";
            // 
            // tbReleaseNumber
            // 
            this.tbReleaseNumber.Location = new System.Drawing.Point(204, 207);
            this.tbReleaseNumber.Name = "tbReleaseNumber";
            this.tbReleaseNumber.Size = new System.Drawing.Size(41, 20);
            this.tbReleaseNumber.TabIndex = 8;
            this.tbReleaseNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbReleaseNumber_KeyDown);
            this.tbReleaseNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbReleaseNumber_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(112, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Release Number";
            // 
            // tbReleaseLetter
            // 
            this.tbReleaseLetter.Location = new System.Drawing.Point(333, 207);
            this.tbReleaseLetter.MaxLength = 1;
            this.tbReleaseLetter.Name = "tbReleaseLetter";
            this.tbReleaseLetter.Size = new System.Drawing.Size(20, 20);
            this.tbReleaseLetter.TabIndex = 10;
            this.tbReleaseLetter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbReleaseLetter_KeyDown);
            this.tbReleaseLetter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbReleaseLetter__KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(251, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Release Letter";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(412, 60);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 12;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnValidate
            // 
            this.btnValidate.Enabled = false;
            this.btnValidate.Location = new System.Drawing.Point(412, 133);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(75, 23);
            this.btnValidate.TabIndex = 14;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // cbForce
            // 
            this.cbForce.AutoSize = true;
            this.cbForce.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbForce.Location = new System.Drawing.Point(118, 94);
            this.cbForce.Name = "cbForce";
            this.cbForce.Size = new System.Drawing.Size(15, 14);
            this.cbForce.TabIndex = 15;
            this.cbForce.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(78, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Force";
            // 
            // btnCreateBranch
            // 
            this.btnCreateBranch.Location = new System.Drawing.Point(357, 205);
            this.btnCreateBranch.Name = "btnCreateBranch";
            this.btnCreateBranch.Size = new System.Drawing.Size(130, 23);
            this.btnCreateBranch.TabIndex = 17;
            this.btnCreateBranch.Text = "Create Custom Branch";
            this.btnCreateBranch.UseVisualStyleBackColor = true;
            this.btnCreateBranch.Click += new System.EventHandler(this.btnCreateBranch_Click);
            // 
            // tbLog
            // 
            this.tbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLog.Location = new System.Drawing.Point(12, 251);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(675, 272);
            this.tbLog.TabIndex = 18;
            // 
            // tbRepository
            // 
            this.tbRepository.Location = new System.Drawing.Point(118, 62);
            this.tbRepository.Name = "tbRepository";
            this.tbRepository.ReadOnly = true;
            this.tbRepository.Size = new System.Drawing.Size(289, 20);
            this.tbRepository.TabIndex = 19;
            // 
            // btnNextMajor
            // 
            this.btnNextMajor.Enabled = false;
            this.btnNextMajor.Location = new System.Drawing.Point(359, 163);
            this.btnNextMajor.Name = "btnNextMajor";
            this.btnNextMajor.Size = new System.Drawing.Size(128, 23);
            this.btnNextMajor.TabIndex = 20;
            this.btnNextMajor.UseVisualStyleBackColor = true;
            this.btnNextMajor.Click += new System.EventHandler(this.btnNextMajor_Click);
            // 
            // btnNextMinor
            // 
            this.btnNextMinor.Enabled = false;
            this.btnNextMinor.Location = new System.Drawing.Point(359, 89);
            this.btnNextMinor.Name = "btnNextMinor";
            this.btnNextMinor.Size = new System.Drawing.Size(128, 23);
            this.btnNextMinor.TabIndex = 21;
            this.btnNextMinor.UseVisualStyleBackColor = true;
            this.btnNextMinor.Click += new System.EventHandler(this.btnNextMinor_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(219, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Create Next Major Release";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(219, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Create Next Minor Release";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 535);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnNextMinor);
            this.Controls.Add(this.btnNextMajor);
            this.Controls.Add(this.tbRepository);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.btnCreateBranch);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbForce);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbReleaseLetter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbReleaseNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbCommitId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbTeamProject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbOrganisationUri);
            this.Name = "MainForm";
            this.Text = "Release Branch Utility";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbOrganisationUri;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTeamProject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCommitId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbReleaseNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbReleaseLetter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.CheckBox cbForce;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCreateBranch;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.TextBox tbRepository;
        private System.Windows.Forms.Button btnNextMajor;
        private System.Windows.Forms.Button btnNextMinor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}

