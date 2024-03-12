using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ZampLib.Business;
using ZampLib;
using System.Net;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Linq;
using System.IO.Compression;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Runtime.InteropServices.ComTypes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ZampGUI
{
    public partial class FormOneClick_WP2 : Form
    {
        #region vars
        public ConfigVar cv;
        #endregion

        #region constructor
        public FormOneClick_WP2(ConfigVar cv)
        {
            InitializeComponent();
            this.cv = cv;
            ricaricaComboIstanzeWP();

            //backgroundWorker2 = new BackgroundWorker();
            //backgroundWorker2.WorkerReportsProgress = true;
            //backgroundWorker2.DoWork += new DoWorkEventHandler(esegui_worker);
            //backgroundWorker2.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_Completed);
            //backgroundWorker2.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);

        }
        #endregion

        #region eventi form
        private async void btnInstall_Click(object sender, EventArgs e)
        {
            txtOut.Text = "";
            string nome_sito = txt_nomesito.Text.ToLower().Trim();
            string user = txt_User.Text.ToLower().Trim();
            string pwd = txt_Pwd.Text.ToLower().Trim();
            string email = txt_Email.Text.ToLower().Trim();
            string displayname = txt_DisplayName.Text.ToLower().Trim();
            string path_folder_wp = Path.Combine(cv.Apache_htdocs_path, nome_sito);
            string path_wp = Path.Combine(cv.App_Path, cv.pathWPcli, "wp.bat");


            string sout_err = "";
            sout_err += controllaCampo(nome_sito, "name website");
            sout_err += controllaCampo(user, "user");
            sout_err += controllaCampo(pwd, "password");
            sout_err += controllaCampo(email, "email", true);
            sout_err += controllaCampo(displayname, "nickname");

            if (!string.IsNullOrEmpty(sout_err))
            {
                MessageBox.Show(sout_err);
                return;
            }

            
            if (checkBox_Sovrascrivi.Checked)
            {
                //cancello tutto db e cartella
                cancellaIstanzaWp(nome_sito);
            }
            else
            {
                // ho richiesto di non sovrascrivere controllo se esiste db e cartella sito
                List<string> all_db = ZampGUILib.getAllDB(cv.mariadb_port);
                foreach (string s in all_db)
                {
                    if (s.Equals(nome_sito))
                    {
                        MessageBox.Show("database \"" + s + "\" already exists - please insert a different name");
                        return;
                    }
                }

                if (System.IO.Directory.Exists(path_folder_wp))
                {
                    MessageBox.Show("folder \"" + nome_sito + "\" already exists inside Apache/htdocs - please use a different name");
                    return;
                }
            }

            Directory.CreateDirectory(path_folder_wp);
            disabilita_comandi_form();


            //sezione in cui avvio il job in un altro thread
            var progress = new Progress<string>(arg => txtOut.Text += arg + Environment.NewLine);
            await Task.Factory.StartNew(() => this.esegui_worker(progress), TaskCreationOptions.LongRunning);
            abilita_comandi_form();
            MessageBox.Show("Completed - Please Visit" + Environment.NewLine + "http://localhost/" + nome_sito);
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string nomeistanza = comboBoxWpDelete.SelectedItem.ToString();

            if (string.IsNullOrEmpty(nomeistanza))
            {
                MessageBox.Show("please choose a web site from combobox");
                return;
            }

            cancellaIstanzaWp(nomeistanza);
            ricaricaComboIstanzeWP();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            txtOut.Text = "";
            string enviromentPath = cv.PHP_path + ";" + Path.Combine(cv.MariaDB_path, "bin") + ";" + System.Environment.GetEnvironmentVariable("PATH");
            string nomeistanza = comboBoxWpBackup.SelectedItem.ToString();
            string path_folder_wp = Path.Combine(cv.Apache_htdocs_path, nomeistanza);
            string path_folder_zip = Path.Combine(cv.Apache_htdocs_path, nomeistanza + "_" + DateTime.Now.ToString("yyyy-MM-dd_-_HH-mm-ss") + ".zip");
            string comando_backup_db = "mysqldump -u root --password=root " + nomeistanza + " > \"" + Path.Combine(path_folder_wp, nomeistanza) + ".sql\"";

            if(string.IsNullOrEmpty(nomeistanza))
            {
                MessageBox.Show("please choose a web site from combobox");
                return;
            }

            disabilita_comandi_form();

            string output = eseguiComando(comando_backup_db, path_folder_wp, enviromentPath);

            if (File.Exists(path_folder_zip))
                File.Delete(path_folder_zip);

            ZipFile.CreateFromDirectory(path_folder_wp, path_folder_zip);
            output += "Zip file \"" + path_folder_zip + "\"";
            abilita_comandi_form();

            txtOut.Text = output;

            MessageBox.Show("File saved inside " + cv.Apache_htdocs_path + Environment.NewLine + "with the following name" + Environment.NewLine + Path.GetFileName(path_folder_zip));
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            txtOut.Text = "";
            string enviromentPath = cv.PHP_path + ";" + Path.Combine(cv.MariaDB_path, "bin") + ";" + System.Environment.GetEnvironmentVariable("PATH");
            string nomeistanza = comboBoxWpRestore.SelectedItem.ToString();
            string path_folder_wp = Path.Combine(cv.Apache_htdocs_path, nomeistanza);
            string comando_restore_db = "mysql -u root --password=root " + nomeistanza + " < \"" + Path.Combine(path_folder_wp, nomeistanza) + ".sql\"";
            
            if (string.IsNullOrEmpty(nomeistanza))
            {
                MessageBox.Show("please choose a web site from combobox");
                return;
            }

            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = cv.Apache_htdocs_path,
                Title = "Browse Zip Files",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "zip",
                Filter = "zip file (*.zip)|*.zip",
                FilterIndex = 2,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(openFileDialog1.FileName);

                disabilita_comandi_form();

                ZipFile.ExtractToDirectory(openFileDialog1.FileName, path_folder_wp);
                txtOut.Text += "Wordpress Directory \"" + path_folder_wp + "\"";
                txtOut.Text += eseguiComando(comando_restore_db, path_folder_wp, enviromentPath);

                abilita_comandi_form();

                ricaricaComboIstanzeWP();

                MessageBox.Show("Wordpress \"" + nomeistanza + "\" restored inside folder \"" + path_folder_wp + "\"");
            }

        }

        #endregion

        #region metodi background worker
        private void esegui_worker(IProgress<string> progress)
        {
            string nome_sito = txt_nomesito.Text.ToLower().Trim();
            string user = txt_User.Text.ToLower().Trim();
            string pwd = txt_Pwd.Text.ToLower().Trim();
            string email = txt_Email.Text.ToLower().Trim();
            string displayname = txt_DisplayName.Text.ToLower().Trim();
            string path_folder_wp = Path.Combine(cv.Apache_htdocs_path, nome_sito);
            string path_wp = Path.Combine(cv.App_Path, cv.pathWPcli, "wp.bat");
            string enviromentPath = cv.PHP_path + ";" + Path.Combine(cv.MariaDB_path, "bin") + ";" + System.Environment.GetEnvironmentVariable("PATH");

            List<string> comandi_create_wp_cli = new List<string>();
            comandi_create_wp_cli.Add(path_wp + " core download");
            comandi_create_wp_cli.Add(path_wp + " config create --dbname=\"" + nome_sito + "\" --dbuser=root --dbpass=root");
            comandi_create_wp_cli.Add(path_wp + " config set WP_POST_REVISIONS 10 --raw");
            comandi_create_wp_cli.Add(path_wp + " config set WP_AUTO_UPDATE_CORE false --raw");
            comandi_create_wp_cli.Add(path_wp + " db create");
            comandi_create_wp_cli.Add(path_wp + " core install --url=\"http://localhost/" + nome_sito + "\" --title=\"" + nome_sito + "\" --admin_user=\"" + user + "\" --admin_password=\"" + pwd + "\" --admin_email=\"" + email + "\"");
            comandi_create_wp_cli.Add(path_wp + " plugin delete hello akismet");
            comandi_create_wp_cli.Add(path_wp + " theme delete twentytwentythree twentytwentytwo");
            //comandi_create_wp_cli.Add(path_wp + " option update timezone_string \"Europe/Rome\"");
            //comandi_create_wp_cli.Add(path_wp + " option update time_format \"H:i\"");
            comandi_create_wp_cli.Add(path_wp + " option update rss_use_excerpt 1");
            comandi_create_wp_cli.Add(path_wp + " option update uploads_use_yearmonth_folders 0");
            comandi_create_wp_cli.Add(path_wp + " user update 1 --nickname=\"" + displayname + "\" --display_name=\"" + displayname + "\"");
            comandi_create_wp_cli.Add(path_wp + " rewrite structure /%postname%/ --hard");


            foreach (string comando in comandi_create_wp_cli)
            {
                string output = eseguiComando(comando, path_folder_wp, enviromentPath);
                progress.Report(output);
            }

        }
        #endregion

        #region metodi privati
        private void ricaricaComboIstanzeWP()
        {
            List<string> lista_folder = (from x in System.IO.Directory.GetDirectories(cv.Apache_htdocs_path) select Path.GetFileName(x)).ToList();
            List<string> lista_db = ZampGUILib.getAllDB(cv.mariadb_port);
            var CommonList = lista_folder.Intersect(lista_db);

            foreach (string file in CommonList)
            {
                comboBoxWpDelete.Items.Add(Path.GetFileName(file));
                comboBoxWpBackup.Items.Add(Path.GetFileName(file));
                comboBoxWpRestore.Items.Add(Path.GetFileName(file));
            }

        }
        private void cancellaIstanzaWp(string nomeistanza)
        {
            //cancello tutto db e cartella
            string connStr = "server=127.0.0.1;user=root;password=root;port=" + cv.mariadb_port;
            using (var conn = new MySqlConnection(connStr))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "DROP DATABASE IF EXISTS " + nomeistanza + ";";
                cmd.ExecuteNonQuery();
            }

            //cancello la cartella dentro la httdocs
            string path_folder_wp = Path.Combine(cv.Apache_htdocs_path, nomeistanza);

            if (System.IO.Directory.Exists(path_folder_wp))
            {
                Directory.Delete(path_folder_wp, true);
            }
        }

        private void disabilita_comandi_form()
        {
            tabControl1.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            btnInstall.Enabled = false;
            btnDelete.Enabled = false;
            btnRestore.Enabled = false;
            btnBackup.Enabled = false;
        }

        private void abilita_comandi_form()
        {
            tabControl1.Enabled = true;
            Cursor.Current = Cursors.Default;
            btnInstall.Enabled = true;
            btnDelete.Enabled = true;
            btnRestore.Enabled = true;
            btnBackup.Enabled = true;
        }
        private string eseguiComando(string comando, string currentdir, string enviromentPath)
        {
            Tuple<string, string> tt;
            Dictionary<string,string> map = new Dictionary<string,string>();
            map.Add("WP_CLI_CACHE_DIR", Path.Combine(cv.App_Path, cv.pathWPcli, ".wp-cli"));
            map.Add("WP_CLI_CONFIG_PATH", Path.Combine(cv.App_Path, cv.pathWPcli, "config.yml"));
            tt = ZampGUILib.startProc_and_wait_output2(comando, "", true, currentdir, enviromentPath, map);
            string result = tt.Item1 + Environment.NewLine + tt.Item2;
            return result;
        }
        private string controllaCampo(string nomeCampo, string nomeEtichetta, bool b_controllomail = false)
        {
            string sout_err = "";
            if (string.IsNullOrEmpty(nomeCampo))
            {
                sout_err += "Please insert a name for \"" + nomeEtichetta + "\"" + Environment.NewLine;
            }

            if (nomeCampo == "wordpress")
            {
                sout_err += "'wordpress' name is reserved for \"" + nomeEtichetta + "\", Please use a different name" + Environment.NewLine;
            }

            if (nomeCampo.Length < 2 || nomeCampo.Length > 30)
            {
                sout_err += "Please use between 2 and 30 characters for \"" + nomeEtichetta + "\"" + Environment.NewLine;
            }


            if (b_controllomail)
            {
                if(!IsValidEmail(nomeCampo))
                {
                    sout_err += "Email invalid, please enter a valid email" + Environment.NewLine;
                }
            }
            else
            {
                if (!Regex.IsMatch(nomeCampo, @"^[a-zA-Z]+(\d)*[a-zA-Z]*$"))
                {
                    sout_err += "For \"" + nomeEtichetta + "\" please enter a name that starts with a letter followed by a letter or number" + Environment.NewLine;
                }
            }

            return sout_err;
        }

        public bool IsValidEmail(string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        #endregion

        
        
    }
}
