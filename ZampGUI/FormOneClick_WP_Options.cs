using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZampLib.Business;

namespace ZampGUI
{
    public partial class FormOneClick_WP_Options : Form
    {
        public ConfigVar cv;
        #region var che rileggo quando chiudo il form
        public string ButtonPressed = "";
        #endregion


        public FormOneClick_WP_Options(ConfigVar cv)
        {
            InitializeComponent();
            this.cv = cv;

            txtNumPost.Value = cv.wpop.txtNumPost;
            txtSiteName.Text = cv.wpop.txtSiteName;
            txtDescription.Text = cv.wpop.txtDescription;
            checkOverwriteWebSite.Checked = cv.wpop.checkOverwriteWebSite;
            checkDisableAutoUpdate.Checked = cv.wpop.checkDisableAutoUpdate;
            checkEnableWPPostRevision.Checked = cv.wpop.checkEnableWPPostRevision;
            txtNumericPostRevision.Value = cv.wpop.txtNumericPostRevision;
            checkRemoveDefaultPlugin.Checked = cv.wpop.checkRemoveDefaultPlugin;
            checkRemoveDefaultTheme.Checked = cv.wpop.checkRemoveDefaultTheme;
            txtPluginList.Text = cv.wpop.txtPluginList;
            txtThemeList.Text = cv.wpop.txtThemeList;
        }

        private void checkEnableWPPostRevision_CheckedChanged(object sender, EventArgs e)
        {
            if(checkEnableWPPostRevision.Checked)
            {
                txtNumericPostRevision.Enabled = true;
            }
            else
            {
                txtNumericPostRevision.Enabled = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ButtonPressed = ((System.Windows.Forms.Button)sender).Text;
            closeForm();
        }



        #region private 
        public void closeForm()
        {
            if(ButtonPressed == "OK")
            {
                cv.wpop.txtNumPost = Convert.ToInt32(txtNumPost.Value);
                cv.wpop.txtSiteName = txtSiteName.Text.Trim();
                cv.wpop.txtDescription = txtDescription.Text.Trim();
                cv.wpop.checkOverwriteWebSite = checkOverwriteWebSite.Checked;
                cv.wpop.checkDisableAutoUpdate = checkDisableAutoUpdate.Checked;
                cv.wpop.checkEnableWPPostRevision = checkEnableWPPostRevision.Checked;
                cv.wpop.txtNumericPostRevision = Convert.ToInt32(txtNumericPostRevision.Value);
                cv.wpop.checkRemoveDefaultPlugin = checkRemoveDefaultPlugin.Checked;
                cv.wpop.checkRemoveDefaultTheme = checkRemoveDefaultTheme.Checked;
                cv.wpop.txtPluginList = txtPluginList.Text.Trim();
                cv.wpop.txtThemeList = txtThemeList.Text.Trim();
            }
            this.Close();
        }
        #endregion

        
    }
}
