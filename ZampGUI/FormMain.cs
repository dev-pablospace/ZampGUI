using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Configuration;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using ZampLib;
using ZampLib.Business;
using Newtonsoft.Json.Linq;

namespace ZampGUI
{
    public partial class FormMain : Form
    {
        public ConfigVar cv;
        

        #region constructor
        public FormMain(string[] args)
        {
            InitializeComponent();

            //listViewInfo.View = View.Details;
            //listViewInfo.GridLines = true;
            //listViewInfo.FullRowSelect = true;

            //Add column header
            //listViewInfo.Columns.Add("Name", 80);
            //listViewInfo.Columns.Add("Value");
            //listViewInfo.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            //listViewInfo.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            //listViewInfo.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewInfo.Columns[1].Width = listViewInfo.Width - listViewInfo.Columns[0].Width - 20;
            toolStripStatusLabelMainForm.Text = "";

            //change title
            this.Text = "ZampGUI v" + ZampGUILib.getval_from_appsetting("ver");
        }
        #endregion

        #region eventi

        private void FrmManZAMP_Load(object sender, EventArgs e)
        {
            try
            {
                cv = new ConfigVar(this);
                string root_folder = ZampGUILib.getRootFolder(this);
                cv.updatePath(root_folder);
                cv.updateUUID();


                string svalidate = cv.validateSetting();
                if (!string.IsNullOrEmpty(svalidate))
                {
                    ZampGUILib.printMsg_and_exit(svalidate);
                }

                string msg_port_in_use = cv.checkPortInUse();
                if (!string.IsNullOrEmpty(msg_port_in_use))
                {
                    addOutput(msg_port_in_use);
                    MessageBox.Show(msg_port_in_use, "!!!!!", MessageBoxButtons.OK);
                }

                cv.update_software_version();
                refreshStatusForm(true);
                crealinkSite(cv.listaSites);

                if(cv.checkUpdateZampgui)
                {
                    checkUpdate_statusBar();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
                ZampGUILib.printMsg_and_exit();
            }
        }

        #region file
        private void checkStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addOutput(ZampGUILib.getStatusProc(cv, typeProg.apache));
            addOutput(ZampGUILib.getStatusProc(cv, typeProg.mariadb));
        }
        private void stopAllProgrammToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disableControl();
            do_All_Backup_Db();
            addOutput(ZampGUILib.killproc(cv, typeProg.apache));
            addOutput(ZampGUILib.killproc(cv, typeProg.mariadb));

            enableControl();
            refreshStatusForm();

        }
        private void runAllProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disableControl();
            check_and_kill_other_instance(typeProg.apache);
            check_and_kill_other_instance(typeProg.mariadb);


            addOutput(ZampGUILib.startProc(cv, typeProg.apache, new string[] { }));
            addOutput(ZampGUILib.startProc(cv, typeProg.mariadb, new string[] { }));

            addOutput(ZampGUILib.getStatusProc(cv, typeProg.apache));
            addOutput(ZampGUILib.getStatusProc(cv, typeProg.mariadb));

            enableControl();
            refreshStatusForm();

        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZampGUILib.printMsg_and_exit("", true);
        }
        private void btnStartStopApache_Click(object sender, EventArgs e)
        {
            disableControl();
            check_and_kill_other_instance(typeProg.apache);
            if (ZampGUILib.checkRunningProc(cv.getPID_apache))
            {
                addOutput(ZampGUILib.killproc(cv, typeProg.apache));
            }
            else
            {
                addOutput(ZampGUILib.startProc(cv, typeProg.apache, new string[] { }));
            }

            enableControl();
            refreshStatusForm();
        }
        private void btnStartStopMariaDB_Click(object sender, EventArgs e)
        {
            disableControl();
            do_All_Backup_Db();
            check_and_kill_other_instance(typeProg.mariadb);
            if (ZampGUILib.checkRunningProc(cv.getPID_mariadb))
            {
                addOutput(ZampGUILib.killproc(cv, typeProg.mariadb));
            }
            else
            {
                addOutput(ZampGUILib.startProc(cv, typeProg.mariadb, new string[] { }));
            }

            enableControl();
            refreshStatusForm();
        }
        private void timer_refresh_Tick(object sender, EventArgs e)
        {
            refreshStatusForm();
        }

        #endregion

        #region Edit
        private void changeConfig_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename_config = "";
            string vocemenu_chiamata = ((System.Windows.Forms.ToolStripMenuItem)sender).Name;
            switch (vocemenu_chiamata)
            {
                case "apacheHttpdconfToolStripMenuItem":
                    filename_config = cv.Apache_httpd_conf;
                    break;
                case "apacheHttpdvhostsconfToolStripMenuItem":
                    filename_config = cv.Apache_httpd_vhosts;
                    break;
                case "phpiniToolStripMenuItem":
                    filename_config = cv.PHP_ini;
                    break;
                case "mariadbIniToolStripMenuItem":
                    filename_config = cv.MariaDB_ini;
                    break;
            }
            ZampGUILib.startProc(cv, typeProg.editor, new string[] { filename_config });
        }
        private void hostFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path_host_file = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"drivers\etc\hosts");
            ZampGUILib.startProc_as_admin(cv.default_editor, path_host_file);
        }
        private void backupRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ZampGUILib.checkRunningProc(cv.getPID_mariadb))
            {
                MessageBox.Show("MariaDB is not running");
                return;
            }

            FormBackupRestore frm2 = new FormBackupRestore(cv);
            DialogResult dr = frm2.ShowDialog(this);
            if (dr == DialogResult.OK)
            {

            }
            frm2.Close();
        }
        private void ChangeVersStripMenuItem_Click(object sender, EventArgs e)
        {
            //Non funziona più questo mtodo dopo aver fatto un refactoring
            if (ZampGUILib.checkRunningProc(cv.getPID_apache))
            {
                MessageBox.Show("Please close Apache");
                return;
            }

            FormChangeVers frm2 = new FormChangeVers(cv);
            DialogResult dr = frm2.ShowDialog(this);
            //cv = new ConfigVar();
            cv.update_software_version(true);
            refreshStatusForm(true);
            frm2.Close();
        }
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOptions frm2 = new FormOptions(cv);
            DialogResult dr = frm2.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                cv = frm2.cv;
                cv.updatePort();
                cv.updateAdditionalPath();
                cv.updateDefaultEditor(cv.default_editor);
                cv.otherUpdate();
                refreshStatusForm(true);
            }
            frm2.Close();
        }
        private void exportConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"C:\";      
            saveFileDialog1.Title = "Save Config.json";
            //saveFileDialog1.CheckFileExists = true;
            //saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "json";
            //saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Filter = "Json files (*.json)|";
            //saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != "")
            {
                if(System.IO.File.Exists(saveFileDialog1.FileName))
                {
                    System.IO.File.Delete(saveFileDialog1.FileName);
                }
                System.IO.File.Copy(cv.ConfigJson_path, saveFileDialog1.FileName);
                MessageBox.Show("File saved as \"" + saveFileDialog1.FileName + "\"");
            }
        }

        private void importConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                //openFileDialog.Filter = "Json files (*.json)|*.txt|All files (*.*)|*.*";
                openFileDialog.Filter = "Json files (*.json)|";
                //openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    JObject jimported = JObject.Parse(System.IO.File.ReadAllText(openFileDialog.FileName));

                    if (cv.importJson(jimported))
                    {
                        MessageBox.Show("File imported");
                        crealinkSite(cv.listaSites);
                    }
                    else
                    {
                        MessageBox.Show("File non imported");
                    }
                }
            }
            
        }
        #endregion

        #region Link
        private void phpinfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _url = cv.url_phpinfo;
            if (!string.IsNullOrEmpty(_url))
            {
                System.Diagnostics.Process.Start(_url);
            }
        }
        private void phpMyAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _url = cv.url_phpmyadmin;
            if (!string.IsNullOrEmpty(_url))
            {
                System.Diagnostics.Process.Start(_url);
            }
        }
        private void adminerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _url = cv.url_adminer;
            if (!string.IsNullOrEmpty(_url))
            {
                System.Diagnostics.Process.Start(_url);
            }
        }
        private void manageSitesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManageSites frm = new FormManageSites(cv);
            frm.ShowDialog();
            cv.caricasites();
            crealinkSite(cv.listaSites);
        }
        #endregion

        #region Extra
        private void showHostEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string path_host_file = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"drivers\etc\hosts");
                string contents = System.IO.File.ReadAllText(path_host_file);

                FormMsg frm_msg = new FormMsg(contents);
                frm_msg.ShowDialog(this);
                frm_msg.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void wordpressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("function not available at the moment");
            //return;

            if (!ZampGUILib.checkRunningProc(cv.getPID_mariadb))
            {
                MessageBox.Show("MariaDB is not running");
                return;
            }

            //FormOneClick_WP frm_wp = new FormOneClick_WP(cv);
            //if (frm_wp.ShowDialog(this) == DialogResult.OK)
            //{

            //}
            //frm_wp.Dispose();


            FormOneClick_WP2 frm_wp = new FormOneClick_WP2(cv);
            frm_wp.ShowDialog(this);
            frm_wp.Dispose();
        }
        private void pHPFoldeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = cv.PHP_path;
            Process.Start(path);
        }

        private void mySQLFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = cv.MariaDB_path;
            Process.Start(path);
        }

        private void apacheFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = cv.Apache_path;
            Process.Start(path);
        }
        private void backupDBFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = cv.BackupDB_path;
            Process.Start(path);
        }

        private void HttdocsRootFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = cv.Apache_htdocs_path;
            Process.Start(path);
        }
        #endregion

        #region Console
        private void consoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openConsole();
        }
        #endregion

        #region Help
        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                //recupero i config dal app.config
                string ver = ZampGUILib.getval_from_appsetting("ver");
                JObject jobj = cv.getReqInfo_from_WebSite(ver);


                //mi occupo di fare il check sulla versione
                string homepage = jobj.Value<string>("homepage");
                string supporto_pagina = jobj.Value<string>("supporto_pagina");
                System.Diagnostics.Process.Start(supporto_pagina);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Service not available at the moment");
            }
        }

        private void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //recupero i config dal app.config
                string ver = ZampGUILib.getval_from_appsetting("ver");

                JObject jobj = cv.getReqInfo_from_WebSite(ver);

                //salvo il config nell app.config
                //string home_web = jobj.Value<string>("homepage");
                string url_latest_vers = jobj.Value<string>("url_latest_vers");

                //Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                //config.Save(ConfigurationSaveMode.Minimal);


                //mi occupo di fare il check sulla versione
                string ver_web = jobj.Value<string>("ver");

                if (ver.Equals(ver_web))
                {
                    MessageBox.Show("You have the latest version of ZampGUI");
                }
                else
                {
                    FormUpdateProgram frm2 = new FormUpdateProgram(url_latest_vers);
                    DialogResult dr = frm2.ShowDialog(this);
                    if (dr == DialogResult.OK)
                    {

                    }
                    frm2.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Service not available at the moment");
            }

        }
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormAbout frm2 = new FormAbout(cv);
            DialogResult dr = frm2.ShowDialog(this);
            if (dr == DialogResult.OK)
            {

            }
            frm2.Close();
        }

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //recupero i config dal app.config
                string ver = ZampGUILib.getval_from_appsetting("ver");
                JObject jobj = cv.getReqInfo_from_WebSite(ver);


                //mi occupo di fare il check sulla versione
                string indirizzo_eth = jobj.Value<string>("indirizzo_eth");
                string indirizzo_bit = jobj.Value<string>("indirizzo_bit");

                FormDonate frm2 = new FormDonate(indirizzo_eth, indirizzo_bit);
                DialogResult dr = frm2.ShowDialog(this);
                if (dr == DialogResult.OK)
                {

                }
                frm2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Service not available at the moment");
            }


        }

        #endregion

        private void toolStripStatusLabelMainForm_Click(object sender, EventArgs e)
        {
            ToolStripLabel toolStripLabel1 = (ToolStripLabel)sender;

            // Start Internet Explorer and navigate to the URL in the
            // tag property.
            if(!string.IsNullOrEmpty(toolStripLabel1.Tag.ToString()))
            {
                System.Diagnostics.Process.Start(toolStripLabel1.Tag.ToString());

                // Set the LinkVisited property to true to change the color.
                toolStripLabel1.LinkVisited = true;
            }
            
        }

        #endregion

        #region private method
        private void openConsole()
        {
            string apache_dir_bin = System.IO.Path.Combine(cv.App_Path, cv.Apache_current, "bin");
            string mariadb_dir_bin = System.IO.Path.Combine(cv.App_Path, cv.MariaDB_current, "bin");
            string composer_path = System.IO.Path.Combine(cv.App_Path, "composer");
            string php_dir = System.IO.Path.Combine(cv.App_Path, cv.PHP_current);
            //string node_path = System.IO.Path.Combine(cv.pathBase, "Apps", "node-x64");
            //string sass_path = System.IO.Path.Combine(cv.pathBase, "Apps", "dart-sass");
            string wpcli_path = System.IO.Path.Combine(cv.pathBase, "Apps", cv.pathWPcli);

            string drive_letter = System.IO.Path.GetPathRoot(cv.pathBase).Substring(0, 1);
            //MessageBox.Show(drive_letter);
            string ListPathConsole = cv.ListPathConsole.Count == 0 ? "": ";\"" + String.Join("\";\"", cv.ListPathConsole.ToArray()) + "\"";

            if(System.IO.Directory.Exists(cv.pathGit))
            {
                ListPathConsole += ";\"" + cv.pathGit + "\"";
            }
            if (System.IO.Directory.Exists(cv.pathSass))
            {
                ListPathConsole += ";\"" + cv.pathSass + "\"";
            }
            if (System.IO.Directory.Exists(cv.pathNode))
            {
                ListPathConsole += ";\"" + cv.pathNode + "\"";
            }
            if (System.IO.Directory.Exists(wpcli_path))
            {
                ListPathConsole += ";\"" + wpcli_path + "\"";
            }

            //ManZampLib.ExecuteBatchFile_dont_wait(System.IO.Path.Combine(cv.pathBase, "scripts", "open_console.bat"),
            //        new string[] { apache_dir_bin, cv.pathPHP, mariadb_dir_bin, composer_path, node_path, sass_path, drive_letter, cv.pathBase }
            //);

            //System.Diagnostics.Process process = new System.Diagnostics.Process();
            //System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //startInfo.FileName = "cmd.exe";
            ////startInfo.Arguments = "/C copy /b Image1.jpg + Archive.rar Image2.jpg";
            //process.StartInfo = startInfo;
            //process.Start();

            ProcessStartInfo pro = new ProcessStartInfo();
            pro.FileName = "cmd.exe";
            pro.UseShellExecute = false;
            pro.WorkingDirectory = cv.pathBase;
            Process proStart = new Process();
            proStart.StartInfo = pro;

            string addToPath = "\"" + apache_dir_bin + "\";\"" + php_dir + "\";\"" + mariadb_dir_bin + "\";\"" + composer_path + "\"" + ListPathConsole;
            string PATH = Environment.GetEnvironmentVariable("PATH");
            pro.EnvironmentVariables["PATH"] = addToPath + ";" + PATH;
            proStart.Start();
            
            //proStart.StandardInput.WriteLine("cls");

            //ZampGUILib.ExecuteBatchFile_dont_wait(System.IO.Path.Combine(cv.pathBase, "scripts", "open_console.bat"),
            //        new string[] { apache_dir_bin, cv.PHP_path_scelto, mariadb_dir_bin, composer_path, drive_letter, cv.pathBase, ListPathConsole }
            //);
        }
        private void refreshStatusForm(bool AggiornaPercorsi = false)
        {
            if(AggiornaPercorsi)
            {
                //vecchia modalità
                //lbVersion.Text = "Env: " + cv._env;
                //lb_baseFolder.Text = "Base Folder: " + cv.pathBase;
                //lbApache_ver.Text = cv.apache_vers;
                //lbPHP_ver.Text = cv.php_vers;
                //lbMariaDB_ver.Text = cv.mariadb_vers;
                //lbComposer_ver.Text = cv.composer_vers;

                listViewInfo.Items.Clear();
                listViewInfo.Items.Add(new ListViewItem(new string[] { "Folder", cv.pathBase }));
                listViewInfo.Items.Add(new ListViewItem(new string[] { "Apache", cv.apache_vers }));
                listViewInfo.Items.Add(new ListViewItem(new string[] { "MariaDB", cv.mariadb_vers }));
                listViewInfo.Items.Add(new ListViewItem(new string[] { "PHP", cv.php_vers }));
                listViewInfo.Items.Add(new ListViewItem(new string[] { "Composer", cv.composer_vers }));     
                //listViewInfo.Items.Add(new ListViewItem(new string[] { "Git", cv.git_vers }));
                //listViewInfo.Items.Add(new ListViewItem(new string[] { "Node", cv.node_vers }));
                //listViewInfo.Items.Add(new ListViewItem(new string[] { "Dart Sass", cv.sass_vers }));
                listViewInfo.Items.Add(new ListViewItem(new string[] { "WP cli", cv.wp_cli_vers }));
            }
            

            bool bRunProc = ZampGUILib.checkRunningProc(cv.getPID_apache);
            if (bRunProc)
            {
                pictureBoxApache.Image = Properties.Resources.form_select_icon;
                btnStartStopApache.Text = "Stop Apache";
            }
            else
            {
                pictureBoxApache.Image = Properties.Resources.form_stop_icon;
                btnStartStopApache.Text = "Start Apache";
                if(!string.IsNullOrEmpty(cv.getPID_apache))
                {
                    cv.updatePID(typeProg.apache, typeStartorKill.start, null);
                }
                
            }



            bRunProc = ZampGUILib.checkRunningProc(cv.getPID_mariadb);
            if (bRunProc)
            {
                pictureBoxMariaDB.Image = Properties.Resources.form_select_icon;
                btnStartStopMariaDB.Text = "Stop MariaDB";
            }
            else
            {
                pictureBoxMariaDB.Image = Properties.Resources.form_stop_icon;
                btnStartStopMariaDB.Text = "Start MariaDB";
                if (!string.IsNullOrEmpty(cv.getPID_mariadb))
                {
                    cv.updatePID(typeProg.mariadb, typeStartorKill.start, null);
                }
                    
            }

            
        }
        private void addOutput(string testo)
        {
            string[] lines = Regex.Split(testo, Environment.NewLine);
            foreach (string s in lines)
            {
                if(!string.IsNullOrEmpty(s))
                {
                    string datamia = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    txtOut.AppendText(datamia + " - " + s + Environment.NewLine);
                }
                
            }
        }
        private void check_and_kill_other_instance(typeProg tpg)
        {
            switch(tpg)
            {
                case typeProg.apache:
                    _check_and_kill_other_instance(cv.getPID_apache, cv.procApache, cv.get_friendly_name(typeProg.apache));
                    break;
                case typeProg.mariadb:
                    _check_and_kill_other_instance(cv.getPID_mariadb, cv.procMariaDB, cv.get_friendly_name(typeProg.mariadb));
                    break;
                case typeProg.apache_and_mariadb:
                    _check_and_kill_other_instance(cv.getPID_apache, cv.procApache, cv.get_friendly_name(typeProg.apache));
                    _check_and_kill_other_instance(cv.getPID_mariadb, cv.procMariaDB, cv.get_friendly_name(typeProg.mariadb));
                    break;
            }

        }
        private void _check_and_kill_other_instance(string pid, string nameproc, string friendly_name)
        {
            if (string.IsNullOrEmpty(pid) && ZampGUILib.checkstatusProc_byName(nameproc))
            {
                ZampGUILib.killproc_byName(nameproc); //kill in any case 

                //DialogResult dialogResult = MessageBox.Show(friendly_name + " running from another program ? Do you want to kill every " + friendly_name + " process ?", friendly_name + " running", MessageBoxButtons.YesNo);
                //if (dialogResult == DialogResult.Yes)
                //{
                //    //do something
                //    ManZampLib.killproc_byName(nameproc);
                //}
                //else if (dialogResult == DialogResult.No)
                //{
                //    //do something else
                //    return;
                //}
            }
        }
        private void crealinkSite(List<RigaSite> arrListSite)
        {
            this.sitesToolStripMenuItem.DropDownItems.Clear();

            for (int i = 0; i < arrListSite.Count; i++)
            {
                if (arrListSite[i] == null || string.IsNullOrEmpty(arrListSite[i].Url) || string.IsNullOrEmpty(arrListSite[i].Name))
                    continue;

                string surl = arrListSite[i].Url.Trim();
                System.Windows.Forms.ToolStripMenuItem toolstr = new System.Windows.Forms.ToolStripMenuItem();
                toolstr.Name = "toolstripitem_sites" + i;
                toolstr.Text = arrListSite[i].Name.Trim();
                toolstr.Click += new EventHandler(delegate (object s, EventArgs ev)
                {
                    System.Diagnostics.Process.Start(surl);
                }); ;
                this.sitesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { toolstr });
            }
        }
        private void do_All_Backup_Db()
        {
            string friendly_name = cv.get_friendly_name(typeProg.mariadb);
            string pid = cv.get_correct_pid(typeProg.mariadb);
            bool mariadbrunning = !string.IsNullOrEmpty(pid);
            

            if (cv.checkBackUpAllDBOnExit && mariadbrunning)
            {
                List<string> all_db = ZampGUILib.getAllDB(cv.mariadb_port);
                string[] dbskip = { "information_schema", "mysql", "performance_schema", "sys", "phpmyadmin" };
                foreach (string str_db in all_db)
                {
                    if (dbskip.Contains(str_db))
                    {
                        continue;
                    }

                    string nomescript_backup = "MySql_Backup_addcreate.bat";
                    string nomebackup_file = str_db + "_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_-_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + "_" + DateTime.Now.Millisecond + ".sql";
                    
                    if(System.IO.Directory.Exists(cv.pathBackupSQLFolder))
                    {
                        nomebackup_file = System.IO.Path.Combine(cv.pathBackupSQLFolder, nomebackup_file);
                    }
                    else
                    {
                        nomebackup_file = System.IO.Path.Combine(cv.pathBase, "db_backup", nomebackup_file);
                    }
                    

                    List<string> l_res = ZampGUILib.ExecuteBatchFile(System.IO.Path.Combine(cv.pathBase, "scripts", nomescript_backup),
                        new string[] { str_db, "root", "root", nomebackup_file, System.IO.Path.Combine(cv.MariaDB_path, "bin"), "127.0.0.1", cv.mariadb_port }
                    );

                }
            }
        }
        private void disableControl()
        {
            btnStartStopApache.Enabled = false;
            btnStartStopMariaDB.Enabled = false;
            operationToolStripMenuItem.Enabled = false;
            editToolStripMenuItem.Enabled = false;
        }
        private void enableControl()
        {
            btnStartStopApache.Enabled = true;
            btnStartStopMariaDB.Enabled = true;
            operationToolStripMenuItem.Enabled = true;
            editToolStripMenuItem.Enabled = true;
        }
        private void checkUpdate_statusBar()
        {
            

            try
            {
                //recupero i config dal app.config
                string ver = ZampGUILib.getval_from_appsetting("ver");

                JObject jobj = cv.getReqInfo_from_WebSite(ver);

                string url_latest_vers = jobj.Value<string>("url_latest_vers");

                //mi occupo di fare il check sulla versione
                string ver_web = jobj.Value<string>("ver");

                if (ver.Equals(ver_web))
                {
                    toolStripStatusLabelMainForm.Text = "No Update available"; //"You have the latest version of ZampGUI"
                    //toolStripStatusLabelMainForm.Tag = "";
                }
                else
                {
                    toolStripStatusLabelMainForm.IsLink= true;
                    toolStripStatusLabelMainForm.Click += new System.EventHandler(this.toolStripStatusLabelMainForm_Click);
                    toolStripStatusLabelMainForm.Text = "New version " + ver_web + " available ";
                    toolStripStatusLabelMainForm.Tag = url_latest_vers;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Service not available at the moment");
            }
        }


        #endregion

        
    }
}
