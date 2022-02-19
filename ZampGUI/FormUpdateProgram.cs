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
    public partial class FormUpdateProgram : Form
    {
        public string latest_vers;
        public FormUpdateProgram(string latest_vers)
        {
            InitializeComponent();
            this.latest_vers = latest_vers;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(this.latest_vers);
        }
    }
}
