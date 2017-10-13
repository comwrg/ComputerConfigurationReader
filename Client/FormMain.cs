using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                Protocol p = new Protocol(File.ReadAllText("ip.txt"), 8888);
                List<string> list = new List<string>();
                list.Add(ComputerConfiguationReader.GetCpuName());
                list.Add(ComputerConfiguationReader.GetBaseboard());
                list.Add(ComputerConfiguationReader.GetBiosVersion());
                var displayNameList = ComputerConfiguationReader.GetVideoName();
                list.AddRange(Format(displayNameList));
                var memoryInfoList = ComputerConfiguationReader.GetMemoryInfo();
                list.AddRange(Format(memoryInfoList));
                string s = String.Join("|", list.ToArray());
                p.Send(s);
            }
            catch (Exception)
            {
            }
            finally
            {
                Dispose();
            }

        }

        private List<string> Format(List<string> list)
        {
            while (list.Count < 2)
            {
                list.Add("");
            }
            return list;
        }
    }
}
