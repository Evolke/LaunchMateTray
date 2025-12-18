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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LaunchMateTray
{
    public partial class SettingsDlg : Form
    {
        protected MenuList? menuList;
        protected LaunchMateTrayContextMenuStrip? itemContextMenu;
        protected LaunchMateTraySettings? settings;

        public SettingsDlg()
        {
            InitializeComponent();
            menuTreeView.ImageList = new ImageList();
            settings = new LaunchMateTraySettings();
            settings.ReadSettings();
            InitMenuList();
            InitColorSettings();
            InitKeySettings();
        }

        public MenuList? GetMenuList() { return menuList; }

        public void InitMenuList()
        {
            if (settings == null) { return; }

            menuList = new MenuList();
            menuList.ImportSettings(settings.Settings.Apps);
            itemContextMenu = new LaunchMateTrayContextMenuStrip(settings.Settings.Appearance);
            itemContextMenu.Items.AddRange([
                new ToolStripMenuItem("Add",null,AddItemHandler),
                new ToolStripMenuItem("Edit",null,EditItemHandler),
                new ToolStripMenuItem("Delete",null,DeleteItemHandler)
            ]);

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
        public void InitColorSettings()
        {
            ColorSettings? colorSettings = settings?.Settings.Appearance;
            if (colorSettings == null) { return; }
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

        public void InitKeySettings()
        {
            KeySettings? keySettings = settings?.Settings.Keys;
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

        private bool IsGroupNode(TreeNode node)
        {
            return node.Name.StartsWith("g:");
        }

        public void AddItemHandler(object? sender, EventArgs e)
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
                    if (IsGroupNode(selNode))
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
                        menuList?.BuildDictionaryItem(item);
                    }
                }
                else
                {
                    menuList?.Root.AddChild(item);
                    menuList?.BuildDictionaryItem(item);
                }
                AddTreeItem(item, nodes ?? menuTreeView.Nodes);
            }
        }
        public void EditItemHandler(object? sender, EventArgs e)
        {
            var selNode = menuTreeView.SelectedNode;
            if (selNode != null)
            {
                MenuListItem? item = menuList?.FindMenuItem(selNode.Name);
                if (item != null)
                {
                    var dlg = new MenuItemDlg("Edit Menu Item", item);
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        selNode.Text = item.Name;
                        int index = menuTreeView?.ImageList?.Images.IndexOfKey(item.Id) ?? -1;
                        Icon? itemIcon = item.GetIcon();
                        if (itemIcon != null)
                        {
                            Bitmap resizedBitmap = new Bitmap(itemIcon.ToBitmap(), new Size(16, 16));
                            menuTreeView?.ImageList?.Images[index] = resizedBitmap;
                        }
                    }
                }

            }

        }
        public void DeleteItemHandler(object? sender, EventArgs e)
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

        private void addMenuItem_Click(object sender, EventArgs e)
        {
            AddItemHandler(sender, e);
        }

        private void editMenuItem_Click(object sender, EventArgs e)
        {
            EditItemHandler(sender, e);
        }


        private void deleteItemBtn_Click(object sender, EventArgs e)
        {
            DeleteItemHandler(sender, e);
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
                    Icon icon = item.GetIcon() ?? SystemIcons.GetStockIcon(StockIconId.Error, 16);
                    menuTreeView?.ImageList?.Images.Add(item.Id, icon);
                    ret = nodes.Add(item.Id, item.Name, item.Id, item.Id);
                    break;

                case menuItemType.Group:
                    menuTreeView?.ImageList?.Images.Add(item.Id, item.GetIcon() ?? SystemIcons.GetStockIcon(StockIconId.Error, 16));
                    ret = nodes.Add(item.Id, item.Name, item.Id, item.Id);
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

            if (itemContextMenu != null && ret != null)
            {
                ret.ContextMenuStrip = itemContextMenu;
            }
            return ret;
        }

        private bool ContainsNode(TreeNode dragNode, TreeNode targetNode)
        {
            // Check the parent node of the second node.  
            if (targetNode.Parent == null) return false;
            if (targetNode.Parent.Equals(dragNode)) return true;

            // If the parent node is not null or equal to the first node,   
            // call the ContainsNode method recursively using the parent of   
            // the second node.  
            return ContainsNode(dragNode, targetNode.Parent);
        }

        private void menuTreeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // Move the dragged node when the left mouse button is used.  
            if (e.Button == MouseButtons.Left && e.Item != null)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }

            // Copy the dragged node when the right mouse button is used.  
            else if (e.Button == MouseButtons.Right && e.Item != null)
            {
                DoDragDrop(e.Item, DragDropEffects.Copy);
            }

        }

        private void menuTreeView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void menuTreeView_DragOver(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse position.  
            Point targetPoint = menuTreeView.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.  
            menuTreeView.SelectedNode = menuTreeView.GetNodeAt(targetPoint);
        }

        private void menuTreeView_DragDrop(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the drop location.  
            Point targetPoint = menuTreeView.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.  
            TreeNode? targetNode = menuTreeView.GetNodeAt(targetPoint);

            // Retrieve the node that was dragged.  
            TreeNode? draggedNode = e.Data != null ? (TreeNode?)e.Data.GetData(typeof(TreeNode)) : null;
            if (targetNode != null && draggedNode != null)
            {
                MenuListItem? dragItem = menuList?.FindMenuItem(draggedNode.Name);
                MenuListItem? targetItem = menuList?.FindMenuItem(targetNode.Name);
                if (targetItem == null || dragItem == null) { return; }

                // Confirm that the node at the drop location is not   
                // the dragged node or a descendant of the dragged node.  
                if (!draggedNode.Equals(targetNode))
                {
                    if (!ContainsNode(draggedNode, targetNode) && IsGroupNode(targetNode))
                    {
                        // If it is a move operation, remove the node from its current   
                        // location and add it to the node at the drop location.  
                        if (e.Effect == DragDropEffects.Move)
                        {
                            draggedNode.Remove();
                            dragItem.GetParent()?.RemoveChild(dragItem);
                            targetNode.Nodes.Add(draggedNode);
                            targetItem.AddChild(dragItem);
                        }

                        // If it is a copy operation, clone the dragged node   
                        // and add it to the node at the drop location.  
                        else if (e.Effect == DragDropEffects.Copy)
                        {
                            targetNode.Nodes.Add((TreeNode)draggedNode.Clone());
                            targetItem.AddChild((MenuListItem)dragItem.Clone());
                        }

                        // Expand the node at the location   
                        // to show the dropped node.  
                        targetNode.Expand();
                    }
                    else
                    {
                        draggedNode.Remove();
                        dragItem.GetParent()?.RemoveChild(dragItem);
                        targetNode.Parent?.Nodes.Insert(targetNode.Index, draggedNode);
                        targetItem.GetParent()?.InsertChild(dragItem, targetItem);
                    }
                }
            }
            else
            {
                string[]? files = e.Data?.GetData(DataFormats.FileDrop) as string[];
                if (files != null && files.Length > 0)
                {
                    foreach (string file in files)
                    {
                        if (Path.GetExtension(file).ToLower() == ".exe")
                        {
                            MenuListItem item = new MenuListItem();
                            item.Path = file;
                            item.Name = Path.GetFileNameWithoutExtension(file);
                            AddTreeItem(item, menuTreeView.Nodes);
                            menuList?.Root.AddChild(item);
                            menuList?.BuildDictionaryItem(item);
                        }
                    }
                }
            }




        }

        private void sortBtn_Click(object sender, EventArgs e)
        {
            menuTreeView.Sort();
            menuList?.Sort();

        }

        private void menuTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //Point targetPoint = menuTreeView.PointToClient();
                TreeNode? targetNode = menuTreeView.GetNodeAt(new Point(e.X, e.Y));
                if (targetNode != null) { menuTreeView.SelectedNode = targetNode; }
            }
        }
    }
}
