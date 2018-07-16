namespace FileSearchAndAdd
{
    partial class MainGuiForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGuiForm));
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFilenameToSearchFor = new System.Windows.Forms.TextBox();
            this.lblFoldersWithSearchedFile = new System.Windows.Forms.Label();
            this.lblFoldersWithoutSearchedFile = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvFoldersWithSearchedFile = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvFoldersWithoutSearchedFile = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbFilenameOfFileToAdd = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnCheckRepos = new System.Windows.Forms.Button();
            this.lblGitFolderStatusChangeDetected = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(392, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // tbFilenameToSearchFor
            // 
            this.tbFilenameToSearchFor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFilenameToSearchFor.Location = new System.Drawing.Point(15, 12);
            this.tbFilenameToSearchFor.Name = "tbFilenameToSearchFor";
            this.tbFilenameToSearchFor.Size = new System.Drawing.Size(371, 20);
            this.tbFilenameToSearchFor.TabIndex = 2;
            this.tbFilenameToSearchFor.DoubleClick += new System.EventHandler(this.tbFilenameToSearchFor_DoubleClick);
            // 
            // lblFoldersWithSearchedFile
            // 
            this.lblFoldersWithSearchedFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFoldersWithSearchedFile.AutoSize = true;
            this.lblFoldersWithSearchedFile.Location = new System.Drawing.Point(12, 179);
            this.lblFoldersWithSearchedFile.Name = "lblFoldersWithSearchedFile";
            this.lblFoldersWithSearchedFile.Size = new System.Drawing.Size(51, 13);
            this.lblFoldersWithSearchedFile.TabIndex = 5;
            this.lblFoldersWithSearchedFile.Text = "With File:";
            // 
            // lblFoldersWithoutSearchedFile
            // 
            this.lblFoldersWithoutSearchedFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFoldersWithoutSearchedFile.AutoSize = true;
            this.lblFoldersWithoutSearchedFile.Location = new System.Drawing.Point(4, 6);
            this.lblFoldersWithoutSearchedFile.Name = "lblFoldersWithoutSearchedFile";
            this.lblFoldersWithoutSearchedFile.Size = new System.Drawing.Size(66, 13);
            this.lblFoldersWithoutSearchedFile.TabIndex = 6;
            this.lblFoldersWithoutSearchedFile.Text = "Without File:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(7, 172);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvFoldersWithSearchedFile);
            this.splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvFoldersWithoutSearchedFile);
            this.splitContainer1.Panel2.Controls.Add(this.lblFoldersWithoutSearchedFile);
            this.splitContainer1.Panel2MinSize = 100;
            this.splitContainer1.Size = new System.Drawing.Size(473, 250);
            this.splitContainer1.SplitterDistance = 119;
            this.splitContainer1.TabIndex = 7;
            // 
            // lvFoldersWithSearchedFile
            // 
            this.lvFoldersWithSearchedFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvFoldersWithSearchedFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvFoldersWithSearchedFile.FullRowSelect = true;
            this.lvFoldersWithSearchedFile.LabelWrap = false;
            this.lvFoldersWithSearchedFile.Location = new System.Drawing.Point(4, 22);
            this.lvFoldersWithSearchedFile.Name = "lvFoldersWithSearchedFile";
            this.lvFoldersWithSearchedFile.Size = new System.Drawing.Size(462, 92);
            this.lvFoldersWithSearchedFile.TabIndex = 0;
            this.lvFoldersWithSearchedFile.UseCompatibleStateImageBehavior = false;
            this.lvFoldersWithSearchedFile.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 1000;
            // 
            // lvFoldersWithoutSearchedFile
            // 
            this.lvFoldersWithoutSearchedFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvFoldersWithoutSearchedFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lvFoldersWithoutSearchedFile.FullRowSelect = true;
            this.lvFoldersWithoutSearchedFile.Location = new System.Drawing.Point(4, 30);
            this.lvFoldersWithoutSearchedFile.Name = "lvFoldersWithoutSearchedFile";
            this.lvFoldersWithoutSearchedFile.Size = new System.Drawing.Size(462, 92);
            this.lvFoldersWithoutSearchedFile.TabIndex = 1;
            this.lvFoldersWithoutSearchedFile.UseCompatibleStateImageBehavior = false;
            this.lvFoldersWithoutSearchedFile.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "";
            this.columnHeader2.Width = 1000;
            // 
            // tbFilenameOfFileToAdd
            // 
            this.tbFilenameOfFileToAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFilenameOfFileToAdd.Location = new System.Drawing.Point(15, 72);
            this.tbFilenameOfFileToAdd.Name = "tbFilenameOfFileToAdd";
            this.tbFilenameOfFileToAdd.Size = new System.Drawing.Size(371, 20);
            this.tbFilenameOfFileToAdd.TabIndex = 9;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(392, 69);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "All Files|*.*";
            this.openFileDialog1.Title = "Select Git File";
            // 
            // btnCheckRepos
            // 
            this.btnCheckRepos.Location = new System.Drawing.Point(20, 127);
            this.btnCheckRepos.Name = "btnCheckRepos";
            this.btnCheckRepos.Size = new System.Drawing.Size(143, 23);
            this.btnCheckRepos.TabIndex = 10;
            this.btnCheckRepos.Text = "Check Git Repo Status\'s";
            this.btnCheckRepos.UseVisualStyleBackColor = true;
            this.btnCheckRepos.Click += new System.EventHandler(this.btnCheckRepos_Click);
            // 
            // lblGitFolderStatusChangeDetected
            // 
            this.lblGitFolderStatusChangeDetected.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGitFolderStatusChangeDetected.AutoSize = true;
            this.lblGitFolderStatusChangeDetected.Location = new System.Drawing.Point(332, 156);
            this.lblGitFolderStatusChangeDetected.Name = "lblGitFolderStatusChangeDetected";
            this.lblGitFolderStatusChangeDetected.Size = new System.Drawing.Size(97, 13);
            this.lblGitFolderStatusChangeDetected.TabIndex = 11;
            this.lblGitFolderStatusChangeDetected.Text = "Change Detected :";
            this.lblGitFolderStatusChangeDetected.Visible = false;
            // 
            // MainGuiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 425);
            this.Controls.Add(this.lblGitFolderStatusChangeDetected);
            this.Controls.Add(this.btnCheckRepos);
            this.Controls.Add(this.tbFilenameOfFileToAdd);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblFoldersWithSearchedFile);
            this.Controls.Add(this.tbFilenameToSearchFor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(502, 464);
            this.Name = "MainGuiForm";
            this.Text = "Git File Search and Adder";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFilenameToSearchFor;
        private System.Windows.Forms.Label lblFoldersWithSearchedFile;
        private System.Windows.Forms.Label lblFoldersWithoutSearchedFile;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox tbFilenameOfFileToAdd;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListView lvFoldersWithSearchedFile;
        private System.Windows.Forms.ListView lvFoldersWithoutSearchedFile;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnCheckRepos;
        private System.Windows.Forms.Label lblGitFolderStatusChangeDetected;
    }
}

