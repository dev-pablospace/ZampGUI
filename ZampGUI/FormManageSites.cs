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
            if (sites == null || sites.Count() == 0)
            {
                lista.Add(new RigaSite() { Url = "", Name = "" });
            }
            else
            {
                foreach (Newtonsoft.Json.Linq.JProperty kv in sites)
                {
                    lista.Add(new RigaSite() { Name = kv.Name, Url = kv.Value.ToString() });
                }
            }

            dataGridView1.DataSource = lista;
            
        }

        private void buttonDeleteRow_Click(object sender, EventArgs e)
        {
            
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {
                    var item = dataGridView1.SelectedRows[i];
                    RigaSite r = (RigaSite)item.DataBoundItem;
                    lista.Remove(r);
                }
            }
            else
            {
                IEnumerable<DataGridViewRow> selectedRows = dataGridView1.SelectedCells.Cast<DataGridViewCell>()
                                           .Select(cell => cell.OwningRow)
                                           .Distinct();
                if(selectedRows.Count() > 0)
                {
                    foreach (DataGridViewRow item in selectedRows)
                    {
                        RigaSite r = (RigaSite)item.DataBoundItem;
                        lista.Remove(r);
                    }
                }
            }

            if(lista.Count() == 0)
            {
                lista.Add(new RigaSite() { Url = "", Name = "" });
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;

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
                if(!string.IsNullOrEmpty(item.Name) && !string.IsNullOrEmpty(item.Url))
                {
                    arr.Add(new JProperty(item.Name, item.Url));
                }
            }

            cv.json = cv.json ?? ZampGUILib.getJson_Env();
            cv.json[cv._env]["sites"] = new JObject(arr);
            ZampGUILib.setJson_Env(cv.json);
            this.Close();
        }
    }

    
}
