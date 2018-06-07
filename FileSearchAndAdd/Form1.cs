using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibGit2Sharp;

namespace FileSearchAndAdd
{
    public partial class Form1 : Form
    {
        private List<string> _foldersWithFile;
        private List<string> _foldersWithoutFile;
        private string _fileName = "";

        public Form1()
        {
            InitializeComponent();
            _foldersWithFile = new List<string>();
            _foldersWithoutFile = new List<string>();
            textBox1.Text = @"";
            textBox2.Text = @"";
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView2.Items.Clear();
            _foldersWithFile.Clear();
            _foldersWithoutFile.Clear();

            int countOfGitignoreFiles = 0;
            int hasgitIgnoreFile = 0;
            int doesntgitIgnoreFile = 0;
            int totalFoldersSearched = 0;

            foreach (string enumerateFile in Directory.EnumerateFiles(textBox1.Text, ".git", SearchOption.AllDirectories))
            {
                if (Path.GetExtension(enumerateFile).Equals(".git"))
                {
                    string directoryName = Path.GetDirectoryName(enumerateFile);
                    countOfGitignoreFiles++;
                    //if (Directory.GetFiles(Path.GetDirectoryName(enumerateFile), "*.gitignore").Length == 0)
                    if (directoryName != null && !Directory.EnumerateFiles(directoryName, "*.gitignore", SearchOption.TopDirectoryOnly).Any())
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

            List<ListViewItem> withItems = new List<ListViewItem>();
            List<ListViewItem> withoutItems = new List<ListViewItem>();
            _foldersWithFile.ForEach(i => withItems.Add(new ListViewItem(i)));
            _foldersWithoutFile.ForEach(i => withoutItems.Add(new ListViewItem(i)));
            listView1.Items.AddRange(withItems.ToArray());
            listView2.Items.AddRange(withoutItems.ToArray());


            label4.Text = string.Format("Change Detected : [{0}]", CheckAndUpdateGitStatus());
            
            
            label2.Text = string.Format("With File: [{0}]", _foldersWithFile.Count);
            label3.Text = string.Format("Without File: [{0}]", _foldersWithoutFile.Count);
            
            label1.Text = string.Format("Number of .git files [{0}], with .gitignore files [Contains [{1}] vs Doesn't [{2}]] in [{3}] folders", countOfGitignoreFiles,hasgitIgnoreFile,doesntgitIgnoreFile,totalFoldersSearched);
        }

        private int CheckAndUpdateGitStatus()
        {
            int changesDetected = 0;
            for (int x = 0; x < listView1.Items.Count; x++)
            {
                string enumerateFile = listView1.Items[x].Text;

                using (var repo = new Repository(enumerateFile))
                {
                    int count = repo.RetrieveStatus(new LibGit2Sharp.StatusOptions() {IncludeIgnored = false})
                        .Count();
                    if (count > 0)
                    {
                        var x1 = x;
                        listView1.BeginInvoke(new Action(() => { listView1.Items[x1].BackColor = Color.Red; }));
                        changesDetected++;
                    }
                }
            }

            return changesDetected;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", "Add file to folders selected",  MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                foreach (var listBox2SelectedItem in listView2.SelectedItems)
                {
                    string fileName = Path.GetFileName(textBox2.Text);
                    File.Copy(textBox2.Text, string.Format("{0}//{1}", listBox2SelectedItem.ToString(), fileName));
                } 
            }
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            DialogResult dialogResult = openFileDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                _fileName = openFileDialog1.FileName;
               // textBox1.Text = _fileName;
                MessageBox.Show(_fileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
