namespace AzureDiagnosticLogReader
{
    partial class AzureLogForm
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
            PresentationControls.CheckBoxProperties checkBoxProperties1 = new PresentationControls.CheckBoxProperties();
            PresentationControls.CheckBoxProperties checkBoxProperties2 = new PresentationControls.CheckBoxProperties();
            this.FromDateLabel = new System.Windows.Forms.Label();
            this.FromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ToDateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.ToDateLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FilterTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.RunButton = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnUpdateLog = new System.Windows.Forms.Button();
            this.LogDisplayView = new System.Windows.Forms.DataGridView();
            this.gridViewEntryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbSelectedLine = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cbAutoRefresh = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbInstanceFilter = new PresentationControls.CheckBoxComboBox();
            this.cbEventIdFilter = new PresentationControls.CheckBoxComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cbLogLevel = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.EnvironmentComboBox = new System.Windows.Forms.ComboBox();
            this.logEntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.entryDateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoleInstance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.messageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeploymentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.LogDisplayView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEntryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logEntityBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // FromDateLabel
            // 
            this.FromDateLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FromDateLabel.AutoSize = true;
            this.FromDateLabel.Location = new System.Drawing.Point(3, 8);
            this.FromDateLabel.Name = "FromDateLabel";
            this.FromDateLabel.Size = new System.Drawing.Size(56, 13);
            this.FromDateLabel.TabIndex = 0;
            this.FromDateLabel.Text = "From Date";
            // 
            // FromDateTimePicker
            // 
            this.FromDateTimePicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FromDateTimePicker.CustomFormat = "dd/MM/yyyy HH:mm";
            this.FromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FromDateTimePicker.Location = new System.Drawing.Point(72, 5);
            this.FromDateTimePicker.Name = "FromDateTimePicker";
            this.FromDateTimePicker.Size = new System.Drawing.Size(133, 20);
            this.FromDateTimePicker.TabIndex = 1;
            // 
            // ToDateTimePicker1
            // 
            this.ToDateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ToDateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm";
            this.ToDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ToDateTimePicker1.Location = new System.Drawing.Point(72, 35);
            this.ToDateTimePicker1.Name = "ToDateTimePicker1";
            this.ToDateTimePicker1.Size = new System.Drawing.Size(133, 20);
            this.ToDateTimePicker1.TabIndex = 3;
            // 
            // ToDateLabel
            // 
            this.ToDateLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ToDateLabel.AutoSize = true;
            this.ToDateLabel.Location = new System.Drawing.Point(3, 38);
            this.ToDateLabel.Name = "ToDateLabel";
            this.ToDateLabel.Size = new System.Drawing.Size(46, 13);
            this.ToDateLabel.TabIndex = 2;
            this.ToDateLabel.Text = "To Date";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(211, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Environment";
            // 
            // FilterTextBox
            // 
            this.FilterTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilterTextBox.Enabled = false;
            this.FilterTextBox.Location = new System.Drawing.Point(0, 0);
            this.FilterTextBox.Name = "FilterTextBox";
            this.FilterTextBox.Size = new System.Drawing.Size(240, 20);
            this.FilterTextBox.TabIndex = 9;
            this.toolTip1.SetToolTip(this.FilterTextBox, "Filter by only showing entries that contain this text in the message");
            this.FilterTextBox.Enter += new System.EventHandler(this.FilterTextBox_Enter);
            this.FilterTextBox.Leave += new System.EventHandler(this.FilterTextBox_Leave);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Message";
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnFilter.Enabled = false;
            this.btnFilter.Location = new System.Drawing.Point(495, 3);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 14;
            this.btnFilter.Text = "Filter";
            this.toolTip1.SetToolTip(this.btnFilter, "Filter already fetched entries");
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // RunButton
            // 
            this.RunButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RunButton.Location = new System.Drawing.Point(282, 33);
            this.RunButton.Margin = new System.Windows.Forms.Padding(0);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(70, 24);
            this.RunButton.TabIndex = 5;
            this.RunButton.Text = "Query Logs";
            this.toolTip1.SetToolTip(this.RunButton, "Fetch entries defined by the From and To Dates and the Environment");
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnClear.Enabled = false;
            this.btnClear.Location = new System.Drawing.Point(495, 33);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "Clear";
            this.toolTip1.SetToolTip(this.btnClear, "Clear the filter and show all fetched entries");
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnUpdateLog
            // 
            this.btnUpdateLog.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnUpdateLog.Enabled = false;
            this.btnUpdateLog.Location = new System.Drawing.Point(404, 33);
            this.btnUpdateLog.Margin = new System.Windows.Forms.Padding(0);
            this.btnUpdateLog.Name = "btnUpdateLog";
            this.btnUpdateLog.Size = new System.Drawing.Size(70, 24);
            this.btnUpdateLog.TabIndex = 16;
            this.btnUpdateLog.Text = "Update Log";
            this.toolTip1.SetToolTip(this.btnUpdateLog, "Updates the To Date to NOW and fetches log entries more recent than already fetch" +
        "ed.");
            this.btnUpdateLog.UseVisualStyleBackColor = true;
            this.btnUpdateLog.Click += new System.EventHandler(this.btnUpdateLog_Click);
            // 
            // LogDisplayView
            // 
            this.LogDisplayView.AllowUserToAddRows = false;
            this.LogDisplayView.AllowUserToDeleteRows = false;
            this.LogDisplayView.AllowUserToOrderColumns = true;
            this.LogDisplayView.AllowUserToResizeRows = false;
            this.LogDisplayView.AutoGenerateColumns = false;
            this.LogDisplayView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.LogDisplayView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.entryDateTimeDataGridViewTextBoxColumn,
            this.RoleInstance,
            this.eventIdDataGridViewTextBoxColumn,
            this.messageDataGridViewTextBoxColumn,
            this.DeploymentName,
            this.Level});
            this.LogDisplayView.DataSource = this.gridViewEntryBindingSource;
            this.LogDisplayView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogDisplayView.Location = new System.Drawing.Point(0, 0);
            this.LogDisplayView.Name = "LogDisplayView";
            this.LogDisplayView.ReadOnly = true;
            this.LogDisplayView.Size = new System.Drawing.Size(1067, 395);
            this.LogDisplayView.TabIndex = 13;
            this.LogDisplayView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.LogDisplayView_CellEnter);
            this.LogDisplayView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.LogDisplayView_CellMouseDoubleClick);
            this.LogDisplayView.SelectionChanged += new System.EventHandler(this.LogDisplayView_SelectionChanged);
            // 
            // gridViewEntryBindingSource
            // 
            this.gridViewEntryBindingSource.DataSource = typeof(AzureDiagnosticLogReader.AzureLogForm.GridViewEntry);
            // 
            // tbSelectedLine
            // 
            this.tbSelectedLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSelectedLine.Location = new System.Drawing.Point(0, 0);
            this.tbSelectedLine.Name = "tbSelectedLine";
            this.tbSelectedLine.Size = new System.Drawing.Size(1067, 156);
            this.tbSelectedLine.TabIndex = 17;
            this.tbSelectedLine.Text = "";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 73);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.LogDisplayView);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbSelectedLine);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(1067, 555);
            this.splitContainer1.SplitterDistance = 395;
            this.splitContainer1.TabIndex = 18;
            // 
            // cbAutoRefresh
            // 
            this.cbAutoRefresh.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbAutoRefresh.AutoSize = true;
            this.tableLayoutPanel4.SetColumnSpan(this.cbAutoRefresh, 2);
            this.cbAutoRefresh.Enabled = false;
            this.cbAutoRefresh.Location = new System.Drawing.Point(3, 36);
            this.cbAutoRefresh.Name = "cbAutoRefresh";
            this.cbAutoRefresh.Size = new System.Drawing.Size(114, 17);
            this.cbAutoRefresh.TabIndex = 19;
            this.cbAutoRefresh.Text = "Auto Refresh (60s)";
            this.cbAutoRefresh.UseVisualStyleBackColor = true;
            this.cbAutoRefresh.CheckedChanged += new System.EventHandler(this.cbAutoRefresh_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(167, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Event Id";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 671);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1073, 22);
            this.statusStrip1.TabIndex = 23;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(331, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Instance";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSave.Location = new System.Drawing.Point(211, 33);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(67, 24);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "Save CSV";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbInstanceFilter
            // 
            this.cbInstanceFilter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            checkBoxProperties1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbInstanceFilter.CheckBoxProperties = checkBoxProperties1;
            this.cbInstanceFilter.DisplayMemberSingleItem = "";
            this.cbInstanceFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInstanceFilter.FormattingEnabled = true;
            this.cbInstanceFilter.Location = new System.Drawing.Point(413, 34);
            this.cbInstanceFilter.Name = "cbInstanceFilter";
            this.cbInstanceFilter.Size = new System.Drawing.Size(71, 21);
            this.cbInstanceFilter.Sorted = true;
            this.cbInstanceFilter.TabIndex = 24;
            // 
            // cbEventIdFilter
            // 
            this.cbEventIdFilter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            checkBoxProperties2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbEventIdFilter.CheckBoxProperties = checkBoxProperties2;
            this.cbEventIdFilter.DisplayMemberSingleItem = "";
            this.cbEventIdFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEventIdFilter.FormattingEnabled = true;
            this.cbEventIdFilter.Location = new System.Drawing.Point(249, 34);
            this.cbEventIdFilter.Name = "cbEventIdFilter";
            this.cbEventIdFilter.Size = new System.Drawing.Size(71, 21);
            this.cbEventIdFilter.Sorted = true;
            this.cbEventIdFilter.TabIndex = 22;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1073, 671);
            this.tableLayoutPanel1.TabIndex = 29;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1067, 64);
            this.tableLayoutPanel2.TabIndex = 30;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 7;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.Controls.Add(this.btnFilter, 6, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnClear, 6, 1);
            this.tableLayoutPanel4.Controls.Add(this.cbInstanceFilter, 5, 1);
            this.tableLayoutPanel4.Controls.Add(this.label2, 4, 1);
            this.tableLayoutPanel4.Controls.Add(this.cbEventIdFilter, 3, 1);
            this.tableLayoutPanel4.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.cbAutoRefresh, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.panel1, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.cbLogLevel, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(483, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(581, 58);
            this.tableLayoutPanel4.TabIndex = 32;
            // 
            // panel1
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.panel1, 3);
            this.panel1.Controls.Add(this.FilterTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(249, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 24);
            this.panel1.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Level";
            // 
            // cbLogLevel
            // 
            this.cbLogLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLogLevel.FormattingEnabled = true;
            this.cbLogLevel.Location = new System.Drawing.Point(85, 3);
            this.cbLogLevel.Name = "cbLogLevel";
            this.cbLogLevel.Size = new System.Drawing.Size(76, 21);
            this.cbLogLevel.TabIndex = 28;
            this.cbLogLevel.SelectedIndexChanged += new System.EventHandler(this.cbLogLevel_SelectedIndexChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.70588F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.41176F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.68627F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.58824F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.60784F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnUpdateLog, 4, 1);
            this.tableLayoutPanel3.Controls.Add(this.RunButton, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnSave, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.ToDateTimePicker1, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.FromDateTimePicker, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.ToDateLabel, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.EnvironmentComboBox, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.FromDateLabel, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(474, 58);
            this.tableLayoutPanel3.TabIndex = 31;
            // 
            // EnvironmentComboBox
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.EnvironmentComboBox, 2);
            this.EnvironmentComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EnvironmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EnvironmentComboBox.FormattingEnabled = true;
            this.EnvironmentComboBox.Location = new System.Drawing.Point(282, 3);
            this.EnvironmentComboBox.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.EnvironmentComboBox.Name = "EnvironmentComboBox";
            this.EnvironmentComboBox.Size = new System.Drawing.Size(192, 21);
            this.EnvironmentComboBox.TabIndex = 6;
            // 
            // logEntityBindingSource
            // 
            this.logEntityBindingSource.DataSource = typeof(AzureDiagnosticLogReader.LogEntity);
            // 
            // entryDateTimeDataGridViewTextBoxColumn
            // 
            this.entryDateTimeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.entryDateTimeDataGridViewTextBoxColumn.DataPropertyName = "EntryDateTime";
            this.entryDateTimeDataGridViewTextBoxColumn.HeaderText = "EntryDateTime";
            this.entryDateTimeDataGridViewTextBoxColumn.Name = "entryDateTimeDataGridViewTextBoxColumn";
            this.entryDateTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.entryDateTimeDataGridViewTextBoxColumn.Width = 102;
            // 
            // RoleInstance
            // 
            this.RoleInstance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.RoleInstance.DataPropertyName = "RoleInstance";
            this.RoleInstance.HeaderText = "RI";
            this.RoleInstance.Name = "RoleInstance";
            this.RoleInstance.ReadOnly = true;
            this.RoleInstance.Width = 60;
            // 
            // eventIdDataGridViewTextBoxColumn
            // 
            this.eventIdDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.eventIdDataGridViewTextBoxColumn.DataPropertyName = "EventId";
            this.eventIdDataGridViewTextBoxColumn.HeaderText = "EventId";
            this.eventIdDataGridViewTextBoxColumn.Name = "eventIdDataGridViewTextBoxColumn";
            this.eventIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.eventIdDataGridViewTextBoxColumn.Width = 69;
            // 
            // messageDataGridViewTextBoxColumn
            // 
            this.messageDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.messageDataGridViewTextBoxColumn.DataPropertyName = "Message";
            this.messageDataGridViewTextBoxColumn.HeaderText = "Message";
            this.messageDataGridViewTextBoxColumn.Name = "messageDataGridViewTextBoxColumn";
            this.messageDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // DeploymentName
            // 
            this.DeploymentName.DataPropertyName = "DeploymentName";
            this.DeploymentName.HeaderText = "DeploymentName";
            this.DeploymentName.Name = "DeploymentName";
            this.DeploymentName.ReadOnly = true;
            // 
            // Level
            // 
            this.Level.DataPropertyName = "Level";
            this.Level.HeaderText = "Level";
            this.Level.Name = "Level";
            this.Level.ReadOnly = true;
            // 
            // AzureLogForm
            // 
            this.AcceptButton = this.RunButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 693);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "AzureLogForm";
            this.Text = "Azure Diagnostics Log";
            this.Load += new System.EventHandler(this.AzureLogForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LogDisplayView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEntryBindingSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logEntityBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FromDateLabel;
        private System.Windows.Forms.DateTimePicker FromDateTimePicker;
        private System.Windows.Forms.DateTimePicker ToDateTimePicker1;
        private System.Windows.Forms.Label ToDateLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FilterTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.BindingSource logEntityBindingSource;
        private System.Windows.Forms.BindingSource gridViewEntryBindingSource;
        private System.Windows.Forms.DataGridView LogDisplayView;
        private System.Windows.Forms.RichTextBox tbSelectedLine;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnUpdateLog;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox cbAutoRefresh;
        private System.Windows.Forms.Label label4;
        private PresentationControls.CheckBoxComboBox cbEventIdFilter;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private PresentationControls.CheckBoxComboBox cbInstanceFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ComboBox EnvironmentComboBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbLogLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn entryDateTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoleInstance;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn messageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeploymentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Level;
    }
}

