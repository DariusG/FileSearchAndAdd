﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibGit2Sharp;

namespace FileSearchAndAdd
{
    public partial class MainGuiForm : Form
    {
        private List<string> _foldersWithFile;
        private List<string> _foldersWithoutFile;
        public MainGuiForm()
        {
            InitializeComponent();
            _foldersWithFile = new List<string>();
            _foldersWithoutFile = new List<string>();
            tbFilenameToSearchFor.Text = @"C:\BNCS\BBC_CS\panels\";
            tbFilenameOfFileToAdd.Text = @"C:\BNCS\BBC_CS\panels\.gitignore";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UpdateGui();
        }

        private void UpdateGui(bool includeGitCheck = false)
        {
            try
            {
                Task updateGuiOperation = Task.Factory.StartNew(() =>
                {
                    lvFoldersWithSearchedFile.BeginInvoke(new Action(() =>
                    {
                        lvFoldersWithSearchedFile.Items.Clear();
                    }));
                    lvFoldersWithSearchedFile.BeginInvoke(new Action(() =>
                    {
                        lvFoldersWithoutSearchedFile.Items.Clear();
                    }));
                    _foldersWithFile.Clear();
                    _foldersWithoutFile.Clear();

                    int countOfGitignoreFiles = 0;
                    int hasgitIgnoreFile = 0;
                    int doesntgitIgnoreFile = 0;
                    int totalFoldersSearched = 0;

                    countOfGitignoreFiles = SearchForFiles(countOfGitignoreFiles, ref doesntgitIgnoreFile,
                        ref hasgitIgnoreFile,
                        ref totalFoldersSearched);

                    List<ListViewItem> withItems = new List<ListViewItem>();
                    List<ListViewItem> withoutItems = new List<ListViewItem>();
                    _foldersWithFile.ForEach(i => withItems.Add(new ListViewItem(i)));
                    _foldersWithoutFile.ForEach(i => withoutItems.Add(new ListViewItem(i)));
                    lvFoldersWithSearchedFile.BeginInvoke(new Action(()=>
                    {
                        lvFoldersWithSearchedFile.Items.AddRange(withItems.ToArray());
                    }));
                    lvFoldersWithoutSearchedFile.BeginInvoke(new Action(() =>
                    {
                        lvFoldersWithoutSearchedFile.Items.AddRange(withoutItems.ToArray());
                    }));

                    if (includeGitCheck)
                    {
                        lvFoldersWithSearchedFile.BeginInvoke(new Action(() =>
                        {
                            lblGitFolderStatusChangeDetected.Visible = true;
                        }));
                        lvFoldersWithSearchedFile.BeginInvoke(new Action(() =>
                        {
                            lblGitFolderStatusChangeDetected.Text =
                            string.Format("Change Detected : [{0}]", CheckAndUpdateGitStatus());
                        }));
                    }
                    else
                    {
                        lvFoldersWithoutSearchedFile.BeginInvoke(new Action(() =>
                        {
                            lblGitFolderStatusChangeDetected.Visible = false;
                        }));
                    }

                    lvFoldersWithoutSearchedFile.BeginInvoke(new Action(() =>
                    {
                        lblFoldersWithSearchedFile.Text = string.Format("With File: [{0}]", _foldersWithFile.Count);
                    }));
                    lvFoldersWithoutSearchedFile.BeginInvoke(new Action(() =>
                    {
                        lblFoldersWithoutSearchedFile.Text =
                        string.Format("Without File: [{0}]", _foldersWithoutFile.Count);
                    }));
                    lvFoldersWithoutSearchedFile.BeginInvoke(new Action(() =>
                    {
                            label1.Text =
                        string.Format(
                            "Number of .git files [{0}], with .gitignore files [Contains [{1}] vs Doesn't [{2}]] in [{3}] folders",
                            countOfGitignoreFiles, hasgitIgnoreFile, doesntgitIgnoreFile, totalFoldersSearched);
                    }));
                });
                updateGuiOperation.ContinueWith((fb) =>
                {
                    if (fb.IsFaulted)
                    {
                        MessageBox.Show("Faulted");
                    }
                    else
                    {
                        Cursor.Current = Cursors.Default;
                    }
                    
                });
            }
            catch (Exception)
            {
                MessageBox.Show(@"Error Updating the Gui");
            }
        }

        private int SearchForFiles(int countOfGitignoreFiles, ref int doesntgitIgnoreFile, ref int hasgitIgnoreFile,
            ref int totalFoldersSearched)
        {
            try
            {
                foreach (string enumerateFile in Directory.EnumerateFiles(tbFilenameToSearchFor.Text, ".git",
                        SearchOption.AllDirectories))
                {
                    if (enumerateFile != null && Path.GetExtension(enumerateFile).Equals(".git"))
                    {
                        string directoryName = Path.GetDirectoryName(enumerateFile);
                        countOfGitignoreFiles++;
                        if (directoryName != null &&
                            !Directory.EnumerateFiles(directoryName, "*.gitignore", SearchOption.TopDirectoryOnly).Any())
                        {
                            //NO matching *.gitignore files
                            doesntgitIgnoreFile++;
                            _foldersWithoutFile.Add(directoryName);
                        }
                        else
                        {
                            //has matching *.gitignore files
                            hasgitIgnoreFile++;
                            _foldersWithFile.Add(directoryName);
                        }
                    }

                    totalFoldersSearched++;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"Error Searching the folders for file");
            }

            return countOfGitignoreFiles;
        }

        private int CheckAndUpdateGitStatus()
        {
            int changesDetected = 0;
            try
            {

                for (int x = 0; x < lvFoldersWithSearchedFile.Items.Count; x++)
                {
                    string enumerateFile = lvFoldersWithSearchedFile.Items[x].Text;

                    using (var repo = new Repository(enumerateFile))
                    {
                        int count = repo.RetrieveStatus(new LibGit2Sharp.StatusOptions() {IncludeIgnored = false})
                            .Count();
                        if (count > 0)
                        {
                            var x1 = x;
                            lvFoldersWithSearchedFile.BeginInvoke(new Action(() =>
                            {
                                lvFoldersWithSearchedFile.Items[x1].BackColor = Color.Red;
                            }));
                            changesDetected++;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"Error Retrieving the Git Status for folders using LibGit2Sharp");
                changesDetected = -1;
            }

            return changesDetected;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(@"Are you sure?", @"Add file to folders selected",  MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                foreach (var listBox2SelectedItem in lvFoldersWithoutSearchedFile.SelectedItems)
                {
                    string fileName = Path.GetFileName(tbFilenameOfFileToAdd.Text);
                    File.Copy(tbFilenameOfFileToAdd.Text, string.Format("{0}//{1}", listBox2SelectedItem.ToString(), fileName));
                } 
            }
        }

        private void tbFilenameToSearchFor_DoubleClick(object sender, EventArgs e)
        {
            DialogResult dialogResult = openFileDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                tbFilenameToSearchFor.Text = Path.GetDirectoryName(openFileDialog1.FileName);
            }
        }

        private void btnCheckRepos_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UpdateGui(true);
        }
    }
}
