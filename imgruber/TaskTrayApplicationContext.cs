using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;
using GlobalHotKey;

namespace imgruber
{
    public class TaskTrayApplicationContext : ApplicationContext
    {
        public NotifyIcon notifyIcon = new NotifyIcon();
        public Config configWindow;
        private HotKeyManager _hkm;

        public TaskTrayApplicationContext()
        {
            configWindow = new Config(this);
            configWindow.LoadConfigurations();
            MenuItem configMenuItem = new MenuItem("Configuration", new EventHandler(ShowConfig));
            MenuItem exitMenuItem = new MenuItem("Exit", new EventHandler(Exit));

            notifyIcon.Icon = Properties.Resources.imgrub_ico;
            notifyIcon.DoubleClick += new EventHandler(TakeScreenshot);
            notifyIcon.ContextMenu = new ContextMenu(new MenuItem[] { configMenuItem, exitMenuItem });
            notifyIcon.Visible = true;

            _hkm = new HotKeyManager();

            //TODO: add hotkey changing
            _hkm.Register(Key.PrintScreen, ModifierKeys.None);

            _hkm.KeyPressed += TakeScreenshot;


        }

        void TakeScreenshot(object sender, EventArgs e)
        {
            var sshot = new Screenshot();
            configWindow.urlTB.Text = sshot.Take(sender, e, this);
        }

        void ShowConfig(object sender, EventArgs e)
        {
            if (configWindow.Visible)
                configWindow.Focus();
            else
                configWindow.ShowDialog();
        }

        void Exit(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
            _hkm.Unregister(Key.PrintScreen, ModifierKeys.None);
            _hkm.Dispose();
            Application.Exit();
        }
    }
}