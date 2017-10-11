﻿using System;
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
            List<string> list = new List<string>();
            list.Add(ComputerConfiguationReader.GetCpuName());
            list.Add(ComputerConfiguationReader.GetBaseboard());
            list.Add(ComputerConfiguationReader.GetBiosVersion());
            list.Add(ComputerConfiguationReader.GetDisplayName());
            list.AddRange(ComputerConfiguationReader.GetMemoryInfo());

            string s = String.Join("|", list.ToArray());
            Protocol p = new Protocol(File.ReadAllText("ip.txt"), 8888);
            p.Send(s);
            Dispose();
        }
    }
}
