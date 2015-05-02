using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Input;
using GlobalHotKey;
using imgruber.Properties;

namespace imgruber
{
    public class TaskTrayApplicationContext : ApplicationContext
    {
        public static HotKeyManager hkm;
        public Config configWindow;
        public NotifyIcon notifyIcon = new NotifyIcon();

        public TaskTrayApplicationContext()
        {
            configWindow = new Config();
            configWindow.LoadConfigurations();
            var configMenuItem = new MenuItem("Configuration", ShowConfig);
            var exitMenuItem = new MenuItem("Exit", Exit);

            notifyIcon.Icon = Resources.imgruber;
            notifyIcon.DoubleClick += TakeScreenshot;
            notifyIcon.ContextMenu = new ContextMenu(new[] {configMenuItem, exitMenuItem});
            notifyIcon.Visible = true;

            hkm = new HotKeyManager();


            RegisterHotKey(configWindow);         

            hkm.KeyPressed += TakeScreenshot;
        }

        public static void RegisterHotKey(Config config)
        {
            ModifierKeys mod;

            if (config.useCtrlBOX.Checked && config.useAltBOX.Checked)
            {
                mod = (ModifierKeys.Control | ModifierKeys.Alt);
            }
            else if (config.useCtrlBOX.Checked && !config.useAltBOX.Checked)
            {
                mod = ModifierKeys.Control;
            }
            else if (config.useAltBOX.Checked && !config.useCtrlBOX.Checked)
            {
                mod = ModifierKeys.Alt;
            }
            else
            {
                mod = ModifierKeys.None;
            }

            Key hotkey = Key.PrintScreen;

            switch (config.HotkeyCOMBO.SelectedIndex)
            {
                case 0: //print screen
                    break;
                case 1: //scroll lock
                    hotkey = Key.Scroll;
                    break;
                case 2: //pause break
                    hotkey = Key.Pause;
                    break;
            }

            try
            {
                hkm.Register(hotkey, mod);
            }
            catch (Exception)
            {
                hkm.Unregister(hotkey, mod);
                hkm.Register(hotkey, mod);
            }
        }

        private void TakeScreenshot(object sender, EventArgs e)
        {
            var sshot = new Screenshot();
            var link = sshot.Take(sender, e, this);
            configWindow.urlTB.Text = link;
        }

        private void ShowConfig(object sender, EventArgs e)
        {
            if (configWindow.Visible)
                configWindow.Focus();
            else
                configWindow.ShowDialog();
        }

        private void Exit(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
            hkm.Unregister(Key.PrintScreen, ModifierKeys.None);
            hkm.Dispose();
            Application.Exit();
        }
    }
}