using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace imgruber
{
    public partial class Config : Form
    {
        private TaskTrayApplicationContext context;

        public Config(TaskTrayApplicationContext ttac)
        {
            InitializeComponent();
            context = ttac;
        }

        public void LoadConfigurations()
        {
            var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Imgruber\Config", true);

            if (key == null)
            {
                key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Imgruber\Config");
            }

            this.useCtrlBOX.Checked = bool.Parse((string) key.GetValue("hotkeyCTRL", false));
            this.useAltBOX.Checked = bool.Parse((string) key.GetValue("hotkeyALT", false));
            this.HotkeyCOMBO.SelectedIndex = (int) key.GetValue("hotkeyIndex", 0);
            this.LinkCodeCOMBO.SelectedIndex = (int) key.GetValue("linkCodeIndex", 0);
            this.TweetThisCB.Checked = bool.Parse((string) key.GetValue("autoTweet", false));
            this.TweetPrependTB.Text = (string) key.GetValue("prependText", "");

        }

        void saveConfigurations()
        {
            var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Imgruber\Config", true);

            key.SetValue("hotkeyCTRL", this.useCtrlBOX.Checked);
            key.SetValue("hotkeyALT", this.useAltBOX.Checked);
            key.SetValue("hotkeyIndex", this.HotkeyCOMBO.SelectedIndex);
            key.SetValue("linkCodeIndex", this.LinkCodeCOMBO.SelectedIndex);
            key.SetValue("autoTweet", this.TweetThisCB.Checked);
            key.SetValue("prependText", this.TweetPrependTB.Text);
        }
        
        private void DoneBTN_Click(object sender, EventArgs e)
        {
            saveConfigurations();
            Close();
        }

        private void HelpLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://jarena3.github.io/imgruber/");
        }

        private void SourceLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/jarena3/imgruber");
        }

    }
}
