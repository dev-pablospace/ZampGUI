using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZampLib.Business
{
    public class WP_Options
    {
        //main options
        public string txt_nomesito = "";
        public string txt_User = "";
        public string txt_Pwd = "";
        public string txt_Email = "";
        public string txt_DisplayName = "";
        public string comboBoxLang = "";
        public string comboBoxWPVersion = "";


        //other options
        public int txtNumPost = 0;
        public string txtSiteName = "";
        public string txtDescription = "";
        public bool checkOverwriteWebSite = false;
        public bool checkDisableAutoUpdate = false;
        public bool checkEnableWPPostRevision = false;
        public int txtNumericPostRevision = 1;
        public bool checkRemoveDefaultPlugin = false;
        public bool checkRemoveDefaultTheme = false;
        public string txtPluginList = "";
        public string txtThemeList = "";

        //hidden options
        public string timezone_string = "";
        public string time_format = "";
        public string rss_use_excerpt = "";
        public string uploads_use_yearmonth_folders = "";
        public string permalink_string = "";
    }
}
