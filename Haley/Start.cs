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
using System.Speech.Synthesis;

namespace Haley
{
    public partial class Start : Form
    {
        Configuration Config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
        string MLoc;
        private SpeechSynthesizer VSynth = new SpeechSynthesizer();

        public Start()
        {
            InitializeComponent();
            foreach(InstalledVoice IV in VSynth.GetInstalledVoices())
            {
                VoiceInfo VI = IV.VoiceInfo;
                CBox_VSct.Items.Add(VI.Name);
            }
            CBox_VSct.SelectedItem = Config.AppSettings.Settings["VoiceSelected"].Value;          
            MLoc = Config.AppSettings.Settings["Mlocation"].Value;
            Dis_MusicLocation.Text = MLoc;
        }

        private void Btn_launch_Click(object sender, EventArgs e)
        {
            Haley_Sight haley_Sight = new Haley_Sight();
            haley_Sight.Show();
            this.Hide();
        }

        private void Btn_CML_Click(object sender, EventArgs e)
        {
            if(MusicLocation.ShowDialog() == DialogResult.OK)
            {
                Config.AppSettings.Settings["Mlocation"].Value = MusicLocation.SelectedPath.ToString();
                MLoc = Config.AppSettings.Settings["Mlocation"].Value;
                Config.Save(ConfigurationSaveMode.Modified);
                Dis_MusicLocation.Text = MLoc;
            }
        }

        private void CBox_VSct_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(CBox_VSct.SelectedItem.ToString());
            Config.AppSettings.Settings["VoiceSelected"].Value = CBox_VSct.SelectedItem.ToString();
            Config.Save(ConfigurationSaveMode.Modified);
        }
    }
}
