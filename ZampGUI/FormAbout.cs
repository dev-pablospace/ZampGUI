using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZampGUI
{
    public partial class FormAbout : Form
    {
        public string HOME { get; set; }

        public FormAbout()
        {
            InitializeComponent();
            this.HOME = ZampLib.ZampGUILib.getval_from_appsetting("HOME");
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(HOME);
        }

        private void pictureBoxHome_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(HOME);
        }

        private void pictureBoxEmail_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start(HOME + "/contactme.php");
        }

        private void pictureBoxGithub_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/pablodevsite?tab=repositories");
        }

        private void pictureBoxSourceforge_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://sourceforge.net/projects/zampgui/");
        }
    }
}
