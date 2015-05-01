using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace imgruber
{
    public partial class Config : Form
    {

        public Config()
        {
            InitializeComponent();
        }

        public void LoadConfigurations()
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Imgruber\Config", true);

            if (key == null)
            {
                key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Imgruber\Config");
            }

            useCtrlBOX.Checked = bool.Parse((string) key.GetValue("hotkeyCTRL", false));
            useAltBOX.Checked = bool.Parse((string) key.GetValue("hotkeyALT", false));
            HotkeyCOMBO.SelectedIndex = (int) key.GetValue("hotkeyIndex", 0);
            LinkCodeCOMBO.SelectedIndex = (int) key.GetValue("linkCodeIndex", 0);
            TweetThisCB.Checked = bool.Parse((string) key.GetValue("autoTweet", false));
            TweetPrependTB.Text = (string) key.GetValue("prependText", "");
        }

        private void SaveConfigurations()
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Imgruber\Config", true);

            key.SetValue("hotkeyCTRL", useCtrlBOX.Checked);
            key.SetValue("hotkeyALT", useAltBOX.Checked);
            key.SetValue("hotkeyIndex", HotkeyCOMBO.SelectedIndex);
            key.SetValue("linkCodeIndex", LinkCodeCOMBO.SelectedIndex);
            key.SetValue("autoTweet", TweetThisCB.Checked);
            key.SetValue("prependText", TweetPrependTB.Text);
        }

        private void DoneBTN_Click(object sender, EventArgs e)
        {
            SaveConfigurations();
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

        private void TweetPrependTB_TextChanged(object sender, EventArgs e)
        {
            CharCount.Text = TweetPrependTB.Text.Length + "/110";
            if (TweetPrependTB.Text.Length > 110)
            {
                CharCount.ForeColor = Color.DarkRed;
            }
            else
            {
                CharCount.ForeColor = Color.Black;
            }
        }
    }
}