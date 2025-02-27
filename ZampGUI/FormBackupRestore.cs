﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
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
    public partial class FormBackupRestore : Form
    {
        public ConfigVar cv;
        public string selected_db = "";
        public string sql_file_restore = "";
        public string sql_file_backup = "";
        public List<string> all_db;
        public string path_last_script = "";

        public FormBackupRestore(ConfigVar cv)
        {
            InitializeComponent();
            this.cv = cv;
            path_last_script = System.IO.Path.Combine(cv.pathBase, "last_script.txt");
            comboBoxDbRestore.SelectedIndex = (comboBoxDbRestore.Items.Count > 0) ? 0 : -1;
            comboBoxDbBackup.SelectedIndex = (comboBoxDbBackup.Items.Count > 0) ? 0 : -1;
            radioButtonSchemaAndData.Checked = true;

            if (System.IO.File.Exists(path_last_script))
            {
                textBoxSql.Text = System.IO.File.ReadAllText(path_last_script);
            }
        }

        private void FormBackupRestore_Load(object sender, EventArgs e)
        {
            try
            {
                all_db = ZampGUILib.getAllDB(cv.mariadb_port);
                foreach(string s in all_db)
                {
                    comboBoxDbRestore.Items.Add(s);
                    comboBoxDbBackup.Items.Add(s);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                ZampGUILib.printMsg_and_exit();
            }


            try
            {
                string svalidate = cv.validateSetting();
                if (!string.IsNullOrEmpty(svalidate))
                {
                    ZampGUILib.printMsg_and_exit(svalidate);
                }
            }
            catch (ConfigurationErrorsException er)
            {
                ZampGUILib.printMsg_and_exit(er.ToString());
            }

        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if(comboBoxDbBackup.SelectedItem == null)
            {
                MessageBox.Show("please select a db");
            }
            else
            {
                string options = "";
                string script_template = System.IO.Path.Combine(cv.pathBase, "scripts", "MySql_Backup_2.bat");
                string script_to_run = System.IO.Path.Combine(cv.pathBase, "scripts", "script_to_run.bat"); ;
                string str_db = comboBoxDbBackup.SelectedItem.ToString();
                string nomebackup_file = str_db + "_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_-_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + "_" + DateTime.Now.Millisecond + ".sql";

                if (System.IO.Directory.Exists(cv.pathBackupSQLFolder))
                {
                    nomebackup_file = System.IO.Path.Combine(cv.pathBackupSQLFolder, nomebackup_file);
                }
                else
                {
                    nomebackup_file = System.IO.Path.Combine(cv.pathBase, "db_backup", nomebackup_file);
                }
                

                if(checkBoxAddCreateDB.Checked)
                {
                    //nomescript_backup = "MySql_Backup_addcreate.bat";
                    options += " --databases ";
                }
                if (radioButtonSchemaOnly.Checked)
                {
                    options += " --no-data ";
                }
                if (radioButtonDataOnly.Checked)
                {
                    options += " --no-create-info ";
                }

                //scrivo le opzioni creando un uoco script - che sarà poi quello che eseguirò
                string text = File.ReadAllText(script_template);
                text = text.Replace("{{options}}", options);
                File.WriteAllText(script_to_run, text);


                //eseguibackup(str_db, nomebackup_file);
                List<string> l_res = ZampGUILib.ExecuteBatchFile(script_to_run,
                    new string[] { str_db, "root", "root", nomebackup_file, System.IO.Path.Combine(cv.MariaDB_path, "bin"), "127.0.0.1", cv.mariadb_port }
                );

                string contents = l_res[0] + Environment.NewLine + Environment.NewLine + "Error: " + l_res[1] + Environment.NewLine + "Exit code: " + l_res[2] + Environment.NewLine + "Backup done : " + nomebackup_file;
                
                FormMsg frm_msg = new FormMsg(contents);
                frm_msg.ShowDialog(this);
                frm_msg.Dispose();

                //MessageBox.Show("Backup done at file: " + nomebackup_file);
                //this.Close();
            }
        }


        private void btnSelectSqlFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = System.IO.Path.Combine(cv.pathBase, "db_backup"),
                Title = "Browse SQL file",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "sql",
                Filter = "sql files (*.sql)|*.sql",
                //FilterIndex = 2,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPathSQLFile.Text = openFileDialog1.FileName;
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            string str_db = "";
            string nomebat_restore = "MySql_Restore_nodb.bat";

            if (comboBoxDbRestore.SelectedItem != null)
            {
                str_db = comboBoxDbRestore.SelectedItem.ToString();
                nomebat_restore = "MySql_Restore.bat";
            }
            
            if (!System.IO.File.Exists(txtPathSQLFile.Text) || !txtPathSQLFile.Text.ToLower().EndsWith(".sql"))
            {
                MessageBox.Show("please select a valid sql file");
            }
            else
            {
                //eseguiRestore(comboBoxDbRestore.SelectedItem.ToString(), txtPathSQLFile.Text);
                List<string> l_res= ZampGUILib.ExecuteBatchFile(System.IO.Path.Combine(cv.pathBase, "scripts", nomebat_restore), 
                    new string[] { "root", "root", str_db, txtPathSQLFile.Text, "127.0.0.1", System.IO.Path.Combine(cv.MariaDB_path, "bin"), cv.mariadb_port }
                );

                string contents = l_res[0] + Environment.NewLine + Environment.NewLine + "Error: " + l_res[1] + Environment.NewLine + "Exit code: " + l_res[2] + Environment.NewLine + "Executed " + txtPathSQLFile.Text;

                FormMsg frm_msg = new FormMsg(contents);
                frm_msg.ShowDialog(this);
                frm_msg.Dispose();

                //MessageBox.Show("Restored " + str_db + " with file " + nomebackup_file + " completed");

            }
        }

        private void btnRunScript_Click(object sender, EventArgs e)
        {
            string script = textBoxSql.Text.Trim();
            if (string.IsNullOrEmpty(script))
            {
                MessageBox.Show("No script to execute");
                return;
            }
            
            System.IO.File.WriteAllText(path_last_script, script);



            string mysqlimport = System.IO.Path.Combine(cv.MariaDB_path, "bin", "mariadb.exe");
            string argumentsString = "--user=root --password=root -e \"\\. " + path_last_script + "\"";



            ProcessStartInfo ProcessInfo = new ProcessStartInfo(mysqlimport, argumentsString);
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = false;
            //ProcessInfo.WorkingDirectory = Application.StartupPath + "\\txtmanipulator";
            // *** Redirect the output ***
            ProcessInfo.RedirectStandardError = true;
            ProcessInfo.RedirectStandardOutput = true;

            Process process = Process.Start(ProcessInfo);
            process.WaitForExit();

            // *** Read the streams ***
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            int ExitCode = process.ExitCode;

            process.Close();

            string contents = (string.IsNullOrEmpty(output) ? "" : output + Environment.NewLine + Environment.NewLine)
                + (string.IsNullOrEmpty(error)? "": "Error: " + error + Environment.NewLine)
                + "Exit code: " + ExitCode.ToString() + Environment.NewLine;
                //+ "Backup done : " + nomebackup_file;

            FormMsg frm_msg = new FormMsg(contents);
            frm_msg.ShowDialog(this);
            frm_msg.Dispose();
        }





        #region old

        //metodo funzionante al momento ho preferito usare il metodo che usa lo script
        private void eseguibackup(string str_db, string nomebackup_file)
        {
            try
            {
                string strBackupFileName = nomebackup_file;
                StreamWriter strBackupFile = new StreamWriter(strBackupFileName);

                ProcessStartInfo psInfo = new ProcessStartInfo();
                psInfo.FileName = System.IO.Path.Combine(cv.MariaDB_path, "bin", "mariadb-dump.exe");
                psInfo.RedirectStandardInput = false;
                //psInfo.RedirectStandardOutput = false;
                psInfo.Arguments = "--user root --password=root --routines --events --triggers --single-transaction " + str_db;
                psInfo.UseShellExecute = false;
                psInfo.RedirectStandardOutput = true;
                Process backup_process = Process.Start(psInfo);

                string stdout;
                stdout = backup_process.StandardOutput.ReadToEnd();
                strBackupFile.WriteLine(stdout);
                backup_process.WaitForExit();
                strBackupFile.Close();
                backup_process.Close();
                MessageBox.Show("Backup done at file: " + strBackupFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during the backup: \n\n" + ex.Message);
            }
        }

        //metodo funzionante (ma il processo mysql non esce) al momento ho preferito usare il metodo che usa lo script
        private void eseguiRestore(string str_db, string nomebackup_file)
        {
            string contenuto_sql = System.IO.File.ReadAllText(nomebackup_file);

            var startInfo = new ProcessStartInfo(System.IO.Path.Combine(cv.MariaDB_path, "bin", "mariadb.exe"));
            startInfo.RedirectStandardInput = true;
            //startInfo.RedirectStandardInput = false;
            startInfo.RedirectStandardOutput = false;
            startInfo.UseShellExecute = false;
            startInfo.Arguments = "-u root -proot --host=127.0.0.1 --port=3309 " + str_db;

            var process = new Process();
            process.StartInfo = startInfo;
            //process.StartInfo.CreateNoWindow = true;
            process.Start();

            var streamWriter = process.StandardInput;
            streamWriter.WriteLine(contenuto_sql);

            process.WaitForExit();
            streamWriter.Close();
            process.Close();
            MessageBox.Show("Restore " + str_db + " with file " + nomebackup_file + " completed");
        }



        #endregion

        
    }
}
