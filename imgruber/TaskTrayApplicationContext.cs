using System;
using System.Windows.Forms;
using System.Windows.Input;
using GlobalHotKey;
using imgruber.Properties;

namespace imgruber
{
    public class TaskTrayApplicationContext : ApplicationContext
    {
        private readonly HotKeyManager _hkm;
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

            _hkm = new HotKeyManager();

            //TODO: add hotkey changing
            try
            {
                _hkm.Register(Key.PrintScreen, ModifierKeys.None);
            }
            catch (Exception)
            {
                _hkm.Unregister(Key.PrintScreen, ModifierKeys.None);
                _hkm.Register(Key.PrintScreen, ModifierKeys.None);
            }
            


            _hkm.KeyPressed += TakeScreenshot;
        }

        private void TakeScreenshot(object sender, EventArgs e)
        {
            var sshot = new Screenshot();
            configWindow.urlTB.Text = sshot.Take(sender, e, this);
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
            _hkm.Unregister(Key.PrintScreen, ModifierKeys.None);
            _hkm.Dispose();
            Application.Exit();
        }
    }
}