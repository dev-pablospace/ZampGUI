using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZampLib;
using ZampLib.Business;

namespace ZampGUI
{
    public partial class FormOptions : Form
    {
        public ConfigVar cv;
        public bool bChangeListPath;

        public FormOptions(ConfigVar cv)
        {
            InitializeComponent();
            this.cv = cv;
        }

        private void FormOptions_Load(object sender, EventArgs e)
        {
            string svalidate = cv.validateSetting();
            if (!string.IsNullOrEmpty(svalidate))
            {
                ZampGUILib.printMsg_and_exit(svalidate);
            }

            txtPathEditor.Text = cv.default_editor_path;
            txtPathGit.Text = cv.pathGit;
            txtPathNodeJS.Text = cv.pathNode;
            txtPathSass.Text = cv.pathSass;
            checkBackUpAllDBOnExit.Checked = cv.checkBackUpAllDBOnExit;
            numericUpDown_http.Value = Convert.ToInt32(cv.apache_http_port);
            numericUpDown_https.Value = Convert.ToInt32(cv.apache_https_port);
            numericUpDown_mariadb.Value = Convert.ToInt32(cv.mariadb_port);
            txtPathConsole.Text = String.Join(Environment.NewLine, cv.ListPathConsole.ToArray());

            this.bChangeListPath = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(this.txtPathEditor.Text.ToLower() != "notepad.exe" && !System.IO.File.Exists(txtPathEditor.Text))
            {
                MessageBox.Show("default_editor_path not found");
            }
            else if(changed_port() && procs_port())
            {
                MessageBox.Show("apache or mariadb running - before changhing any port close apache and mariadb");
            }
            else if(check_change())
            {
                cv.default_editor_path = txtPathEditor.Text.Trim();
                cv.apache_http_port = numericUpDown_http.Value.ToString();
                cv.apache_https_port = numericUpDown_https.Value.ToString();
                cv.mariadb_port = numericUpDown_mariadb.Value.ToString();

                cv.pathGit = txtPathGit.Text.Trim();
                cv.pathNode = txtPathNodeJS.Text.Trim();
                cv.pathSass = txtPathSass.Text.Trim();

                cv.checkBackUpAllDBOnExit = checkBackUpAllDBOnExit.Checked;

                string[] lines = txtPathConsole.Text.Trim().Split(new[] { Environment.NewLine },StringSplitOptions.None);
                cv.ListPathConsole = new List<string>();
                foreach (var s in lines)
                {
                    if (!string.IsNullOrWhiteSpace(s))
                    {
                        if (!System.IO.Directory.Exists(s))
                        {
                            MessageBox.Show("Directory \"" + s + "\" does not exist");
                        }
                        else
                        {
                            cv.ListPathConsole.Add(s.Trim().Trim('\\'));
                        }
                    }
                }
                    
            }
            this.Close();
        }

        private bool check_change()
        {
            return cv.default_editor_path != txtPathEditor.Text.Trim().ToLower() 
                || changed_port() 
                || this.bChangeListPath
                || cv.pathGit != txtPathGit.Text.Trim()
                || cv.pathNode != txtPathNodeJS.Text.Trim()
                || cv.pathSass != txtPathSass.Text.Trim()
                || cv.checkBackUpAllDBOnExit != checkBackUpAllDBOnExit.Checked
                ;
        }

        private bool changed_port()
        {
            return cv.apache_http_port != numericUpDown_http.Value.ToString()
                || cv.apache_https_port != numericUpDown_https.Value.ToString()
                || cv.mariadb_port != numericUpDown_mariadb.Value.ToString();
        }

        private bool procs_port()
        {
            return ZampGUILib.checkRunningProc(cv.getPID_apache) || ZampGUILib.checkRunningProc(cv.getPID_mariadb);
        }

        private void btnSelectEdit_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Title = "Browse Editor .exe";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPathEditor.Text = openFileDialog1.FileName;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtPathConsole_TextChanged(object sender, EventArgs e)
        {
            this.bChangeListPath = true;
        }

        private void btnSelectGit_Click(object sender, EventArgs e)
        {
            txtPathGit.Text = selectFolder();   
        }

        private void btnSelectNode_Click(object sender, EventArgs e)
        {
            txtPathNodeJS.Text = selectFolder();
        }

        private void btnSelectSass_Click(object sender, EventArgs e)
        {
            txtPathSass.Text = selectFolder();
        }


        private string selectFolder()
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection."
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            folderBrowser.InitialDirectory = cv.pathBase;
            // Always default to Folder Selection.
            folderBrowser.FileName = "Folder Selection.";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                return folderPath;
            }
            return "";
        }
    }
}
