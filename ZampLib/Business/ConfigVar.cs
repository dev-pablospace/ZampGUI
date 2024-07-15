using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace ZampLib.Business
{
    public class ConfigVar
    {
        #region const
        public string procMariaDB = "mysqld";
        public string procApache = "httpd";
        public JObject json; //object to map json file 
        public string _env; //from App.config
        public string temp_folder;//from App.config
        public string YN_DEBUG;//from App.config
        public System.Windows.Forms.Form mainForm;
        #endregion

        #region prop 1 to 1 json file
        public string pathBase { get; set; }
        public string Apache_current { get; set; }
        public List<string> MariaDB_list { get; set; } = new List<string>();
        public string MariaDB_current { get; set; }
        public List<string> PHP_list { get; set; } = new List<string>();
        public string PHP_current { get; set; }
        public string pathGit { get; set; }
        public string pathSass { get; set; }
        public string pathNode { get; set; }
        public string pathWPcli { get; set; }
        public string pathBackupSQLFolder { get; set; }
        public List<SingolaVersioneWP> Vers_WP { get; set; } = new List<SingolaVersioneWP>();


        public bool checkBackUpAllDBOnExit { get; set; }
        public bool checkUpdateZampgui { get; set; }
        public string default_editor { get; set; }
        public string apache_http_port { get; set; }
        public string apache_https_port { get; set; }
        public string mariadb_port { get; set; }
        public string pid_currentproc_apache { get; set; }
        public string pid_currentproc_mariadb { get; set; }
        public string uuid_str { get; set; }
        public List<string> ListPathConsole { get; set; } //percorsi aggiuntivi che devo aggiungere alla %PATH% QUANDO apro la console
        public List<RigaSite> listaSites = new List<RigaSite>();

        public WP_Options wpop { get; set; }

        #endregion

        #region prop che contiene le versioni dei programmi
        public string apache_vers { get; set; }
        public string php_vers { get; set; }
        public string mariadb_vers { get; set; }
        public string composer_vers { get; set; }
        public string git_vers { get; set; }
        public string sass_vers { get; set; }
        public string node_vers { get; set; }
        public string wp_cli_vers { get; set; }
        #endregion

        #region prop derivate
        public string default_editor_path
        {
            get
            {
                if (!string.IsNullOrEmpty(default_editor))
                {
                    if (System.IO.File.Exists(default_editor))
                    {
                        return default_editor;
                    }
                }
                return "notepad.exe";
            }
        }
        public string App_Path
        {
            get
            {
                return System.IO.Path.Combine(pathBase, "Apps");
            }
        }
        public string ConfigJson_path
        {
            get
            {
                //lo prendo da qui perchè se potrei essere in debug
                return ZampGUILib.getJsonPath();
            }
        }
        public string MariaDB_path
        {
            get
            {
                return System.IO.Path.Combine(App_Path, MariaDB_current);
            }
        }
        public string MariaDB_exe
        {
            get
            {
                return System.IO.Path.Combine(MariaDB_path, "bin", procMariaDB + ".exe");
            }
        }
        public string Apache_exe
        {
            get
            {
                return System.IO.Path.Combine(Apache_path, "bin", procApache + ".exe");
            }
        }
        public string Apache_path
        {
            get
            {
                return System.IO.Path.Combine(App_Path, Apache_current);
            }
        }
        public string Apache_htdocs_path
        {
            get
            {
                return System.IO.Path.Combine(Apache_path, "htdocs");
            }
        }
        public string PHP_path
        {
            get
            {
                return System.IO.Path.Combine(App_Path, PHP_current);
            }
        }
        public string PHP_exe
        {
            get
            {
                return System.IO.Path.Combine(PHP_path, "php.exe");
            }
        }
        public string BackupDB_path
        {
            get
            {
                return System.IO.Path.Combine(pathBase, "db_backup");
            }
        }
        public string Composer_exe
        {
            get
            {
                return System.IO.Path.Combine(App_Path, "composer", "composer.bat");
            }
        }
        public string Apache_httpd_conf
        {
            get
            {
                return System.IO.Path.Combine(App_Path, Apache_current, "conf", "httpd.conf");
            }
        }
        public string Apache_httpd_vhosts
        {
            get
            {
                return System.IO.Path.Combine(App_Path, Apache_current, "conf", "extra", "httpd-vhosts.conf");
            }
        }
        public string phpmyadmin_config 
        { 
            get 
            {
                string htdocs = Path.Combine(App_Path, Apache_current, "htdocs");
                string[] subdir = (from x in Directory.GetDirectories(htdocs) select new DirectoryInfo(x).Name).ToArray();
                string pma_config = "";
                foreach(string s in subdir)
                {
                    if(s.StartsWith("pma"))
                    {
                        string pma_base = Path.Combine(htdocs, s);
                        pma_config = Path.Combine(pma_base, "config.inc.php");
                        if (!System.IO.File.Exists(pma_config))
                        {
                            pma_config = "";
                        }
                        break;
                    }
                }
                return pma_config;
            } 
        }
        public string PHP_ini
        {
            get
            {
                return System.IO.Path.Combine(App_Path, PHP_current, "php.ini");
            }
        }
        public string MariaDB_ini
        {
            get
            {
                return System.IO.Path.Combine(App_Path, MariaDB_current, "data", "my.ini");
            }
        }
        public string getPID_apache
        {
            get
            {
                if (!string.IsNullOrEmpty(pid_currentproc_apache))
                {
                    return pid_currentproc_apache;
                }
                else
                    return "";
            }
        }
        public string getPID_mariadb
        {
            get
            {
                if (!string.IsNullOrEmpty(pid_currentproc_mariadb))
                {
                    return pid_currentproc_mariadb;
                }
                else
                    return "";
            }
        }
        public string url_phpmyadmin
        {
            get
            {
                return "http://127.0.0.1:" + apache_http_port + "/phpmyadmin";

                string htdocs = Path.Combine(Apache_current, "htdocs");
                string[] subdir = (from x in Directory.GetDirectories(htdocs) select new DirectoryInfo(x).Name).ToArray();
                string pma_url = "";
                foreach (string s in subdir)
                {
                    if (s.StartsWith("pma"))
                    {
                        pma_url = "http://127.0.0.1:" + apache_http_port + "/" + s + "/index.php";
                        break;
                    }
                }
                return pma_url;
            }
        }
        public string url_adminer
        {
            get
            {
                return "http://127.0.0.1:" + apache_http_port + "/adminer";
                string htdocs = Path.Combine(Apache_current, "htdocs");
                string[] name_files = (from x in Directory.GetFiles(htdocs) select new DirectoryInfo(x).Name).ToArray();
                string adminer_url = "";
                foreach (string s in name_files)
                {
                    if (s.StartsWith("adminer"))
                    {
                        adminer_url = "http://127.0.0.1:" + apache_http_port + "/" + s;
                        break;
                    }
                }
                return adminer_url;
            }
        }
        public string url_phpinfo
        {
            get
            {
                return "http://127.0.0.1:" + apache_http_port + "/info.php";
            }
        }
        public string bash_exe_path
        {
            get
            {
                return System.IO.Path.Combine(App_Path, "PortableGit", "bin", "bash.exe");
            }
        }
        #endregion


        public ConfigVar(System.Windows.Forms.Form mainForm)
        {
            this.mainForm = mainForm;
            this._env = ZampGUILib.getval_from_appsetting("env");
            this.temp_folder = ZampGUILib.getval_from_appsetting("temp_folder");
            this.YN_DEBUG = ZampGUILib.getval_from_appsetting("YN_DEBUG");
            createJsonFileIfNotExists();
            this.json = ZampGUILib.getJson_Env();
            this.pathBase = (string)json[_env]["pathBase"];
            this.Apache_current = (string)json[_env]["Apache_current"]; //addPath(new string[] { this.App_Path }, (string)json[_env]["Apache_current"]);

            //foreach (Newtonsoft.Json.Linq.JProperty kv in json[_env]["MariaDB_list"])
            //this.MariaDB_list.Add(kv.Name, addPath(new string[] { this.pathBase, "Apps" }, kv.Value.ToString()));
            foreach (JToken item in (JArray)json[_env]["MariaDB_list"])
            {
                if (!string.IsNullOrEmpty(item.ToString())) 
                    this.MariaDB_list.Add(item.ToString());
            }
            this.MariaDB_current = (string)json[_env]["MariaDB_current"];

            foreach (JToken item in (JArray)json[_env]["PHP_list"])
            {
                if (!string.IsNullOrEmpty(item.ToString())) 
                    this.PHP_list.Add(item.ToString());
            }
            this.PHP_current = (string)json[_env]["PHP_current"];
            this.pathGit = (string)json[_env]["pathGit"];
            this.pathSass = (string)json[_env]["pathSass"];
            this.pathNode = (string)json[_env]["pathNode"];
            this.pathWPcli = (string)json[_env]["pathWPcli"];
            this.pathBackupSQLFolder = (string)json[_env]["pathBackupSQLFolder"];



            if (json[_env]["checkBackUpAllDBOnExit"] == null || (string)json[_env]["checkBackUpAllDBOnExit"] == "")
                this.checkBackUpAllDBOnExit = false;
            else
                this.checkBackUpAllDBOnExit = (bool)json[_env]["checkBackUpAllDBOnExit"];

            if (json[_env]["checkUpdateZampgui"] == null || (string)json[_env]["checkUpdateZampgui"] == "")
                this.checkUpdateZampgui = false;
            else
                this.checkUpdateZampgui = (bool)json[_env]["checkUpdateZampgui"];

            this.default_editor = (string)json[_env]["default_editor"];
            this.apache_http_port = (string)json[_env]["apache_http_port"];
            this.apache_https_port = (string)json[_env]["apache_https_port"];
            this.mariadb_port = (string)json[_env]["mariadb_port"];
            this.pid_currentproc_apache = (string)json[_env]["pid_currentproc_apache"];
            this.pid_currentproc_mariadb = (string)json[_env]["pid_currentproc_mariadb"];


            if (json[_env]["uuid_str"] == null || (string)json[_env]["uuid_str"] == "")
            {
                Guid myuuid = Guid.NewGuid();
                string myuuidAsString = myuuid.ToString();
                this.uuid_str = myuuidAsString;
                json[_env]["uuid_str"] = myuuidAsString;
            }
            else
            {
                this.uuid_str = (string)json[_env]["uuid_str"];
            }
            


            this.ListPathConsole = new List<string>();
            foreach (string s in json[_env]["ListPathConsole"])
            {
                this.ListPathConsole.Add(s);
            }

            apache_vers = (string)json[_env]["vers_sf"]["apache_vers"];
            php_vers = (string)json[_env]["vers_sf"]["php_vers"];
            mariadb_vers = (string)json[_env]["vers_sf"]["mariadb_vers"];
            composer_vers = (string)json[_env]["vers_sf"]["composer_vers"];
            git_vers = (string)json[_env]["vers_sf"]["git_vers"];
            node_vers = (string)json[_env]["vers_sf"]["node_vers"];
            sass_vers = (string)json[_env]["vers_sf"]["sass_vers"];
            wp_cli_vers = (string)json[_env]["vers_sf"]["wp_cli_vers"];


            wpop = new WP_Options();
            wpop.txt_nomesito = (string)json[_env]["wp_options"]["txt_nomesito"];
            wpop.txt_User = (string)json[_env]["wp_options"]["txt_User"];
            wpop.txt_Pwd = (string)json[_env]["wp_options"]["txt_Pwd"];
            wpop.txt_Email = (string)json[_env]["wp_options"]["txt_Email"];
            wpop.txt_DisplayName = (string)json[_env]["wp_options"]["txt_DisplayName"];
            wpop.comboBoxLang = (string)json[_env]["wp_options"]["comboBoxLang"];
            wpop.comboBoxWPVersion = (string)json[_env]["wp_options"]["comboBoxWPVersion"];

            wpop.txtNumPost = (int)json[_env]["wp_options"]["txtNumPost"];
            wpop.txtSiteName = (string)json[_env]["wp_options"]["txtSiteName"];
            wpop.txtDescription = (string)json[_env]["wp_options"]["txtDescription"];
            wpop.checkOverwriteWebSite = (bool)json[_env]["wp_options"]["checkOverwriteWebSite"];
            wpop.checkDisableAutoUpdate = (bool)json[_env]["wp_options"]["checkDisableAutoUpdate"];
            wpop.checkEnableWPPostRevision = (bool)json[_env]["wp_options"]["checkEnableWPPostRevision"];
            wpop.txtNumericPostRevision = (int)json[_env]["wp_options"]["txtNumericPostRevision"];
            wpop.checkRemoveDefaultPlugin = (bool)json[_env]["wp_options"]["checkRemoveDefaultPlugin"];
            wpop.checkRemoveDefaultTheme = (bool)json[_env]["wp_options"]["checkRemoveDefaultTheme"];
            wpop.txtPluginList = (string)json[_env]["wp_options"]["txtPluginList"];
            wpop.txtThemeList = (string)json[_env]["wp_options"]["txtThemeList"];

            wpop.timezone_string = (string)json[_env]["wp_options"]["timezone_string"];
            wpop.time_format = (string)json[_env]["wp_options"]["time_format"];
            wpop.rss_use_excerpt = (string)json[_env]["wp_options"]["rss_use_excerpt"];
            wpop.uploads_use_yearmonth_folders = (string)json[_env]["wp_options"]["uploads_use_yearmonth_folders"];
            wpop.permalink_string = (string)json[_env]["wp_options"]["permalink_string"];
            





            foreach (JToken item in (JArray)json[_env]["vers_wp"])
            {
                string num = item["num"].ToString();
                string theme = item["theme"].ToString();
                SingolaVersioneWP swp = new SingolaVersioneWP() { num = num, theme = theme };
                Vers_WP.Add(swp);
            }



            if (!string.IsNullOrEmpty(pid_currentproc_apache))
            {
                if (!int.TryParse(pid_currentproc_apache, out int nd) || !ZampGUILib.checkRunningProc(pid_currentproc_apache) || ZampGUILib.getNameProc_fromPID(pid_currentproc_apache) != this.procApache)
                {
                    updatePID(typeProg.apache, typeStartorKill.kill, Convert.ToInt32(pid_currentproc_apache));
                }
            }
            if (!string.IsNullOrEmpty(pid_currentproc_mariadb))
            {
                if (!int.TryParse(pid_currentproc_mariadb, out int ne) || !ZampGUILib.checkRunningProc(pid_currentproc_mariadb) || ZampGUILib.getNameProc_fromPID(pid_currentproc_mariadb) != this.procMariaDB)
                {
                    updatePID(typeProg.mariadb, typeStartorKill.kill, Convert.ToInt32(pid_currentproc_mariadb));
                }
            }


            caricasites();
            
        }
        public bool importJson(JObject jimported)
        {
            bool bOk = true;
            this.json = this.json ?? ZampGUILib.getJson_Env();

            IList<string> keys = jimported.Properties().Select(p => p.Name).ToList(); //extract key
            JObject jimp_env = (JObject)jimported[keys[0]];

            //json[_env]["pathGit"] = jimp_env["pathGit"];
            //pathGit = (string)jimp_env["pathGit"];

            //json[_env]["pathSass"] = jimp_env["pathSass"];
            //pathSass = (string)jimp_env["pathSass"];

            //json[_env]["pathNode"] = jimp_env["pathNode"];
            //pathNode = (string)jimp_env["pathNode"];

            //json[_env]["pathWPcli"] = jimp_env["pathWPcli"];
            //pathWPcli = (string)jimp_env["pathWPcli"];

            json[_env]["pathBackupSQLFolder"] = jimp_env["pathBackupSQLFolder"];
            pathBackupSQLFolder = (string)jimp_env["pathBackupSQLFolder"];
            

            json[_env]["checkBackUpAllDBOnExit"] = jimp_env["checkBackUpAllDBOnExit"];
            if (jimp_env["checkBackUpAllDBOnExit"] == null || (string)jimp_env["checkBackUpAllDBOnExit"] == "")
                checkBackUpAllDBOnExit = false;
            else
                checkBackUpAllDBOnExit = (bool)jimp_env["checkBackUpAllDBOnExit"];

            json[_env]["checkUpdateZampgui"] = jimp_env["checkUpdateZampgui"];
            if (jimp_env["checkUpdateZampgui"] == null || (string)jimp_env["checkUpdateZampgui"] == "")
                checkUpdateZampgui = false;
            else
                checkUpdateZampgui = (bool)jimp_env["checkUpdateZampgui"];


            json[_env]["default_editor"] = jimp_env["default_editor"];
            default_editor = (string)jimp_env["default_editor"];

            json[_env]["uuid_str"] = jimp_env["uuid_str"];
            uuid_str = (string)jimp_env["uuid_str"];

            json[_env]["ListPathConsole"] = jimp_env["ListPathConsole"];
            ListPathConsole = new List<string>();
            foreach (string s in jimp_env["ListPathConsole"])
            {
                this.ListPathConsole.Add(s);
            }


            //json[_env]["vers_sf"] = new JObject();
            if(jimp_env["wp_options"] != null)
            {
                this.wpop = new WP_Options();
                JObject wp_options = (JObject)jimp_env["wp_options"];
                json[_env]["wp_options"] = wp_options;
                JProperty[] arr = wp_options.Properties().ToArray();
                //this.wpop.txt_nomesito = wp_options.Properties().Where(x => x.Name == "txt_nomesito").Select(x => x.Value).FirstOrDefault();
                this.wpop.txt_nomesito = wp_options.Property("txt_nomesito").Value.ToString();
                this.wpop.txt_User = wp_options.Property("txt_User").Value.ToString();
                this.wpop.txt_Pwd = wp_options.Property("txt_Pwd").Value.ToString();
                this.wpop.txt_Email = wp_options.Property("txt_Email").Value.ToString();
                this.wpop.txt_DisplayName = wp_options.Property("txt_DisplayName").Value.ToString();
                this.wpop.comboBoxLang = wp_options.Property("comboBoxLang").Value.ToString();
                this.wpop.comboBoxWPVersion = wp_options.Property("comboBoxWPVersion").Value.ToString();

                this.wpop.txtNumPost = Convert.ToInt32(wp_options.Property("txtNumPost").Value.ToString());
                this.wpop.txtSiteName = wp_options.Property("txtSiteName").Value.ToString();
                this.wpop.txtDescription = wp_options.Property("txtDescription").Value.ToString();
                this.wpop.checkOverwriteWebSite = wp_options.Property("checkOverwriteWebSite").Value.ToString().Trim().ToLower() == "true"? true: false;
                this.wpop.checkDisableAutoUpdate = wp_options.Property("checkDisableAutoUpdate").Value.ToString().Trim().ToLower() == "true" ? true : false;
                this.wpop.checkEnableWPPostRevision = wp_options.Property("checkEnableWPPostRevision").Value.ToString().Trim().ToLower() == "true" ? true : false;
                this.wpop.txtNumericPostRevision = Convert.ToInt32(wp_options.Property("txtNumericPostRevision").Value.ToString());
                this.wpop.checkRemoveDefaultPlugin = wp_options.Property("checkRemoveDefaultPlugin").Value.ToString().Trim().ToLower() == "true" ? true : false;
                this.wpop.checkRemoveDefaultTheme = wp_options.Property("checkRemoveDefaultTheme").Value.ToString().Trim().ToLower() == "true" ? true : false;
                this.wpop.txtPluginList = wp_options.Property("txtPluginList").Value.ToString();
                this.wpop.txtThemeList = wp_options.Property("txtThemeList").Value.ToString();

                this.wpop.timezone_string = wp_options.Property("timezone_string").Value.ToString();
                this.wpop.time_format = wp_options.Property("time_format").Value.ToString();
                this.wpop.rss_use_excerpt = wp_options.Property("rss_use_excerpt").Value.ToString();
                this.wpop.uploads_use_yearmonth_folders = wp_options.Property("uploads_use_yearmonth_folders").Value.ToString();
                this.wpop.permalink_string = wp_options.Property("permalink_string").Value.ToString();
            }
            
            


            json[_env]["sites"] = jimp_env["sites"];
            caricasites();

            ZampGUILib.setJson_Env(json);
            update_software_version(true);
            return bOk;
        }
        public void createJsonFileIfNotExists()
        {
            string path_json_config = ZampGUILib.getJsonPath();
            JObject jsonObject, rel;
            string rootFolder = ZampGUILib.getRootFolder(mainForm);
            if(System.IO.File.Exists(path_json_config))
            {
                string temp = File.ReadAllText(path_json_config);
                jsonObject = JObject.Parse(temp);
            }
            else
            {
                jsonObject = new JObject();
            }


            if (jsonObject[_env] == null)
            {
                rel = new JObject();
                jsonObject.Add(this._env, rel);
            }
            else
            {
                rel = (JObject)jsonObject[_env];
            }


            string uuid_str = "";

            if (rel["pathBase"] == null)
            {
                rel.Add("pathBase", rootFolder);
            }
            
            if (rel["Apache_current"] == null)
            {
                rel.Add("Apache_current", ZampGUILib.get_first_dir(rootFolder, "Apache24"));
            }

            if (rel["MariaDB_list"] == null)
            {
                JArray jarrayObjTemp = new JArray();
                foreach(string s in ZampGUILib.get_dirs(rootFolder, "mariadb-"))
                {
                    jarrayObjTemp.Add(s);
                }
                rel.Add("MariaDB_list", jarrayObjTemp);
            }

            if (rel["MariaDB_current"] == null)
            {
                string dir = ZampGUILib.get_first_dir(rootFolder, "mariadb-");
                rel.Add("MariaDB_current", dir);
            }
            
            if (rel["PHP_list"] == null)
            {
                JArray jarrayObjTemp = new JArray();
                foreach (string s in ZampGUILib.get_dirs(rootFolder, "php-"))
                {
                    jarrayObjTemp.Add(s);
                }
                rel.Add("PHP_list", jarrayObjTemp);
            }
            
            if (rel["PHP_current"] == null)
            {
                string dir = ZampGUILib.get_first_dir(rootFolder, "php-");
                rel.Add("PHP_current", dir);
            }
            
            if (rel["pathGit"] == null)
            {
                string temppath = Path.Combine(rootFolder, "Apps", "PortableGit");
                if (Directory.Exists(temppath))
                {
                    rel.Add("pathGit", "PortableGit");
                }
            }
            
            if (rel["pathSass"] == null)
            {
                string temppath = Path.Combine(rootFolder, "Apps", "dart-sass");
                if (Directory.Exists(temppath))
                {
                    rel.Add("pathSass", "dart-sass");
                }
            }
            
            if (rel["pathNode"] == null)
            {
                string dir = ZampGUILib.get_first_dir(rootFolder, "node-", false);
                rel.Add("pathNode", dir);
            }

            if (rel["pathWPcli"] == null)
            {
                string temppath = Path.Combine(rootFolder, "Apps", "wp-cli");
                if (Directory.Exists(temppath))
                {
                    rel.Add("pathWPcli", "wp-cli");
                }
            }

            if (rel["pathBackupSQLFolder"] == null)
            {
                rel.Add("pathBackupSQLFolder", "");
            }

            if (rel["checkBackUpAllDBOnExit"] == null)
            {
                rel.Add("checkBackUpAllDBOnExit", "");
            }

            if (rel["checkUpdateZampgui"] == null)
            {
                rel.Add("checkUpdateZampgui", "");
            }

            if (rel["default_editor"] == null)
            {
                rel.Add("default_editor", "notepad.exe");
            }
            
            if (rel["apache_http_port"] == null)
            {
                rel.Add("apache_http_port", "80");
            }

            if (rel["apache_https_port"] == null)
            {
                rel.Add("apache_https_port", "443");
            }

            if (rel["mariadb_port"] == null)
            {
                rel.Add("mariadb_port", "3306");
            }

            if (rel["pid_currentproc_apache"] == null)
            {
                rel.Add("pid_currentproc_apache", "");
            }

            if (rel["pid_currentproc_mariadb"] == null)
            {
                rel.Add("pid_currentproc_mariadb", "");
            }

            if (rel["uuid_str"] == null)
            {
                rel.Add("uuid_str", "");
            }
            else
            {
                uuid_str = rel["uuid_str"].ToString();
            }

            if (rel["ListPathConsole"] == null)
            {
                JArray jarrayObjTemp = new JArray();
                rel.Add("ListPathConsole", jarrayObjTemp);
            }

            if (rel["vers_sf"] == null)
            {
                rel.Add("vers_sf", new JObject(
                    new JProperty("apache_vers", "")
                    , new JProperty("php_vers", "")
                    , new JProperty("mariadb_vers", "")
                    , new JProperty("composer_vers", "")
                    , new JProperty("git_vers", "")
                    , new JProperty("node_vers", "")
                    , new JProperty("sass_vers", "")
                    , new JProperty("wp_cli_vers", "")
                ));
            }
            else
            {
                var vers_sf = (JObject)rel["vers_sf"];
                if (vers_sf["apache_vers"] == null)
                {
                    vers_sf.Add("apache_vers", "");
                }
                if (vers_sf["php_vers"] == null)
                {
                    vers_sf.Add("php_vers", "");
                }
                if (vers_sf["mariadb_vers"] == null)
                {
                    vers_sf.Add("mariadb_vers", "");
                }
                if (vers_sf["composer_vers"] == null)
                {
                    vers_sf.Add("composer_vers", "");
                }
                if (vers_sf["git_vers"] == null)
                {
                    vers_sf.Add("git_vers", "");
                }
                if (vers_sf["node_vers"] == null)
                {
                    vers_sf.Add("node_vers", "");
                }
                if (vers_sf["sass_vers"] == null)
                {
                    vers_sf.Add("sass_vers", "");
                }
                if (vers_sf["wp_cli_vers"] == null)
                {
                    vers_sf.Add("wp_cli_vers", "");
                }
            }

            if (rel["wp_options"] == null)
            {
                rel.Add("wp_options", new JObject(
                    new JProperty("txt_nomesito", "")
                    , new JProperty("txt_User", "admin")
                    , new JProperty("txt_Pwd", "admin")
                    , new JProperty("txt_Email", "admin@gmail.com")
                    , new JProperty("txt_DisplayName", "admin")
                    , new JProperty("comboBoxLang", "en_US")
                    , new JProperty("comboBoxWPVersion", "")
                    
                    , new JProperty("txtNumPost", "0")
                    , new JProperty("txtSiteName", "")
                    , new JProperty("txtDescription", "")
                    , new JProperty("checkOverwriteWebSite", false)
                    , new JProperty("checkDisableAutoUpdate", false)
                    , new JProperty("checkEnableWPPostRevision", false)
                    , new JProperty("txtNumericPostRevision", "1")
                    , new JProperty("checkRemoveDefaultPlugin", false)
                    , new JProperty("checkRemoveDefaultTheme", false)
                    , new JProperty("txtPluginList", "")
                    , new JProperty("txtThemeList", "")

                    , new JProperty("timezone_string", "")
                    , new JProperty("time_format", "")
                    , new JProperty("rss_use_excerpt", "")
                    , new JProperty("uploads_use_yearmonth_folders", "")
                    , new JProperty("permalink_string", "")
                ));

                if (uuid_str == "mio")
                {
                    var wp_options = (JObject)rel["wp_options"];
                    wp_options.Property("txt_DisplayName").Value = "pabloindev";
                    wp_options.Property("txtNumPost").Value = "3";
                    wp_options.Property("checkDisableAutoUpdate").Value = true;
                    wp_options.Property("checkEnableWPPostRevision").Value = true;
                    wp_options.Property("txtNumericPostRevision").Value = "10";
                    wp_options["checkRemoveDefaultPlugin"] = true;
                    wp_options["checkRemoveDefaultTheme"] = true;
                    wp_options["txtPluginList"] = "custom-css-js svg-support";

                    wp_options["timezone_string"] = "Europe/Rome";
                    wp_options["time_format"] = "H:i";
                    wp_options["rss_use_excerpt"] = "1";
                    wp_options["uploads_use_yearmonth_folders"] = "0";
                    wp_options["permalink_string"] = "/%postname%/";
                }
            }
            else
            {
                var wp_options = (JObject)rel["wp_options"];
                if (wp_options["txt_nomesito"] == null)
                {
                    wp_options.Add("txt_nomesito", "");
                }
                if (wp_options["txt_User"] == null)
                {
                    wp_options.Add("txt_User", "admin");
                }
                if (wp_options["txt_Pwd"] == null)
                {
                    wp_options.Add("txt_Pwd", "admin");
                }
                if (wp_options["txt_Email"] == null)
                {
                    wp_options.Add("txt_Email", "admin@gmail.com");
                }
                if (wp_options["txt_DisplayName"] == null)
                {
                    wp_options.Add("txt_DisplayName", "admin");
                }
                if (wp_options["comboBoxLang"] == null)
                {
                    wp_options.Add("comboBoxLang", "en_US");
                }
                if (wp_options["comboBoxWPVersion"] == null)
                {
                    wp_options.Add("comboBoxWPVersion", "");
                }
                if (wp_options["txtNumPost"] == null)
                {
                    wp_options.Add("txtNumPost", "0");
                }
                if (wp_options["txtSiteName"] == null)
                {
                    wp_options.Add("txtSiteName", "");
                }
                if (wp_options["txtDescription"] == null)
                {
                    wp_options.Add("txtDescription", "");
                }
                if (wp_options["checkOverwriteWebSite"] == null)
                {
                    wp_options.Add("checkOverwriteWebSite", false);
                }
                if (wp_options["checkDisableAutoUpdate"] == null)
                {
                    wp_options.Add("checkDisableAutoUpdate", false);
                }
                if (wp_options["checkEnableWPPostRevision"] == null)
                {
                    wp_options.Add("checkEnableWPPostRevision", false);
                }
                if (wp_options["txtNumericPostRevision"] == null)
                {
                    wp_options.Add("txtNumericPostRevision", "1");
                }
                if (wp_options["checkRemoveDefaultPlugin"] == null)
                {
                    wp_options.Add("checkRemoveDefaultPlugin", false);
                }
                if (wp_options["checkRemoveDefaultTheme"] == null)
                {
                    wp_options.Add("checkRemoveDefaultTheme", false);
                }
                if (wp_options["txtPluginList"] == null)
                {
                    wp_options.Add("txtPluginList", "");
                }
                if (wp_options["txtThemeList"] == null)
                {
                    wp_options.Add("txtThemeList", "");
                }

                if (wp_options["timezone_string"] == null)
                {
                    wp_options.Add("timezone_string", "Europe/Rome");
                }
                if (wp_options["time_format"] == null)
                {
                    wp_options.Add("time_format", "H:i");
                }
                if (wp_options["rss_use_excerpt"] == null)
                {
                    wp_options.Add("rss_use_excerpt", "1");
                }
                if (wp_options["uploads_use_yearmonth_folders"] == null)
                {
                    wp_options.Add("uploads_use_yearmonth_folders", "0");
                }
                if (wp_options["permalink_string"] == null)
                {
                    wp_options.Add("permalink_string", "/%postname%/");
                }
            }

            if (rel["sites"] == null)
            {
                rel.Add("sites", new JObject());
            }

            if (rel["vers_wp"] == null)
            {
                JArray jarrayObjTemp = new JArray() {
                    new JObject(
                        new JProperty("num", "6.5.5")
                        , new JProperty("theme", "")
                    ),
                    new JObject(
                        new JProperty("num", "6.4.5")
                        , new JProperty("theme", "")
                    ),
                    new JObject(
                        new JProperty("num", "6.3.5")
                        , new JProperty("theme", "")
                    ),
                    new JObject(
                        new JProperty("num", "6.2.6")
                        , new JProperty("theme", "")
                    ),
                    new JObject(
                        new JProperty("num", "6.1.6")
                        , new JProperty("theme", "")
                    )
                };
                rel.Add("vers_wp", jarrayObjTemp);
            }


            ZampGUILib.setJson_Env(jsonObject);
        }
        public string checkPortInUse()
        {
            string msg_port_in_use = "";

            if (ZampGUILib.port_in_use(apache_http_port, pid_currentproc_apache))
            {
                msg_port_in_use += "http port \"" + apache_http_port + "\" in use" + Environment.NewLine;
            }
            if (ZampGUILib.port_in_use(apache_https_port, pid_currentproc_apache))
            {
                msg_port_in_use += "https port \"" + apache_https_port + "\" in use" + Environment.NewLine;
            }
            if (ZampGUILib.port_in_use(mariadb_port, pid_currentproc_mariadb))
            {
                msg_port_in_use += "MariaDB port \"" + mariadb_port + "\" in use" + Environment.NewLine;
            }
            return msg_port_in_use;
        }
        public void caricasites()
        {
            listaSites = new List<RigaSite>();
            this.json = this.json ?? ZampGUILib.getJson_Env();
            JToken sites = json[_env]["sites"];
            if (sites == null)
            {
                listaSites.Add(new RigaSite());
            }
            else
            {
                foreach (Newtonsoft.Json.Linq.JProperty kv in sites)
                {
                    listaSites.Add(new RigaSite() { Name = kv.Name, Url = kv.Value.ToString() });
                }
            }
        }
        public string validateSetting()
        {
            string sout = "";
            if (string.IsNullOrEmpty(pathBase) || !System.IO.Directory.Exists(pathBase))
            {
                sout += "pathBase incorrect in config.json" + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(Apache_current) || !System.IO.File.Exists(Apache_exe))
            {
                sout += "pathApache incorrect in config.json" + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(MariaDB_current) || !System.IO.File.Exists(MariaDB_exe)) 
            { 
                sout += "pathMariaDB incorrect in config.json" + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(PHP_current) || !System.IO.File.Exists(PHP_exe))
            { 
                sout += "pathPHP incorrect in config.json" + Environment.NewLine;
            }
            //if (default_editor != "notepad.exe" && !System.IO.File.Exists(default_editor)) 
            //{ 
            //    sout += "default_editor incorrect in config.json"; 
            //}
            if(!int.TryParse(apache_http_port, out int na))
            {
                sout += "apache_http_port is not a number in config.json";
            }
            if (!int.TryParse(apache_https_port, out int nb))
            {
                sout += "apache_https_port is not a number in config.json";
            }
            if (!int.TryParse(mariadb_port, out int nc))
            {
                sout += "mariadb_port is not a number in config.json";
            }
            return sout;
        }
        public void otherUpdate()
        {
            this.json = this.json ?? ZampGUILib.getJson_Env();
            json[_env]["checkBackUpAllDBOnExit"] = checkBackUpAllDBOnExit;
            json[_env]["checkUpdateZampgui"] = checkUpdateZampgui;
            ZampGUILib.setJson_Env(json);
        }
        public void updateDefaultEditor(string editor_path)
        {
            this.json = this.json ?? ZampGUILib.getJson_Env();
            json[_env]["default_editor"] = editor_path;
            ZampGUILib.setJson_Env(json);

            /*
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AppSettingsSection app = config.AppSettings;

            this.default_editor_path = default_editor_path;

            app.Settings.Remove("default_editor_path");
            app.Settings.Add("default_editor_path", default_editor_path);

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            */
        }
        public void updateAdditionalPath()
        {
            this.json = this.json ?? ZampGUILib.getJson_Env();
            json[_env]["ListPathConsole"] = JArray.FromObject(this.ListPathConsole);

            json[_env]["pathGit"] = pathGit;//pathGit.StartsWith(System.IO.Path.Combine(pathBase, "Apps"))? pathGit.Remove(0, System.IO.Path.Combine(pathBase, "Apps").Length).Trim('\\'): pathGit;
            json[_env]["pathSass"] = pathSass;//pathSass.StartsWith(System.IO.Path.Combine(pathBase, "Apps")) ? pathSass.Remove(0, System.IO.Path.Combine(pathBase, "Apps").Length).Trim('\\') : pathSass;
            json[_env]["pathNode"] = pathNode; // pathNode.StartsWith(System.IO.Path.Combine(pathBase, "Apps")) ? pathNode.Remove(0, System.IO.Path.Combine(pathBase, "Apps").Length).Trim('\\') : pathNode;
            json[_env]["pathBackupSQLFolder"] = pathBackupSQLFolder;
            

            wp_cli_vers = refresh_wpcli_vers();
            json[_env]["vers_sf"]["wp_cli_vers"] = wp_cli_vers;

            sass_vers = refresh_sass_vers();
            json[_env]["vers_sf"]["sass_vers"] = sass_vers;

            git_vers = refresh_git_vers();
            json[_env]["vers_sf"]["git_vers"] = git_vers;

            node_vers = refresh_node_vers();
            json[_env]["vers_sf"]["node_vers"] = node_vers;

            ZampGUILib.setJson_Env(json);
        }
        public void updatePort()
        {
            this.json = this.json ?? ZampGUILib.getJson_Env();
            json[_env]["apache_http_port"] = apache_http_port;
            json[_env]["apache_https_port"] = apache_https_port;
            json[_env]["mariadb_port"] = mariadb_port;
            ZampGUILib.setJson_Env(json);


            //cambio file fisici
            //--------------------------
            string[] arrfiles = { Apache_httpd_conf, MariaDB_ini };

            foreach (var f in arrfiles)
            {
                if (!System.IO.File.Exists(f))
                {
                    ZampGUILib.printMsg_and_exit("file " + f + " not found", true);
                    continue;
                }

                string text = System.IO.File.ReadAllText(f);
                if (f.Equals(Apache_httpd_conf))
                {
                    var regex = new Regex(@"^\s*Define HTTP_PORT.*$", RegexOptions.Multiline);
                    text = regex.Replace(text, "Define HTTP_PORT  \"" + apache_http_port + "\"");

                    regex = new Regex(@"^\s*Define HTTPS_PORT.*$", RegexOptions.Multiline);
                    text = regex.Replace(text, "Define HTTPS_PORT  \"" + apache_https_port + "\"");
                }
                if (f.Equals(MariaDB_ini))
                {
                    var regex = new Regex(@"^\s*port.*$", RegexOptions.Multiline);
                    text = regex.Replace(text, "port=" + mariadb_port);
                }

                System.IO.File.WriteAllText(f, text);
            }

            //trying to change phpmyadmin config
            string phpmyadmin_config = this.phpmyadmin_config;
            if (File.Exists(phpmyadmin_config))
            {
                string text = System.IO.File.ReadAllText(phpmyadmin_config);
                var regex = new Regex(@"^\s*\$cfg\['Servers'\]\[\$i\]\['port'\].*$", RegexOptions.Multiline);
                text = regex.Replace(text, "$cfg['Servers'][$i]['port'] = '" + mariadb_port + "';");

                regex = new Regex(@"^\s*\$cfg\['Servers'\]\[\$i\]\['controlport'\].*$", RegexOptions.Multiline);
                text = regex.Replace(text, "$cfg['Servers'][$i]['controlport'] = '" + mariadb_port + "';");
                System.IO.File.WriteAllText(phpmyadmin_config, text);
            }
        }
        public void updateSites()
        {
            List<JProperty> arr = new List<JProperty>();
            foreach (var item in this.listaSites)
            {
                if (!string.IsNullOrEmpty(item.Name) && !string.IsNullOrEmpty(item.Url))
                {
                    arr.Add(new JProperty(item.Name, item.Url));
                }
            }

            this.json = this.json ?? ZampGUILib.getJson_Env();
            this.json[this._env]["sites"] = new JObject(arr);
            ZampGUILib.setJson_Env(this.json);
        }
        public void saveOptionsWP()
        {
            JObject obj = new JObject(
                new JProperty("txt_nomesito", this.wpop.txt_nomesito)
                , new JProperty("txt_User", this.wpop.txt_User)
                , new JProperty("txt_Pwd", this.wpop.txt_Pwd)
                , new JProperty("txt_Email", this.wpop.txt_Email)
                , new JProperty("txt_DisplayName", this.wpop.txt_DisplayName)
                , new JProperty("comboBoxLang", this.wpop.comboBoxLang)
                , new JProperty("comboBoxWPVersion", this.wpop.comboBoxWPVersion)

                , new JProperty("txtNumPost", this.wpop.txtNumPost)
                , new JProperty("txtSiteName", this.wpop.txtSiteName)
                , new JProperty("txtDescription", this.wpop.txtDescription)
                , new JProperty("checkOverwriteWebSite", this.wpop.checkOverwriteWebSite)
                , new JProperty("checkDisableAutoUpdate", this.wpop.checkDisableAutoUpdate)
                , new JProperty("checkEnableWPPostRevision", this.wpop.checkEnableWPPostRevision)
                , new JProperty("txtNumericPostRevision", this.wpop.txtNumericPostRevision)
                , new JProperty("checkRemoveDefaultPlugin", this.wpop.checkRemoveDefaultPlugin)
                , new JProperty("checkRemoveDefaultTheme", this.wpop.checkRemoveDefaultTheme)
                , new JProperty("txtPluginList", this.wpop.txtPluginList)
                , new JProperty("txtThemeList", this.wpop.txtThemeList)

                , new JProperty("timezone_string", this.wpop.timezone_string)
                , new JProperty("time_format", this.wpop.time_format)
                , new JProperty("rss_use_excerpt", this.wpop.rss_use_excerpt)
                , new JProperty("uploads_use_yearmonth_folders", this.wpop.uploads_use_yearmonth_folders)
                , new JProperty("permalink_string", this.wpop.permalink_string)
            );

            this.json = this.json ?? ZampGUILib.getJson_Env();
            this.json[this._env]["wp_options"] = obj;
            ZampGUILib.setJson_Env(this.json);
        }

        public void updateWP_vers()
        {
            JArray arr = new JArray();

            //List<JProperty> arr = new List<JProperty>();
            foreach (var item in this.Vers_WP)
            {
                var obj = new JObject() { 
                    new JProperty("num", item.num)
                    , new JProperty("theme", item.theme) 
                };
                arr.Add(obj);
            }

            this.json = this.json ?? ZampGUILib.getJson_Env();
            this.json[this._env]["vers_wp"] = arr;
            ZampGUILib.setJson_Env(this.json);
        }


        public void updatePID(typeProg type_program, typeStartorKill type_op, int? pid)
        {
            this.json = this.json ?? ZampGUILib.getJson_Env();
            switch (type_program)
            {
                case typeProg.apache:
                    if(type_op == typeStartorKill.kill)
                    {
                        pid_currentproc_apache = "";
                    }
                    else
                    {
                        pid_currentproc_apache = pid.ToString();
                    }
                    json[_env]["pid_currentproc_apache"] = getPID_apache;
                    break;
                case typeProg.mariadb:
                    if (type_op == typeStartorKill.kill)
                    {
                        pid_currentproc_mariadb = "";
                    }
                    else
                    {
                        pid_currentproc_mariadb = pid.ToString();
                    }
                    json[_env]["pid_currentproc_mariadb"] = getPID_mariadb;
                    break;
            }
            ZampGUILib.setJson_Env(json);
        }
        public void updateUUID()
        {
            this.json = this.json ?? ZampGUILib.getJson_Env();
            if ((string)json[_env]["uuid_str"] != this.uuid_str)
            {
                json[_env]["uuid_str"] = this.uuid_str;
                ZampGUILib.setJson_Env(json);
            }
        }
        public void updatePath(string abs_main_path)
        {
            if(abs_main_path != pathBase)
            {
                this.json = this.json ?? ZampGUILib.getJson_Env();
                pathBase = abs_main_path;
                //pathApache = ZampLib.ZampGUILib.get_first_dir(abs_main_path, "Apache");
                json[_env]["pathBase"] = abs_main_path;
                ZampGUILib.setJson_Env(json);
                




                //update files on hard disk
                List<string> arrfiles = new List<string>();
                arrfiles.Add(Apache_httpd_conf);
                arrfiles.Add(Path.Combine(abs_main_path, "scripts", "start_all.vbs"));
                foreach (string s in MariaDB_list)
                {
                    arrfiles.Add(System.IO.Path.Combine(this.App_Path, s, "data", "my.ini"));
                }
                foreach (string s in PHP_list)
                {
                    arrfiles.Add(System.IO.Path.Combine(this.App_Path, s, "php.ini"));
                }



                foreach (var f in arrfiles)
                {
                    if (!System.IO.File.Exists(f))
                    {
                        ZampGUILib.printMsg_and_exit("file " + f + " not found", true);
                        continue;
                    }
                    string text = System.IO.File.ReadAllText(f);
                    string file_name = Path.GetFileName(f);
                    string dirName = "";

                    switch (file_name)
                    {
                        case "httpd.conf":
                            // Use Regex.Replace to replace the pattern in the input.
                            // ... The pattern N.t indicates three letters.
                            // ... N, any character, and t.
                            text = Regex.Replace(text, @"^Define ZAMPROOT.*", "Define ZAMPROOT \"" + abs_main_path.Replace("\\", "/") + "\"", RegexOptions.Multiline);
                            break;
                        case "php.ini":
                            //string name_xdebug_file = ManLib.ManZampLib.get_first_file(Path.Combine(PHP_path_scelto, "ext"), "xdebug");
                            //text = Regex.Replace(text, @"^extension_dir.*", "extension_dir = \"" + Path.Combine(PHP_path_scelto, "ext") + "\"", RegexOptions.Multiline);
                            //if(!string.IsNullOrEmpty(name_xdebug_file))
                            //{
                            //    text = Regex.Replace(text, @"^zend_extension.*", "zend_extension = \"" + name_xdebug_file + "\"", RegexOptions.Multiline);
                            //}
                            dirName = new DirectoryInfo(f).Parent.FullName;
                            string name_xdebug_file = ZampLib.ZampGUILib.get_first_file(Path.Combine(dirName, "ext"), "xdebug");
                            text = Regex.Replace(text, @"^extension_dir.*", "extension_dir = \"" + Path.Combine(dirName, "ext") + "\"", RegexOptions.Multiline);
                            if (!string.IsNullOrEmpty(name_xdebug_file))
                            {
                                text = Regex.Replace(text, @"^zend_extension.*", "zend_extension = \"" + name_xdebug_file + "\"", RegexOptions.Multiline);
                            }
                            break;
                        case "my.ini":
                            dirName = new DirectoryInfo(f).Parent.Parent.FullName;
                            //text = Regex.Replace(text, @"^datadir.*", "datadir=" + Path.Combine(MariaDB_path_scelto, "data").Replace("\\", "/"), RegexOptions.Multiline);
                            //text = Regex.Replace(text, @"^plugin-dir=.*", "plugin-dir=" + Path.Combine(MariaDB_path_scelto, "lib", "plugin").Replace("\\", "/"), RegexOptions.Multiline);
                            text = Regex.Replace(text, @"^datadir.*", "datadir=" + Path.Combine(dirName, "data").Replace("\\", "/"), RegexOptions.Multiline);
                            text = Regex.Replace(text, @"^plugin-dir=.*", "plugin-dir=" + Path.Combine(dirName, "lib", "plugin").Replace("\\", "/"), RegexOptions.Multiline);
                            break;
                        case "start_all.vbs":
                            //
                            string rep1 = "WinScriptHost.Run Chr(34) & \"" + Apache_exe + "\" & Chr(34), 0" + Environment.NewLine;
                            string rep2 = "WinScriptHost.Run Chr(34) & \"" + MariaDB_exe + "\" & Chr(34), 0" + Environment.NewLine;
                            //text = Regex.Replace(text, @"^WinScriptHost.Run.*", rep, RegexOptions.Multiline);

                            text = Regex.Replace(text, @"^WinScriptHost.Run.*httpd.exe.*", rep1, RegexOptions.Multiline);
                            text = Regex.Replace(text, @"^WinScriptHost.Run.*mysqld.exe.*", rep2, RegexOptions.Multiline);
                            break;
                    }
                    System.IO.File.WriteAllText(f, text);
                }
            }
        }
        public void update_software_version(bool bForceReadingFromProcess = false)
        {
            Regex regex;
            Match match;
            bool bSaveJson = false;

            this.json = this.json ?? ZampGUILib.getJson_Env();
            JToken vers_sf = json[_env]["vers_sf"];
            

            if (bForceReadingFromProcess)
            {
                bSaveJson = true;
                apache_vers = refresh_apache_vers();
                vers_sf["apache_vers"] = apache_vers;
                
                php_vers = refresh_php_vers();
                vers_sf["php_vers"] = php_vers;
                
                mariadb_vers = refresh_mariadb_vers();
                vers_sf["mariadb_vers"] = mariadb_vers;
                
                composer_vers = refresh_composer_vers();
                vers_sf["composer_vers"] = composer_vers;
                
                git_vers = refresh_git_vers();
                vers_sf["git_vers"] = git_vers;
                
                node_vers = refresh_node_vers();
                vers_sf["node_vers"] = node_vers;

                sass_vers = refresh_sass_vers();
                vers_sf["sass_vers"] = sass_vers;

                wp_cli_vers = refresh_wpcli_vers();
                vers_sf["wp_cli_vers"] = wp_cli_vers;
            }
            else
            {
                if(string.IsNullOrEmpty(apache_vers))
                {
                    apache_vers = refresh_apache_vers();
                    vers_sf["apache_vers"] = apache_vers;
                    bSaveJson = true;
                }

                if (string.IsNullOrEmpty(php_vers))
                {
                    php_vers = refresh_php_vers();
                    vers_sf["php_vers"] = php_vers;
                    bSaveJson = true;
                }

                if (string.IsNullOrEmpty(mariadb_vers))
                {
                    mariadb_vers = refresh_mariadb_vers();
                    vers_sf["mariadb_vers"] = mariadb_vers;
                    bSaveJson = true;
                }

                if (string.IsNullOrEmpty(composer_vers))
                {
                    composer_vers = refresh_composer_vers();
                    vers_sf["composer_vers"] = composer_vers;
                    bSaveJson = true;
                }

                if (string.IsNullOrEmpty(git_vers))
                {
                    git_vers = refresh_git_vers();
                    vers_sf["git_vers"] = git_vers;
                    bSaveJson = true;
                }

                if (string.IsNullOrEmpty(node_vers))
                {
                    node_vers = refresh_node_vers();
                    vers_sf["node_vers"] = node_vers;
                    bSaveJson = true;
                }

                if (string.IsNullOrEmpty(sass_vers))
                {
                    sass_vers = refresh_sass_vers();
                    vers_sf["sass_vers"] = sass_vers;
                    bSaveJson = true;
                }

                if (string.IsNullOrEmpty(wp_cli_vers))
                {
                    wp_cli_vers = refresh_wpcli_vers();
                    vers_sf["wp_cli_vers"] = wp_cli_vers;
                    bSaveJson = true;
                }
            }

            if(bSaveJson)
            {
                ZampGUILib.setJson_Env(json);
            }

        }
        public JObject getReqInfo_from_WebSite(string ver)
        {
            string contents = "";
            string jsupdate = ZampLib.ZampGUILib.getval_from_appsetting("JSUPDATE");
            jsupdate = jsupdate.ToLower().Trim('/');
            NameValueCollection values = new NameValueCollection();
            values.Add("reqinfo", uuid_str);
            values.Add("ver", ver);

            using (var wc = new System.Net.WebClient())
            {
                wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                byte[] result = wc.UploadValues(jsupdate, "POST", values);
                contents = System.Text.Encoding.UTF8.GetString(result);
                //contents = wc.DownloadString(url_pablospace.ToLower().Trim('/') + "?reqinfo=" + uuid_str + "&ver=" + ver);
            }
            if(string.IsNullOrEmpty(contents))
            {
                contents = "{}";
            }
            JObject jobj = JObject.Parse(contents);
            return jobj;
        }
        public string get_friendly_name(typeProg tpg)
        {
            string friendly_name = "";
            switch (tpg)
            {
                case typeProg.mariadb:
                    friendly_name = "mariadb";
                    break;
                case typeProg.apache:
                    friendly_name = "apache";
                    break;
                case typeProg.editor:
                    friendly_name = "default editor";
                    break;
            }
            return friendly_name;
        }
        public string get_correct_pid(typeProg tpg)
        {
            string pid = "";
            switch (tpg)
            {
                case typeProg.mariadb:
                    pid = getPID_mariadb;
                    break;
                case typeProg.apache:
                    pid = getPID_apache;
                    break;
            }
            return pid;
        }
        public string get_correct_path_prog(typeProg tpg)
        {
            string path = "";
            switch (tpg)
            {
                case typeProg.mariadb:
                    path = MariaDB_exe;
                    break;
                case typeProg.apache:
                    path = Apache_exe;
                    break;
                case typeProg.editor:
                    path = default_editor_path;
                    break;
            }
            return path;
        }


        #region private
        private string refresh_wpcli_vers()
        {
            string sout = "";
            Regex regex;
            Match match;
            string fullpath_wpcli = System.IO.Path.Combine(App_Path, pathWPcli);
            if (!string.IsNullOrEmpty(pathWPcli) && System.IO.Directory.Exists(fullpath_wpcli))
            {
                string temp = ZampGUILib.startProc_and_wait_output(PHP_exe, " wp-cli.phar --info", true, fullpath_wpcli);
                regex = new Regex(@"WP-CLI version:.\d+\.\d+\.\d+");
                match = regex.Match(temp);
                if (match.Success)
                {
                    sout = match.Value.Replace("WP-CLI version:", "").Trim();
                }
            }
            return sout;
        }
        private string refresh_sass_vers()
        {
            string sout = "";
            Regex regex;
            Match match;
            string fullpath_sass = System.IO.Path.Combine(App_Path, pathSass);
            if (!string.IsNullOrEmpty(pathSass) && System.IO.Directory.Exists(fullpath_sass))
            {
                string temp = ZampGUILib.startProc_and_wait_output(System.IO.Path.Combine(fullpath_sass, "sass.bat"), "--version", true, fullpath_sass);
                //regex = new Regex(@"Composer version \d+\.\d+\.\d+");
                //match = regex.Match(temp);
                //if (match.Success)
                //{
                //    sout = match.Value;
                //}
                sout = temp.Trim();
            }
            return sout;
        }
        private string refresh_node_vers()
        {
            string sout = "";
            Regex regex;
            Match match;
            string fullpath_node = System.IO.Path.Combine(App_Path, pathNode);
            if (!string.IsNullOrEmpty(pathNode) && System.IO.Directory.Exists(fullpath_node))
            {
                string temp = ZampGUILib.startProc_and_wait_output(System.IO.Path.Combine(fullpath_node, "node.exe"), "--version", true, fullpath_node);
                regex = new Regex(@"\d+\.\d+\.\d+");
                match = regex.Match(temp);
                if (match.Success)
                {
                    sout = match.Value;
                }
            }
            return sout;
        }
        private string refresh_git_vers()
        {
            string sout = "";
            Regex regex;
            Match match;

            string fullpath_git = System.IO.Path.Combine(App_Path, pathGit);
            if (!string.IsNullOrEmpty(pathGit) && System.IO.Directory.Exists(fullpath_git))
            {
                string temp = ZampGUILib.startProc_and_wait_output(System.IO.Path.Combine(fullpath_git, "bin", "git.exe"), "--version", true, fullpath_git);
                //str = str.Replace("git version ", "").Trim();
                regex = new Regex(@"\d+\.\d+\.\d+");
                match = regex.Match(temp);
                if (match.Success)
                {
                    sout = match.Value;
                }
            }

            return sout;
        }


        private string refresh_apache_vers()
        {
            Regex regex;
            Match match;

            string vers = ZampGUILib.startProc_and_wait_output(Apache_exe, "-v", true);
            regex = new Regex(@"Apache.\d+\.\d+\.\d+");
            match = regex.Match(vers);
            if (match.Success)
            {
                vers = match.Value.Replace("Apache/", "");
            }
            return vers;
        }
        private string refresh_php_vers()
        {
            Regex regex;
            Match match;

            string vers = ZampGUILib.startProc_and_wait_output(PHP_exe, "-v", true);
            regex = new Regex(@"PHP \d+\.\d+.\d+");
            match = regex.Match(vers);
            if (match.Success)
            {
                vers = match.Value.Replace("PHP ", "");
            }
            return vers;
        }
        private string refresh_mariadb_vers()
        {
            Regex regex;
            Match match;

            string vers = ZampGUILib.startProc_and_wait_output(MariaDB_exe, "--version", true);
            regex = new Regex(@"Ver \d+\.\d+\.\d+");
            match = regex.Match(vers);
            if (match.Success)
            {
                vers = match.Value.Replace("Ver", "").Trim();
            }
            return vers;
        }
        private string refresh_composer_vers()
        {
            Regex regex;
            Match match;

            string vers = ZampGUILib.startProc_and_wait_output(Composer_exe, "--version", true, PHP_path);
            regex = new Regex(@"Composer version \d+\.\d+\.\d+");
            match = regex.Match(vers);
            if (match.Success)
            {
                vers = match.Value.Replace("Composer version", "").Trim();
            }
            return vers;
        }

        private string addPath(string[] _base, string _path)
        {
            if(System.IO.Path.IsPathRooted(_path) && System.IO.Directory.Exists(_path))
            {
                return _path;
            }
            else 
            {
                string combine = _base[0];
                for (int k = 1; k < _base.Length; k++)
                {
                    combine = System.IO.Path.Combine(combine, _base[k]);
                }

                return System.IO.Path.Combine(combine, _path);
            }
        }
        #endregion
    }
}

