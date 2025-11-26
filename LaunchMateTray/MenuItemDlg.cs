using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaunchMateTray
{

    public partial class MenuItemDlg : Form
    {
        public MenuItemInfo menuItemInfo = new MenuItemInfo();

        public MenuItemDlg()
        {
            InitializeComponent();
        }

        public MenuItemDlg(string title, MenuItemInfo menuItemInfo)
        {
            InitializeComponent();
            Text = title;
            itemType.SelectedIndex = (int)menuItemInfo.itemType;
        }

        private void browse_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "Applications (*.exe)|*.exe";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pathInput.Text = dlg.FileName;
                nameInput.Text = Path.GetFileNameWithoutExtension(dlg.SafeFileName);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            menuItemInfo.itemType = (menuItemType)itemType.SelectedIndex;
            menuItemInfo.itemName = nameInput.Text;
            menuItemInfo.itemPath = pathInput.Text;
        }

        private void TogglePathFields(bool show)
        {
            pathLabel.Visible = show;
            pathInput.Visible = show;
            browse.Visible = show;
        }

        private void itemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (itemType.SelectedIndex)
            {
                case 0:
                    TogglePathFields(true);
                    break;
                case 1:
                    TogglePathFields(false);
                    break;
            }
        }
    }
}
