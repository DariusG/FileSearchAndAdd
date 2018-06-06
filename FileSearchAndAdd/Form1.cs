using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSearchAndAdd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int countOfGitignoreFiles = 0;
            int hasgitIgnoreFile = 0;
            int doesntgitIgnoreFile = 0;
            int totalFoldersSearched = 0;
            foreach (string enumerateFile in Directory.EnumerateFiles(textBox1.Text, ".git", SearchOption.AllDirectories))
            {
                if (Path.GetExtension(enumerateFile).Equals(".git"))
                {
                    countOfGitignoreFiles++;
                    if (Directory.GetFiles(Path.GetDirectoryName(enumerateFile), "*.gitignore").Length == 0)
                    {
                        //NO matching *.gitignore files
                        doesntgitIgnoreFile++;
                    }
                    else
                    {
                        //has matching *.gitignore files
                        hasgitIgnoreFile++;
                    }
                }

                totalFoldersSearched++;
            }

            label1.Text = string.Format("Number of .git files [{0}], with .gitignore files [Contains [{1}] vs Doesn't [{2}]] in [{3}] folders", countOfGitignoreFiles,hasgitIgnoreFile,doesntgitIgnoreFile,totalFoldersSearched);
        }
    }
}
