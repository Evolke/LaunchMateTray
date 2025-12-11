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
            sortBtn = new Button();
            deleteItemBtn = new Button();
            editMenuItem = new Button();
            addMenuItem = new Button();
            menuTreeView = new TreeView();
            appearTab = new TabPage();
            seltextclr_btn = new ColorButton();
            seltextclr_label = new Label();
            selectclr_btn = new ColorButton();
            selectclr_label = new Label();
            textclr_btn = new ColorButton();
            textclr_label = new Label();
            backclr_btn = new ColorButton();
            backclr_label = new Label();
            keyTab = new TabPage();
            shiftAction = new ComboBox();
            shiftLabel = new Label();
            ctrlAction = new ComboBox();
            ctrl_label = new Label();
            tableLayoutPanel1.SuspendLayout();
            tabControl1.SuspendLayout();
            appTab.SuspendLayout();
            appearTab.SuspendLayout();
            keyTab.SuspendLayout();
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
            tabControl1.Controls.Add(appearTab);
            tabControl1.Controls.Add(keyTab);
            tabControl1.Location = new Point(3, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(758, 371);
            tabControl1.TabIndex = 2;
            // 
            // appTab
            // 
            appTab.BackColor = Color.Black;
            appTab.Controls.Add(sortBtn);
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
            // sortBtn
            // 
            sortBtn.FlatStyle = FlatStyle.Flat;
            sortBtn.Location = new Point(690, 93);
            sortBtn.Name = "sortBtn";
            sortBtn.Size = new Size(54, 23);
            sortBtn.TabIndex = 2;
            sortBtn.Text = "Sort";
            sortBtn.UseVisualStyleBackColor = true;
            sortBtn.Click += sortBtn_Click;
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
            menuTreeView.HideSelection = false;
            menuTreeView.Location = new Point(6, 6);
            menuTreeView.Name = "menuTreeView";
            menuTreeView.ShowNodeToolTips = true;
            menuTreeView.Size = new Size(678, 330);
            menuTreeView.TabIndex = 0;
            menuTreeView.ItemDrag += menuTreeView_ItemDrag;
            menuTreeView.AfterSelect += menuTreeView_AfterSelect;
            menuTreeView.DragDrop += menuTreeView_DragDrop;
            menuTreeView.DragEnter += menuTreeView_DragEnter;
            menuTreeView.DragOver += menuTreeView_DragOver;
			menuTreeView.MouseDown += menuTreeView_MouseDown;
            // 
            // appearTab
            // 
            appearTab.BackColor = Color.Black;
            appearTab.Controls.Add(seltextclr_btn);
            appearTab.Controls.Add(seltextclr_label);
            appearTab.Controls.Add(selectclr_btn);
            appearTab.Controls.Add(selectclr_label);
            appearTab.Controls.Add(textclr_btn);
            appearTab.Controls.Add(textclr_label);
            appearTab.Controls.Add(backclr_btn);
            appearTab.Controls.Add(backclr_label);
            appearTab.ForeColor = Color.White;
            appearTab.Location = new Point(4, 24);
            appearTab.Name = "appearTab";
            appearTab.Padding = new Padding(3);
            appearTab.Size = new Size(750, 343);
            appearTab.TabIndex = 1;
            appearTab.Text = "Appearance";
            // 
            // seltextclr_btn
            // 
            seltextclr_btn.Location = new Point(350, 205);
            seltextclr_btn.Name = "seltextclr_btn";
            seltextclr_btn.Size = new Size(75, 28);
            seltextclr_btn.TabIndex = 7;
            seltextclr_btn.UseVisualStyleBackColor = true;
            // 
            // seltextclr_label
            // 
            seltextclr_label.AutoSize = true;
            seltextclr_label.Location = new Point(249, 212);
            seltextclr_label.Name = "seltextclr_label";
            seltextclr_label.Size = new Size(94, 15);
            seltextclr_label.TabIndex = 6;
            seltextclr_label.Text = "Select Text Color";
            seltextclr_label.TextAlign = ContentAlignment.BottomRight;
            // 
            // selectclr_btn
            // 
            selectclr_btn.Location = new Point(350, 153);
            selectclr_btn.Name = "selectclr_btn";
            selectclr_btn.Size = new Size(75, 28);
            selectclr_btn.TabIndex = 5;
            selectclr_btn.UseVisualStyleBackColor = true;
            // 
            // selectclr_label
            // 
            selectclr_label.AutoSize = true;
            selectclr_label.Location = new Point(273, 160);
            selectclr_label.Name = "selectclr_label";
            selectclr_label.Size = new Size(70, 15);
            selectclr_label.TabIndex = 4;
            selectclr_label.Text = "Select Color";
            selectclr_label.TextAlign = ContentAlignment.BottomRight;
            // 
            // textclr_btn
            // 
            textclr_btn.Location = new Point(350, 101);
            textclr_btn.Name = "textclr_btn";
            textclr_btn.Size = new Size(75, 28);
            textclr_btn.TabIndex = 3;
            textclr_btn.UseVisualStyleBackColor = true;
            // 
            // textclr_label
            // 
            textclr_label.AutoSize = true;
            textclr_label.Location = new Point(283, 108);
            textclr_label.Name = "textclr_label";
            textclr_label.Size = new Size(60, 15);
            textclr_label.TabIndex = 2;
            textclr_label.Text = "Text Color";
            textclr_label.TextAlign = ContentAlignment.BottomRight;
            // 
            // backclr_btn
            // 
            backclr_btn.Location = new Point(350, 51);
            backclr_btn.Name = "backclr_btn";
            backclr_btn.Size = new Size(75, 28);
            backclr_btn.TabIndex = 1;
            backclr_btn.UseVisualStyleBackColor = true;
            // 
            // backclr_label
            // 
            backclr_label.AutoSize = true;
            backclr_label.Location = new Point(240, 59);
            backclr_label.Name = "backclr_label";
            backclr_label.Size = new Size(103, 15);
            backclr_label.TabIndex = 0;
            backclr_label.Text = "Background Color";
            // 
            // keyTab
            // 
            keyTab.BackColor = Color.Black;
            keyTab.Controls.Add(shiftAction);
            keyTab.Controls.Add(shiftLabel);
            keyTab.Controls.Add(ctrlAction);
            keyTab.Controls.Add(ctrl_label);
            keyTab.Location = new Point(4, 24);
            keyTab.Name = "keyTab";
            keyTab.Size = new Size(750, 343);
            keyTab.TabIndex = 2;
            keyTab.Text = "Keys";
            // 
            // shiftAction
            // 
            shiftAction.BackColor = Color.Black;
            shiftAction.DropDownStyle = ComboBoxStyle.DropDownList;
            shiftAction.FlatStyle = FlatStyle.Flat;
            shiftAction.ForeColor = Color.White;
            shiftAction.FormattingEnabled = true;
            shiftAction.Items.AddRange(new object[] { "Run As Administrator", "Run Minimized", "Run Maximized" });
            shiftAction.Location = new Point(281, 165);
            shiftAction.Name = "shiftAction";
            shiftAction.Size = new Size(213, 23);
            shiftAction.TabIndex = 1;
            // 
            // shiftLabel
            // 
            shiftLabel.AutoSize = true;
            shiftLabel.Location = new Point(238, 168);
            shiftLabel.Name = "shiftLabel";
            shiftLabel.Size = new Size(31, 15);
            shiftLabel.TabIndex = 0;
            shiftLabel.Text = "Shift";
            // 
            // ctrlAction
            // 
            ctrlAction.BackColor = Color.Black;
            ctrlAction.DropDownStyle = ComboBoxStyle.DropDownList;
            ctrlAction.FlatStyle = FlatStyle.Flat;
            ctrlAction.ForeColor = Color.White;
            ctrlAction.FormattingEnabled = true;
            ctrlAction.Items.AddRange(new object[] { "Run As Administrator", "Run Minimized", "Run Maximized" });
            ctrlAction.Location = new Point(281, 115);
            ctrlAction.Name = "ctrlAction";
            ctrlAction.Size = new Size(213, 23);
            ctrlAction.TabIndex = 1;
            // 
            // ctrl_label
            // 
            ctrl_label.AutoSize = true;
            ctrl_label.Location = new Point(238, 118);
            ctrl_label.Name = "ctrl_label";
            ctrl_label.Size = new Size(26, 15);
            ctrl_label.TabIndex = 0;
            ctrl_label.Text = "Ctrl";
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
            appearTab.ResumeLayout(false);
            appearTab.PerformLayout();
            keyTab.ResumeLayout(false);
            keyTab.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button okButton;
        private Button cancelButton;
        private TableLayoutPanel tableLayoutPanel1;
        private TabControl tabControl1;
        private TabPage appTab;
        private TabPage appearTab;
        private TreeView menuTreeView;
        private Button editMenuItem;
        private Button addMenuItem;
        private Button deleteItemBtn;
        private ColorButton backclr_btn;
        private Label backclr_label;
        private ColorButton textclr_btn;
        private Label textclr_label;
        private ColorButton selectclr_btn;
        private Label selectclr_label;
        private ColorButton seltextclr_btn;
        private Label seltextclr_label;
        private TabPage keyTab;
        private ComboBox ctrlAction;
        private Label ctrl_label;
        private ComboBox shiftAction;
        private Label shiftLabel;
        private Button sortBtn;
    }
}