namespace LaunchMateTray
{
    partial class SettingsDlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            okButton = new Button();
            cancelButton = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tabControl1 = new TabControl();
            appTab = new TabPage();
            deleteItemBtn = new Button();
            editMenuItem = new Button();
            addMenuItem = new Button();
            menuTreeView = new TreeView();
            tabPage2 = new TabPage();
            tableLayoutPanel1.SuspendLayout();
            tabControl1.SuspendLayout();
            appTab.SuspendLayout();
            SuspendLayout();
            // 
            // okButton
            // 
            okButton.DialogResult = DialogResult.OK;
            okButton.FlatStyle = FlatStyle.Flat;
            okButton.ForeColor = Color.White;
            okButton.Location = new Point(608, 415);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.TabIndex = 0;
            okButton.Text = "&OK";
            okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.ForeColor = Color.White;
            cancelButton.Location = new Point(691, 415);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 0;
            cancelButton.Text = "&Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 12F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 581F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(tabControl1, 0, 0);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 97.92208F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 2.077922F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(776, 426);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(appTab);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(3, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(758, 371);
            tabControl1.TabIndex = 2;
            // 
            // appTab
            // 
            appTab.BackColor = Color.Black;
            appTab.Controls.Add(deleteItemBtn);
            appTab.Controls.Add(editMenuItem);
            appTab.Controls.Add(addMenuItem);
            appTab.Controls.Add(menuTreeView);
            appTab.ForeColor = Color.White;
            appTab.Location = new Point(4, 24);
            appTab.Name = "appTab";
            appTab.Padding = new Padding(3);
            appTab.Size = new Size(750, 343);
            appTab.TabIndex = 0;
            appTab.Text = "Applications";
            // 
            // deleteItemBtn
            // 
            deleteItemBtn.Enabled = false;
            deleteItemBtn.FlatStyle = FlatStyle.Flat;
            deleteItemBtn.Location = new Point(690, 64);
            deleteItemBtn.Name = "deleteItemBtn";
            deleteItemBtn.Size = new Size(54, 23);
            deleteItemBtn.TabIndex = 1;
            deleteItemBtn.Text = "Delete";
            deleteItemBtn.UseVisualStyleBackColor = true;
            deleteItemBtn.Click += deleteItemBtn_Click;
            // 
            // editMenuItem
            // 
            editMenuItem.Enabled = false;
            editMenuItem.FlatStyle = FlatStyle.Flat;
            editMenuItem.Location = new Point(690, 35);
            editMenuItem.Name = "editMenuItem";
            editMenuItem.Size = new Size(54, 23);
            editMenuItem.TabIndex = 1;
            editMenuItem.Text = "Edit";
            editMenuItem.UseVisualStyleBackColor = true;
            editMenuItem.Click += editMenuItem_Click;
            // 
            // addMenuItem
            // 
            addMenuItem.FlatStyle = FlatStyle.Flat;
            addMenuItem.Location = new Point(690, 6);
            addMenuItem.Name = "addMenuItem";
            addMenuItem.Size = new Size(54, 23);
            addMenuItem.TabIndex = 1;
            addMenuItem.Text = "Add";
            addMenuItem.UseVisualStyleBackColor = false;
            addMenuItem.Click += addMenuItem_Click;
            // 
            // menuTreeView
            // 
            menuTreeView.AllowDrop = true;
            menuTreeView.BackColor = Color.Black;
            menuTreeView.BorderStyle = BorderStyle.FixedSingle;
            menuTreeView.ForeColor = Color.White;
            menuTreeView.Location = new Point(6, 6);
            menuTreeView.Name = "menuTreeView";
            menuTreeView.ShowNodeToolTips = true;
            menuTreeView.Size = new Size(678, 330);
            menuTreeView.TabIndex = 0;
            menuTreeView.AfterSelect += menuTreeView_AfterSelect;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.Black;
            tabPage2.ForeColor = Color.White;
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(750, 343);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Appearance";
            // 
            // SettingsDlg
            // 
            AcceptButton = okButton;
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            CancelButton = cancelButton;
            ClientSize = new Size(800, 450);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(tableLayoutPanel1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "SettingsDlg";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Settings";
            tableLayoutPanel1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            appTab.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button okButton;
        private Button cancelButton;
        private TableLayoutPanel tableLayoutPanel1;
        private TabControl tabControl1;
        private TabPage appTab;
        private TabPage tabPage2;
        private TreeView menuTreeView;
        private Button editMenuItem;
        private Button addMenuItem;
        private Button deleteItemBtn;
    }
}