
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Configuration;
using System.Collections;


namespace LaunchMateTray
{
    public partial class LaunchMateTrayContext: ApplicationContext
    {
        private readonly NotifyIcon trayIcon;
        private readonly System.ComponentModel.IContainer components;
        private readonly LaunchMateTrayContextMenuStrip menu;
        private readonly LaunchMateTraySettings settings;
        private MenuList menuList;
        public LaunchMateTrayContext()
        {
            this.components = new System.ComponentModel.Container();
            this.menu = new LaunchMateTrayContextMenuStrip();
            /*this.menu.BackColor = Color.Black;
            this.menu.ForeColor = Color.White;*/
            //this.menu.ShowCheckMargin = false;
            this.trayIcon = new NotifyIcon(this.components);
            this.settings = new LaunchMateTraySettings();
            this.menuList = new MenuList();
            this.settings.ReadSettings();
            this.menuList.ImportSettings(this.settings.Settings.Apps);
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
            if (dlg.ShowDialog() == DialogResult.OK)
            {
            }
        }

        public void AppHandler(object? sender, EventArgs e)
        {
            //Process.Start("D:\\tools\\VLC\\vlc.exe");
            var item = sender as ToolStripMenuItem;
            var id = item?.Name;
            var menuItem = this.menuList.FindMenuItem(id);
            if (menuItem != null)
            {
                Process.Start(menuItem.Path);
            }
        }

        private void AddMenuGroup(MenuListItem item, ToolStripItemCollection menuItems)
        {
            var dropdown = new ToolStripMenuItem(item.Name, SystemIcons.GetStockIcon(StockIconId.Folder, 16).ToBitmap(), null, item.Name);
            var children = item.GetChildren();
            if (children != null)
            {
                foreach (var child in children) 
                {
                    switch (child.Type)
                    {
                        case menuItemType.Group:
                            this.AddMenuGroup(child, dropdown.DropDownItems);
                            break;

                        case menuItemType.Application:
                            this.AddMenuApp(child, dropdown.DropDownItems);
                            break;
                    }
                }
            }
            
            menuItems.Add(dropdown);
        }

       private void AddMenuApp(MenuListItem item, ToolStripItemCollection menuItems)
       {
           var stripItem = new ToolStripMenuItem(item.Name, Icon.ExtractAssociatedIcon(item.Path)?.ToBitmap(), AppHandler, item.Name);
           stripItem.Name = item.Id;
           menuItems.Add(stripItem);
       }

       private void AddApps2Menu()
       {
           List<MenuListItem>? children = this.menuList.GetRootChildren();
           if (children != null)
           {
               foreach(MenuListItem child in children)
               {
                   switch (child.Type)
                   {
                       case menuItemType.Group:
                           this.AddMenuGroup(child, this.menu.Items);
                           break;

                       case menuItemType.Application:
                           this.AddMenuApp(child, this.menu.Items);
                           break;
                   }
               }
           }
       }

       private void SetupMenu()
       {
           /*var dropdown = new ToolStripMenuItem("Dev", SystemIcons.GetStockIcon(StockIconId.Folder, 16).ToBitmap(), null, "Dev");

           var item = new ToolStripMenuItem("Visual Code", Icon.ExtractAssociatedIcon(@"E:\\tools\\vscode\\Code.exe")?.ToBitmap(), AppHandler, "Visual Code");
           item.Name = Guid.NewGuid().ToString();
           dropdown.DropDownItems.Add(item);*/
            this.menu.Items.Clear();
            this.AddApps2Menu();

            var item = new ToolStripMenuItem("&Settings...", null, SettingsHandler, "Settings");
            this.menu.Items.Add(item);
            
            this.menu.Items.Add(new ToolStripSeparator());
            item = new ToolStripMenuItem("&About", null, AboutHandler, "About");
            this.menu.Items.Add(item);
            this.menu.Items.Add(new ToolStripSeparator());
            item = new ToolStripMenuItem("E&xit", null, ExitHandler, "Exit");
            this.menu.Items.Add(item);

        }
    }
}
