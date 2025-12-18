using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaunchMateTray
{

    public partial class MenuItemDlg : Form
    {
        public MenuListItem menuItem = new MenuListItem();

        public MenuItemDlg()
        {
            InitializeComponent();
        }

        public MenuItemDlg(string title, MenuListItem inputMenuItem)
        {
            InitializeComponent();
            Text = title;
            itemType.SelectedIndex = (int)inputMenuItem.Type;
            nameInput.Text = inputMenuItem.Name;
            pathInput.Text = inputMenuItem.Path;
            argsInput.Text = inputMenuItem.Arguments;
            iconInput.Text = inputMenuItem.IconPath;

            menuItem = inputMenuItem;
        }

        private void browse_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "Applications (*.exe)|*.exe";

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                pathInput.Text = dlg.FileName;
                nameInput.Text = Path.GetFileNameWithoutExtension(dlg.SafeFileName);
                okButton.Enabled = true;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            menuItem.Type = (menuItemType)itemType.SelectedIndex;
            menuItem.Name = nameInput.Text;
            menuItem.Path = pathInput.Text;
            menuItem.Arguments = argsInput.Text;
            menuItem.IconPath = iconInput.Text;
        }

        private void ToggleTypeFields(menuItemType type)
        {
            bool show = false;

            switch (type)
            {
                case menuItemType.Application:
                    show = true;
                    break;

                case menuItemType.Group:
                    show = false;
                    break;
            }
            pathLabel.Visible = show;
            pathInput.Visible = show;
            browse.Visible = show;
            argsLabel.Visible = show;
            argsInput.Visible = show;

            enableOKBtn();

        }

        void enableOKBtn()
        {
            bool enableOK = false;

            switch ((menuItemType)itemType.SelectedIndex)
            {
                case menuItemType.Application:
                    enableOK = nameInput.Text.Length > 0 && pathInput.Text.Length > 0;
                    break;
                case menuItemType.Group:
                    enableOK = nameInput.Text.Length > 0;
                    break;
            }

            okButton.Enabled = enableOK;
        }
        private void itemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToggleTypeFields((menuItemType)itemType.SelectedIndex);
        }

        private void MenuItemDlg_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            /*Debug.WriteLine(e.ToString());
            if (nameInput.Text.Length == 0)
            {
                e.Cancel = true;
                MessageBox.Show("Name is required");
                return;
            }*/

        }
        private void nameInput_TextChanged(object sender, EventArgs e)
        {
            enableOKBtn();
        }

        private void pathInput_TextChanged(object sender, EventArgs e)
        {
            enableOKBtn();
        }

        private void iconBrowseBtn_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "Applications (*.exe)|*.exe|Icons (*.ico)|*.ico|Images (*.png)|*.png";

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                iconInput.Text = dlg.FileName;
            }
        }

        private void iconInput_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
