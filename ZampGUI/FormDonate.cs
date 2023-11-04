using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZampLib;

namespace ZampGUI
{
    public partial class FormDonate : Form
    {
        public string indirizzo_eth { get; set; }
        public string indirizzo_bit { get; set; }
        public string HOME { get; set; }

        public FormDonate(string indirizzo_eth, string indirizzo_bit)
        {
            InitializeComponent();
            this.indirizzo_eth = indirizzo_eth;
            this.indirizzo_bit = indirizzo_bit;

            txtBitcoin.Text = string.IsNullOrEmpty(indirizzo_bit)? "--": indirizzo_bit;
            txtEthereum.Text = string.IsNullOrEmpty(indirizzo_eth) ? "--" : indirizzo_eth;

            this.pictureQRBitcoin.ImageLocation = this.HOME + "/img/BIT.png";
            this.pictureQReth.ImageLocation = this.HOME + "/img/ETH.png";

            this.label1.Focus();
        }

        private void labelBitcoin_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtBitcoin.Text.Trim());
            txtBitcoin.Focus();
            txtBitcoin.SelectAll();
        }

        private void labelEth_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtEthereum.Text.Trim());
            txtEthereum.Focus();
            txtEthereum.SelectAll();
        }

        private void FormDonate_Load(object sender, EventArgs e)
        {

        }
    }
}
