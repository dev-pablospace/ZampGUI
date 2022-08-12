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
    public partial class FormManageSites : Form
    {
        public ConfigVar cv;
        public FormManageSites(ConfigVar cv)
        {
            this.cv = cv;
            InitializeComponent();
            //listViewManageSites.View = View.Details;
            //ListViewItem item1 = new ListViewItem("Something");
            //item1.SubItems.Add("SubItem1a");
            //item1.SubItems.Add("SubItem1b");
            //item1.SubItems.Add("SubItem1c");

            //ListViewItem item2 = new ListViewItem("Something2");
            //item2.SubItems.Add("SubItem2a");
            //item2.SubItems.Add("SubItem2b");
            //item2.SubItems.Add("SubItem2c");

            //ListViewItem item3 = new ListViewItem("Something3");
            //item3.SubItems.Add("SubItem3a");
            //item3.SubItems.Add("SubItem3b");
            //item3.SubItems.Add("SubItem3c");

            //listViewManageSites.Items.AddRange(new ListViewItem[] { item1, item2, item3 });

            string[] saLvwItem = new string[3];
            saLvwItem[0] = "Status Message";
            saLvwItem[1] = "ciaociao";
            saLvwItem[2] = DateTime.Now.ToString("dddd dd/MM/yyyy - HH:mm:ss");

            ListViewItem lvi = new ListViewItem(saLvwItem);

            listViewManageSites.Items.Add(lvi);
            //listViewManageSites.Items.Add("Column1Text").SubItems.AddRange(row1);
        }
    }
}
