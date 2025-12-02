
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Configuration;
using System.Collections;
using Microsoft.VisualBasic.Devices;

namespace LaunchMateTray
{
    public enum ProcessActionType { RunAsAdmin = 0, Minimized = 1, Maximized = 2 };

    public partial class LaunchMateTrayContext: ApplicationContext
    {
        private readonly NotifyIcon trayIcon;
        private readonly System.ComponentModel.IContainer components;
        private LaunchMateTrayContextMenuStrip menu;
        private readonly LaunchMateTraySettings settings;
        private MenuList menuList;

        public LaunchMateTrayContext()
        {
            components = new System.ComponentModel.Container();
            settings = new LaunchMateTraySettings();
            settings.ReadSettings();

            ColorSettings colors = settings.Settings?.Appearance == null ? LaunchMateTraySettings.defaultColors : settings.Settings.Appearance;
            menu = new LaunchMateTrayContextMenuStrip(colors);
            /*menu.BackColor = Color.Black;
            menu.ForeColor = Color.White;*/
            //menu.ShowCheckMargin = false;
            trayIcon = new NotifyIcon(components);
            menuList = new MenuList();
            menuList.ImportSettings(settings.Settings?.Apps);
            SetupMenu();
            trayIcon.Icon = new Icon(new System.IO.MemoryStream(Properties.Resources.LaunchMateTrayIcon));
            trayIcon.Visible = true;
            trayIcon.ContextMenuStrip = menu;
      
        }

        public void ExitHandler(object? sender, EventArgs e)
        {
            Application.Exit();
        }

        public void AboutHandler(object? sender, EventArgs e)
        {
            var dlg = new AboutLaunchMateTray();
            dlg.ShowDialog(menu);
        }

        public void SettingsHandler(object? sender, EventArgs e)
        {
            var dlg = new SettingsDlg();
  
            dlg.SetMenuList((MenuList)menuList.Clone());
            ColorSettings colors = settings.Settings.Appearance ?? LaunchMateTraySettings.defaultColors;
            dlg.SetColorSettings(colors);
            dlg.SetKeySettings(settings.Settings.Keys);

            if (dlg.ShowDialog(menu) == DialogResult.OK)
            {
                var dlgMenuList = dlg.GetMenuList();
                if (dlgMenuList != null)
                {
                    menuList = (MenuList)dlgMenuList.Clone();
                    settings.Settings.Appearance = dlg.GetColorSettings();
                    settings.Settings.Keys = dlg.GetKeySettings();
                    settings.WriteSettings();
                    menuList.UpdateSettings();
                    menu.SetColorSettings(settings.Settings.Appearance);
                    SetupMenu();
                }
            }
        }

        private ProcessStartInfo FillProcessAction(ProcessActionType type, ProcessStartInfo info)
        {
            switch (type)
            {
                case ProcessActionType.RunAsAdmin:
                    info.Verb = "runas";
                    info.UseShellExecute = true;
                    Debug.WriteLine("ProcessActionType.RunAsAdmin");
                    break;
                case ProcessActionType.Minimized:
                    info.WindowStyle = ProcessWindowStyle.Minimized;
                    info.UseShellExecute = false;
                    Debug.WriteLine("ProcessActionType.Minimized");
                    break;
                case ProcessActionType.Maximized:
                    info.WindowStyle =  ProcessWindowStyle.Maximized;
                    info.UseShellExecute = false;
                    Debug.WriteLine("ProcessActionType.Maximized");
                    break;
            }

            return info;
        }

        public void AppHandler(object? sender, EventArgs e)
        {
            ToolStripMenuItem? item = sender as ToolStripMenuItem;
            if (item != null)
            {
                var id = item.Name;
                var menuItem = menuList.FindMenuItem(id ?? "");
                if (menuItem != null)
                {
                    ProcessStartInfo psInfo = new ProcessStartInfo();
                    psInfo.FileName = menuItem.Path;
                    if (menuItem.Arguments != null) { psInfo.Arguments = menuItem.Arguments; }
                    if (Control.ModifierKeys == Keys.Control)
                    {
                        psInfo = FillProcessAction((ProcessActionType)settings.Settings.Keys["ctrl"],psInfo);
                    }
                    else if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                    {
                        psInfo = FillProcessAction((ProcessActionType)settings.Settings.Keys["shift"], psInfo);
                    }
                    Process.Start(psInfo);
                }
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
                            AddMenuGroup(child, dropdown.DropDownItems);
                            break;

                        case menuItemType.Application:
                            AddMenuApp(child, dropdown.DropDownItems);
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
           List<MenuListItem>? children = menuList.GetRootChildren();
           if (children != null)
           {
               foreach(MenuListItem child in children)
               {
                   switch (child.Type)
                   {
                       case menuItemType.Group:
                           AddMenuGroup(child, menu.Items);
                           break;

                       case menuItemType.Application:
                           AddMenuApp(child, menu.Items);
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
            menu.Items.Clear();
            AddApps2Menu();

            var item = new ToolStripMenuItem("&Settings...", null, SettingsHandler, "Settings");
            menu.Items.Add(item);
            
            menu.Items.Add(new ToolStripSeparator());
            item = new ToolStripMenuItem("&About", null, AboutHandler, "About");
            menu.Items.Add(item);
            menu.Items.Add(new ToolStripSeparator());
            item = new ToolStripMenuItem("E&xit", null, ExitHandler, "Exit");
            menu.Items.Add(item);

        }
    }
}
