using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LaunchMateTray
{
    public partial class SettingsDlg : Form
    {
        protected MenuList? menuList;

        public SettingsDlg()
        {
            InitializeComponent();
            menuTreeView.ImageList = new ImageList();
        }

        public MenuList? GetMenuList() { return menuList; }
        public void SetMenuList(MenuList menulist)
        {
            menuList = menulist;
            var children = menuList.GetRootChildren();
            if (children != null)
            {
                foreach (var item in children)
                {
                    AddTreeItem(item, menuTreeView.Nodes);
                }

            }
        }

        public ColorSettings GetColorSettings()
        {
            ColorSettings colors = new ColorSettings();
            Color backclr = backclr_btn.BtnColor;
            Color textclr = textclr_btn.BtnColor;
            Color selectclr = selectclr_btn.BtnColor;
            Color seltextclr = seltextclr_btn.BtnColor;

            colors["backclr"] = backclr.ToArgb().ToString("X");
            colors["textclr"] = textclr.ToArgb().ToString("X");
            colors["selectclr"] = selectclr.ToArgb().ToString("X");
            colors["seltextclr"] = seltextclr.ToArgb().ToString("X");

            return colors;
        }
        public void SetColorSettings(ColorSettings colorSettings)
        {
            int clr = Int32.Parse(colorSettings != null ? colorSettings["backclr"] : LaunchMateTraySettings.defaultColors["backclr"], NumberStyles.AllowHexSpecifier);
            Color bkClr = Color.FromArgb(clr);
            backclr_btn.BtnColor = bkClr;

            clr = Int32.Parse(colorSettings != null ? colorSettings["textclr"] : LaunchMateTraySettings.defaultColors["textclr"], NumberStyles.AllowHexSpecifier);
            Color txtClr = Color.FromArgb(clr);
            textclr_btn.BtnColor = txtClr;

            clr = Int32.Parse(colorSettings != null ? colorSettings["selectclr"] : LaunchMateTraySettings.defaultColors["selectclr"], NumberStyles.AllowHexSpecifier);
            Color selectClr = Color.FromArgb(clr);
            selectclr_btn.BtnColor = selectClr;

            clr = Int32.Parse(colorSettings != null ? colorSettings["seltextclr"] : LaunchMateTraySettings.defaultColors["seltextclr"], NumberStyles.AllowHexSpecifier);
            Color selTxtClr = Color.FromArgb(clr);
            seltextclr_btn.BtnColor = selTxtClr;
        }

        public void SetKeySettings(KeySettings keySettings)
        {
            ctrlAction.SelectedIndex = keySettings != null ? keySettings["ctrl"] : 0;
            shiftAction.SelectedIndex = keySettings != null ? keySettings["shift"] : 1;
        }

        public KeySettings GetKeySettings()
        {
            KeySettings keySettings = new KeySettings()
            {
                { "ctrl", ctrlAction.SelectedIndex},
                { "shift", shiftAction.SelectedIndex }
            };

            return keySettings;
        }

        private void addMenuItem_Click(object sender, EventArgs e)
        {
            MenuListItem item = new MenuListItem();
            item.Type = 0;
            var dlg = new MenuItemDlg("Add Menu Item", item);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                var selNode = menuTreeView.SelectedNode;
                var nodes = menuTreeView.Nodes;
                if (selNode != null)
                {
                    if (selNode.ImageKey == "ImageList.folder")
                    {
                        nodes = selNode.Nodes;
                    }
                    else
                    {
                        nodes = selNode?.Parent?.Nodes;
                    }

                    MenuListItem? parentItem = menuList?.FindMenuItem(selNode != null ? selNode.Name : "");
                    if (parentItem != null)
                    {
                        parentItem.AddChild(item);
                    }
                }
                else
                {
                    menuList?.Root.AddChild(item);
                }
                AddTreeItem(item, nodes ?? menuTreeView.Nodes);
            }
        }

        private void editMenuItem_Click(object sender, EventArgs e)
        {
            var selNode = menuTreeView.SelectedNode;
            if (selNode != null)
            {
                var item = menuList?.FindMenuItem(selNode.Name);
                if (item != null)
                {
                    var dlg = new MenuItemDlg("Edit Menu Item", item);
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        selNode.Text = item.Name;
                    }
                }

            }
        }

        private void deleteItemBtn_Click(object sender, EventArgs e)
        {
            var selNode = menuTreeView.SelectedNode;
            if (selNode != null)
            {
                if (MessageBox.Show(this, "Are you sure you want to delete the selected item?", "Delete?", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    var id = selNode.Name;
                    var item = menuList?.FindMenuItem(id);
                    if (item != null)
                    {
                        var parent = item.GetParent();
                        if (parent != null)
                        {
                            parent.RemoveChild(item);
                            menuList?.BuildDictionary();
                            selNode.Parent?.Nodes.Remove(selNode);
                        }
                    }
                }
            }

        }

        private void menuTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            bool selected = menuTreeView.SelectedNode != null;
            editMenuItem.Enabled = selected;
            deleteItemBtn.Enabled = selected;
        }

        private TreeNode? AddTreeItem(MenuListItem item, TreeNodeCollection nodes)
        {
            TreeNode? ret = null;

            switch (item.Type)
            {
                case menuItemType.Application:
                    if (!File.Exists(item.Path)) { MessageBox.Show("Invalid Path"); return null; }
                    Icon icon = Icon.ExtractAssociatedIcon(item.Path) ?? SystemIcons.GetStockIcon(StockIconId.Error, 16);
                    menuTreeView?.ImageList?.Images.Add(item.Path, icon);
                    ret = nodes.Add(item.Id, item.Name, item.Path, item.Path);
                    break;

                case menuItemType.Group:
                    menuTreeView?.ImageList?.Images.Add("ImageList.folder", SystemIcons.GetStockIcon(StockIconId.Folder, 16));
                    ret = nodes.Add(item.Id, item.Name, "ImageList.folder", "ImageList.folder");
                    var children = item.GetChildren();
                    if (children != null)
                    {
                        foreach (var child in children)
                        {
                            AddTreeItem(child, ret.Nodes);
                        }
                    }
                    break;
            }

            return ret;
        }
    }
}
