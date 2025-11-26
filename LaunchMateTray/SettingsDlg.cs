using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LaunchMateTray
{
    public partial class SettingsDlg : Form
    {
        public SettingsDlg()
        {
            InitializeComponent();
            menuTreeView.ImageList = new ImageList();
        }


        private void addMenuItem_Click(object sender, EventArgs e)
        {
            var itemInfo = new MenuItemInfo();
            itemInfo.itemType = 0;
            var dlg = new MenuItemDlg("Add Menu Item", itemInfo);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                itemInfo = dlg.menuItemInfo;
                var selNode = menuTreeView.SelectedNode;
                var nodes = menuTreeView.Nodes; 
                if (selNode != null)
                {
                    if (selNode.ImageKey == "ImageList.folder") {
                        nodes = selNode.Nodes;
                    } else {
                        nodes = selNode?.Parent?.Nodes;
                    }
                }
                this.addTreeItem(itemInfo, nodes);
            }
        }

        private void editMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteItemBtn_Click(object sender, EventArgs e)
        {

        }

        private void menuTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            bool selected = menuTreeView.SelectedNode != null;
            editMenuItem.Enabled = selected;
            deleteItemBtn.Enabled = selected;
        }

        private void addTreeItem(MenuItemInfo itemInfo, TreeNodeCollection nodes)
        {
            switch (itemInfo.itemType)
            {
                case menuItemType.Application:
                    menuTreeView.ImageList.Images.Add(itemInfo.itemPath, Icon.ExtractAssociatedIcon(itemInfo.itemPath));
                    nodes.Add(itemInfo.itemPath, itemInfo.itemName, itemInfo.itemPath, itemInfo.itemPath);
                    break;
                case menuItemType.Group:
                    menuTreeView.ImageList.Images.Add("ImageList.folder", SystemIcons.GetStockIcon(StockIconId.Folder, 16));
                    nodes.Add(itemInfo.itemName, itemInfo.itemName, "ImageList.folder", "ImageList.folder");
                    break;
            }

        }
    }
}
