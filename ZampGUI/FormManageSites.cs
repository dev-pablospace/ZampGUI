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
using ZampLib.Business;

namespace ZampGUI
{
    public partial class FormManageSites : Form
    {
        public ConfigVar cv;
        public List<RigaSite> lista;
        public FormManageSites(ConfigVar cv)
        {
            this.cv = cv;
            lista = new List<RigaSite>();
            InitializeComponent();
            

            JObject jobj = ZampGUILib.getJson_Env();
            JToken sites = jobj[cv._env]["sites"];
            if (sites == null)
            {
                lista.Add(new RigaSite());
            }
            else
            {
                foreach (Newtonsoft.Json.Linq.JProperty kv in sites)
                {
                    lista.Add(new RigaSite() { Name = kv.Name, Url = kv.Value.ToString() });
                }
            }

            dataGridView1.DataSource = lista;
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

            //listViewManageSites.Items.AddRange(new ListViewItem[] { item1});

            //string[] saLvwItem = new string[3];
            //saLvwItem[0] = "Status Message";
            //saLvwItem[1] = "ciaociao";
            //saLvwItem[2] = DateTime.Now.ToString("dddd dd/MM/yyyy - HH:mm:ss");

            //ListViewItem lvi = new ListViewItem(saLvwItem);

            //listViewManageSites.Items.Add(lvi);
            //listViewManageSites.Items.Add("Column1Text").SubItems.AddRange(row1);
        }

        private void buttonDeleteRow_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                RigaSite r = (RigaSite)item.DataBoundItem;
                lista.Remove(r);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = lista;
                //dataGridView1.Rows.RemoveAt(item.Index);
            }
        }

        private void buttonNewRow_Click(object sender, EventArgs e)
        {
            RigaSite r = new RigaSite() { Url = "", Name = "" };
            lista.Add(r);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            List<JProperty> arr = new List<JProperty>();
            foreach(var item in lista)
            {
                arr.Add(new JProperty(item.Name, item.Url));
            }

            JObject jobj = ZampGUILib.getJson_Env();
            jobj[cv._env]["sites"] = new JObject(arr);
            ZampGUILib.setJson_Env(jobj);
            this.Close();
        }
    }

    
}
