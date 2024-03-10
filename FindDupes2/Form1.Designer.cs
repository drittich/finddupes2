namespace FindDupes2
{
    partial class Form1
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
            this.lblSource = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtSearchFolder = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.cboMinSize = new System.Windows.Forms.ComboBox();
            this.lblMinSize = new System.Windows.Forms.Label();
            this.chkMatchNames = new System.Windows.Forms.CheckBox();
            this.lblTotalFileCount = new System.Windows.Forms.Label();
            this.txtTotalFileCount = new System.Windows.Forms.TextBox();
            this.lblFilesCompared = new System.Windows.Forms.Label();
            this.txtFilesCompared = new System.Windows.Forms.TextBox();
            this.lblPotentialSavings = new System.Windows.Forms.Label();
            this.txtPotentialSavings = new System.Windows.Forms.TextBox();
            this.lblTotalDirectoryCount = new System.Windows.Forms.Label();
            this.txtTotalDirectoryCount = new System.Windows.Forms.TextBox();
            this.lblDuplicateCount = new System.Windows.Forms.Label();
            this.txtDuplicateCount = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(21, 15);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(44, 13);
            this.lblSource.TabIndex = 0;
            this.lblSource.Text = "Source:";
            // 
            // txtSearchFolder
            // 
            this.txtSearchFolder.Location = new System.Drawing.Point(105, 12);
            this.txtSearchFolder.Name = "txtSearchFolder";
            this.txtSearchFolder.Size = new System.Drawing.Size(281, 20);
            this.txtSearchFolder.TabIndex = 1;
            this.txtSearchFolder.Text = "c:\\";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(392, 12);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(73, 21);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(105, 100);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(90, 35);
            this.btnGo.TabIndex = 3;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(199, 100);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 35);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(296, 100);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(90, 35);
            this.btnQuit.TabIndex = 3;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // cboMinSize
            // 
            this.cboMinSize.FormattingEnabled = true;
            this.cboMinSize.Items.AddRange(new object[] {
            "0",
            "10kB",
            "100kB",
            "1MB",
            "10MB",
            "100MB",
            "1GB"});
            this.cboMinSize.Location = new System.Drawing.Point(105, 38);
            this.cboMinSize.Name = "cboMinSize";
            this.cboMinSize.Size = new System.Drawing.Size(81, 21);
            this.cboMinSize.TabIndex = 5;
            // 
            // lblMinSize
            // 
            this.lblMinSize.AutoSize = true;
            this.lblMinSize.Location = new System.Drawing.Point(21, 41);
            this.lblMinSize.Name = "lblMinSize";
            this.lblMinSize.Size = new System.Drawing.Size(74, 13);
            this.lblMinSize.TabIndex = 0;
            this.lblMinSize.Text = "Minimum Size:";
            // 
            // chkMatchNames
            // 
            this.chkMatchNames.AutoSize = true;
            this.chkMatchNames.Checked = true;
            this.chkMatchNames.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMatchNames.Location = new System.Drawing.Point(486, 16);
            this.chkMatchNames.Name = "chkMatchNames";
            this.chkMatchNames.Size = new System.Drawing.Size(92, 17);
            this.chkMatchNames.TabIndex = 7;
            this.chkMatchNames.Text = "Also Match Names";
            this.chkMatchNames.UseVisualStyleBackColor = true;
            // 
            // lblTotalFileCount
            // 
            this.lblTotalFileCount.AutoSize = true;
            this.lblTotalFileCount.Location = new System.Drawing.Point(217, 42);
            this.lblTotalFileCount.Name = "lblTotalFileCount";
            this.lblTotalFileCount.Size = new System.Drawing.Size(58, 13);
            this.lblTotalFileCount.TabIndex = 8;
            this.lblTotalFileCount.Text = "Total Files:";
            // 
            // txtTotalFileCount
            // 
            this.txtTotalFileCount.BackColor = System.Drawing.SystemColors.Window;
            this.txtTotalFileCount.Location = new System.Drawing.Point(305, 39);
            this.txtTotalFileCount.Name = "txtTotalFileCount";
            this.txtTotalFileCount.ReadOnly = true;
            this.txtTotalFileCount.Size = new System.Drawing.Size(81, 20);
            this.txtTotalFileCount.TabIndex = 9;
            // 
            // lblFilesCompared
            // 
            this.lblFilesCompared.AutoSize = true;
            this.lblFilesCompared.Location = new System.Drawing.Point(21, 68);
            this.lblFilesCompared.Name = "lblFilesCompared";
            this.lblFilesCompared.Size = new System.Drawing.Size(82, 13);
            this.lblFilesCompared.TabIndex = 8;
            this.lblFilesCompared.Text = "Files Compared:";
            // 
            // txtFilesCompared
            // 
            this.txtFilesCompared.BackColor = System.Drawing.SystemColors.Window;
            this.txtFilesCompared.Location = new System.Drawing.Point(105, 65);
            this.txtFilesCompared.Name = "txtFilesCompared";
            this.txtFilesCompared.ReadOnly = true;
            this.txtFilesCompared.Size = new System.Drawing.Size(81, 20);
            this.txtFilesCompared.TabIndex = 9;
            // 
            // lblPotentialSavings
            // 
            this.lblPotentialSavings.AutoSize = true;
            this.lblPotentialSavings.Location = new System.Drawing.Point(391, 68);
            this.lblPotentialSavings.Name = "lblPotentialSavings";
            this.lblPotentialSavings.Size = new System.Drawing.Size(92, 13);
            this.lblPotentialSavings.TabIndex = 8;
            this.lblPotentialSavings.Text = "Potential Savings:";
            // 
            // txtPotentialSavings
            // 
            this.txtPotentialSavings.BackColor = System.Drawing.SystemColors.Window;
            this.txtPotentialSavings.Location = new System.Drawing.Point(485, 65);
            this.txtPotentialSavings.Name = "txtPotentialSavings";
            this.txtPotentialSavings.ReadOnly = true;
            this.txtPotentialSavings.Size = new System.Drawing.Size(81, 20);
            this.txtPotentialSavings.TabIndex = 9;
            // 
            // lblTotalDirectoryCount
            // 
            this.lblTotalDirectoryCount.AutoSize = true;
            this.lblTotalDirectoryCount.Location = new System.Drawing.Point(390, 41);
            this.lblTotalDirectoryCount.Name = "lblTotalDirectoryCount";
            this.lblTotalDirectoryCount.Size = new System.Drawing.Size(87, 13);
            this.lblTotalDirectoryCount.TabIndex = 8;
            this.lblTotalDirectoryCount.Text = "Total Directories:";
            // 
            // txtTotalDirectoryCount
            // 
            this.txtTotalDirectoryCount.BackColor = System.Drawing.SystemColors.Window;
            this.txtTotalDirectoryCount.Location = new System.Drawing.Point(485, 38);
            this.txtTotalDirectoryCount.Name = "txtTotalDirectoryCount";
            this.txtTotalDirectoryCount.ReadOnly = true;
            this.txtTotalDirectoryCount.Size = new System.Drawing.Size(81, 20);
            this.txtTotalDirectoryCount.TabIndex = 9;
            // 
            // lblDuplicateCount
            // 
            this.lblDuplicateCount.AutoSize = true;
            this.lblDuplicateCount.Location = new System.Drawing.Point(217, 68);
            this.lblDuplicateCount.Name = "lblDuplicateCount";
            this.lblDuplicateCount.Size = new System.Drawing.Size(86, 13);
            this.lblDuplicateCount.TabIndex = 8;
            this.lblDuplicateCount.Text = "Duplicate Count:";
            // 
            // txtDuplicateCount
            // 
            this.txtDuplicateCount.BackColor = System.Drawing.SystemColors.Window;
            this.txtDuplicateCount.Location = new System.Drawing.Point(305, 65);
            this.txtDuplicateCount.Name = "txtDuplicateCount";
            this.txtDuplicateCount.ReadOnly = true;
            this.txtDuplicateCount.Size = new System.Drawing.Size(81, 20);
            this.txtDuplicateCount.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 158);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(751, 503);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(424, 100);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(142, 35);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete Selected Files";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 683);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtDuplicateCount);
            this.Controls.Add(this.lblDuplicateCount);
            this.Controls.Add(this.txtPotentialSavings);
            this.Controls.Add(this.lblPotentialSavings);
            this.Controls.Add(this.txtFilesCompared);
            this.Controls.Add(this.lblFilesCompared);
            this.Controls.Add(this.txtTotalDirectoryCount);
            this.Controls.Add(this.lblTotalDirectoryCount);
            this.Controls.Add(this.txtTotalFileCount);
            this.Controls.Add(this.lblTotalFileCount);
            this.Controls.Add(this.chkMatchNames);
            this.Controls.Add(this.cboMinSize);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtSearchFolder);
            this.Controls.Add(this.lblMinSize);
            this.Controls.Add(this.lblSource);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FindDupes";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtSearchFolder;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.ComboBox cboMinSize;
        private System.Windows.Forms.Label lblMinSize;
        private System.Windows.Forms.CheckBox chkMatchNames;
        private System.Windows.Forms.Label lblTotalFileCount;
        private System.Windows.Forms.TextBox txtTotalFileCount;
        private System.Windows.Forms.Label lblFilesCompared;
        private System.Windows.Forms.TextBox txtFilesCompared;
        private System.Windows.Forms.Label lblPotentialSavings;
        private System.Windows.Forms.TextBox txtPotentialSavings;
        private System.Windows.Forms.Label lblTotalDirectoryCount;
        private System.Windows.Forms.TextBox txtTotalDirectoryCount;
        private System.Windows.Forms.Label lblDuplicateCount;
        private System.Windows.Forms.TextBox txtDuplicateCount;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDelete;
    }
}

