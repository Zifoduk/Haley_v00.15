using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Haley
{
    public partial class Start : Form
    {
        Configuration Config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
        string MLoc;
         
        public Start()
        {
            InitializeComponent();
            MLoc = Config.AppSettings.Settings["Mlocation"].Value;
            Dis_MusicLocation.Text = MLoc;
        }

        private void Btn_launch_Click(object sender, EventArgs e)
        {
            Application.Run(new Haley_Sight());
        }

        public void TrigEnd()
        {
            Application.Exit();
        }

        private void Btn_CML_Click(object sender, EventArgs e)
        {
            if(MusicLocation.ShowDialog() == DialogResult.OK)
            {
                Config.AppSettings.Settings["Mlocation"].Value = MusicLocation.SelectedPath.ToString();
                MLoc = Config.AppSettings.Settings["Mlocation"].Value;
                Dis_MusicLocation.Text = MLoc;
            }
        }
    }
}
