using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Protocol p = new Protocol();
            p.Start((ip, msg) =>
            {
                var list = new List<string>(msg.Split('|'));
                list.Insert(0, ip);
                ListView_config_Add(list);
            });
        }

        private void ListView_config_Add(List<string> list)
        {
            int count = listView_config.Items.Count;
            ListViewItem item = new ListViewItem();
            item.SubItems[0].Text = (count + 1).ToString();
            foreach (var s in list)
            {
                item.SubItems.Add(s);
            }
            this.Invoke(new Action(() =>
            {
                listView_config.Items.Add(item);
            }));
        }

        private void btn_saveAsExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "xlsx|*.xlsx";
            sfd.DefaultExt = "xlsx";
            if ( sfd.ShowDialog() != DialogResult.OK)
                return;
            ToExcel.ListView2Excel(listView_config, sfd.FileName);
        }
    }
}
