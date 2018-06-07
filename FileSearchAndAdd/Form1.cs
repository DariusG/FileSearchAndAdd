using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

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
            textBox1.Text = @"C:\BNCS\BBC_CS\panels";
            textBox2.Text = @"C:\BNCS\BBC_CS\.gitignore";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
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

            label2.Text = string.Format("With File: [{0}]", _foldersWithFile.Count);
            label3.Text = string.Format("Without File: [{0}]", _foldersWithoutFile.Count);
            listBox1.Items.AddRange(_foldersWithFile.ToArray());
            listBox2.Items.AddRange(_foldersWithoutFile.ToArray());

            label1.Text = string.Format("Number of .git files [{0}], with .gitignore files [Contains [{1}] vs Doesn't [{2}]] in [{3}] folders", countOfGitignoreFiles,hasgitIgnoreFile,doesntgitIgnoreFile,totalFoldersSearched);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", "Add file to folders selected",  MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                foreach (var listBox2SelectedItem in listBox2.SelectedItems)
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
    }
}
