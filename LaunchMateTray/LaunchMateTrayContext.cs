
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Configuration;

namespace LaunchMateTray
{
    public partial class LaunchMateTrayContext: ApplicationContext
    {
        private readonly NotifyIcon trayIcon;
        private readonly System.ComponentModel.IContainer components;
        private readonly System.Windows.Forms.ContextMenuStrip menu;
        public LaunchMateTrayContext()
        {
            this.components = new System.ComponentModel.Container();
            this.menu = new ContextMenuStrip();
            //this.menu.BackColor = Color.FromArgb(0,0,0);
            //this.menu.ForeColor = Color.FromArgb(255, 255, 255);
            this.trayIcon = new NotifyIcon(this.components);
            this.SetupMenu();
            this.trayIcon.Icon = new Icon(new System.IO.MemoryStream(Properties.Resources.LaunchMateTrayIcon));
            this.trayIcon.Visible = true;
            this.trayIcon.ContextMenuStrip = this.menu;
        }

        public void ExitHandler(object? sender, EventArgs e)
        {
            Application.Exit();
        }

        public void AboutHandler(object? sender, EventArgs e)
        {
            var dlg = new AboutLaunchMateTray();
            dlg.ShowDialog();
        }

        public void SettingsHandler(object? sender, EventArgs e)
        {
            var dlg = new SettingsDlg();
            dlg.ShowDialog();
        }

        public void AppHandler(object? sender, EventArgs e)
        {
            Process.Start("D:\\tools\\VLC\\vlc.exe");
        }

        private void SetupMenu()
        {
            this.menu.Items.Add(new ToolStripMenuItem("VLC", Icon.ExtractAssociatedIcon(@"D:\\tools\\VLC\\vlc.exe")?.ToBitmap(), AppHandler, "VLC"));
            this.menu.Items.Add(new ToolStripMenuItem("&Settings...", null, SettingsHandler, "Settings"));
            this.menu.Items.Add("-");
            this.menu.Items.Add(new ToolStripMenuItem("&About", null, AboutHandler, "About"));
            this.menu.Items.Add("-");
            this.menu.Items.Add(new ToolStripMenuItem("E&xit", null, ExitHandler, "Exit"));
        }

        private void ReadSettings()
        {
            var appSettings = ConfigurationManager.AppSettings;
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
