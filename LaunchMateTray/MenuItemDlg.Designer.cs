namespace LaunchMateTray
{
    partial class MenuItemDlg
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
            cancelButton = new Button();
            okButton = new Button();
            label1 = new Label();
            itemType = new ComboBox();
            pathInput = new TextBox();
            browse = new Button();
            nameInput = new TextBox();
            label2 = new Label();
            pathLabel = new Label();
            argsLabel = new Label();
            argsInput = new TextBox();
            label3 = new Label();
            iconInput = new TextBox();
            iconBrowseBtn = new Button();
            itemIcon = new PictureBox();
            layout = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)itemIcon).BeginInit();
            layout.SuspendLayout();
            SuspendLayout();
            // 
            // cancelButton
            // 
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.Location = new Point(360, 197);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "&Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            okButton.DialogResult = DialogResult.OK;
            okButton.Enabled = false;
            okButton.FlatStyle = FlatStyle.Flat;
            okButton.Location = new Point(296, 197);
            okButton.Name = "okButton";
            okButton.Size = new Size(47, 23);
            okButton.TabIndex = 7;
            okButton.Text = "&OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(56, 13);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 3;
            label1.Text = "Type";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // itemType
            // 
            itemType.Anchor = AnchorStyles.Left;
            itemType.BackColor = Color.Black;
            itemType.DropDownStyle = ComboBoxStyle.DropDownList;
            itemType.FlatStyle = FlatStyle.Flat;
            itemType.ForeColor = Color.White;
            itemType.FormattingEnabled = true;
            itemType.Items.AddRange(new object[] { "Application", "Group" });
            itemType.Location = new Point(108, 9);
            itemType.Name = "itemType";
            itemType.Size = new Size(121, 23);
            itemType.TabIndex = 1;
            itemType.SelectedIndexChanged += itemType_SelectedIndexChanged;
            // 
            // pathInput
            // 
            pathInput.Anchor = AnchorStyles.Left;
            pathInput.BackColor = Color.Black;
            pathInput.BorderStyle = BorderStyle.FixedSingle;
            pathInput.ForeColor = Color.White;
            pathInput.Location = new Point(108, 73);
            pathInput.Name = "pathInput";
            pathInput.Size = new Size(265, 23);
            pathInput.TabIndex = 3;
            pathInput.TextChanged += pathInput_TextChanged;
            pathInput.Leave += pathInput_Leave;
            // 
            // browse
            // 
            browse.FlatStyle = FlatStyle.Flat;
            browse.Location = new Point(379, 73);
            browse.Name = "browse";
            browse.Size = new Size(39, 23);
            browse.TabIndex = 4;
            browse.Text = "...";
            browse.UseVisualStyleBackColor = true;
            browse.Click += browse_Click;
            // 
            // nameInput
            // 
            nameInput.Anchor = AnchorStyles.Left;
            nameInput.BackColor = Color.Black;
            nameInput.BorderStyle = BorderStyle.FixedSingle;
            nameInput.ForeColor = Color.White;
            nameInput.Location = new Point(108, 44);
            nameInput.Name = "nameInput";
            nameInput.Size = new Size(265, 23);
            nameInput.TabIndex = 2;
            nameInput.TextChanged += nameInput_TextChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(44, 48);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 3;
            label2.Text = "Name*";
            label2.TextAlign = ContentAlignment.TopRight;
            // 
            // pathLabel
            // 
            pathLabel.Anchor = AnchorStyles.Right;
            pathLabel.AutoSize = true;
            pathLabel.Location = new Point(52, 77);
            pathLabel.Name = "pathLabel";
            pathLabel.Size = new Size(36, 15);
            pathLabel.TabIndex = 3;
            pathLabel.Text = "Path*";
            pathLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // argsLabel
            // 
            argsLabel.Anchor = AnchorStyles.Right;
            argsLabel.AutoSize = true;
            argsLabel.Location = new Point(22, 106);
            argsLabel.Name = "argsLabel";
            argsLabel.Size = new Size(66, 15);
            argsLabel.TabIndex = 3;
            argsLabel.Text = "Arguments";
            // 
            // argsInput
            // 
            argsInput.Anchor = AnchorStyles.Left;
            argsInput.BackColor = Color.Black;
            argsInput.BorderStyle = BorderStyle.FixedSingle;
            argsInput.ForeColor = Color.White;
            argsInput.Location = new Point(108, 102);
            argsInput.Name = "argsInput";
            argsInput.Size = new Size(265, 23);
            argsInput.TabIndex = 5;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(58, 141);
            label3.Name = "label3";
            label3.Size = new Size(30, 15);
            label3.TabIndex = 3;
            label3.Text = "Icon";
            // 
            // iconInput
            // 
            iconInput.Anchor = AnchorStyles.Left;
            iconInput.BackColor = Color.Black;
            iconInput.BorderStyle = BorderStyle.FixedSingle;
            iconInput.ForeColor = Color.White;
            iconInput.Location = new Point(108, 137);
            iconInput.Name = "iconInput";
            iconInput.Size = new Size(265, 23);
            iconInput.TabIndex = 5;
            iconInput.TextChanged += iconInput_TextChanged;
            iconInput.Leave += iconInput_Leave;
            // 
            // iconBrowseBtn
            // 
            iconBrowseBtn.Anchor = AnchorStyles.Left;
            iconBrowseBtn.FlatStyle = FlatStyle.Flat;
            iconBrowseBtn.Location = new Point(379, 137);
            iconBrowseBtn.Name = "iconBrowseBtn";
            iconBrowseBtn.Size = new Size(39, 23);
            iconBrowseBtn.TabIndex = 4;
            iconBrowseBtn.Text = "...";
            iconBrowseBtn.UseVisualStyleBackColor = true;
            iconBrowseBtn.Click += iconBrowseBtn_Click;
            // 
            // itemIcon
            // 
            itemIcon.Anchor = AnchorStyles.Left;
            itemIcon.BorderStyle = BorderStyle.FixedSingle;
            itemIcon.Location = new Point(379, 3);
            itemIcon.Name = "itemIcon";
            itemIcon.Size = new Size(34, 34);
            itemIcon.TabIndex = 8;
            itemIcon.TabStop = false;
            // 
            // layout
            // 
            layout.ColumnCount = 5;
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 91F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.102041F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 94.89796F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 53F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            layout.Controls.Add(iconBrowseBtn, 3, 4);
            layout.Controls.Add(label2, 0, 1);
            layout.Controls.Add(browse, 3, 2);
            layout.Controls.Add(argsInput, 2, 3);
            layout.Controls.Add(itemIcon, 3, 0);
            layout.Controls.Add(nameInput, 2, 1);
            layout.Controls.Add(iconInput, 2, 4);
            layout.Controls.Add(pathInput, 2, 2);
            layout.Controls.Add(argsLabel, 0, 3);
            layout.Controls.Add(label3, 0, 4);
            layout.Controls.Add(label1, 0, 0);
            layout.Controls.Add(pathLabel, 0, 2);
            layout.Controls.Add(itemType, 2, 0);
            layout.Location = new Point(8, 9);
            layout.Name = "layout";
            layout.RowCount = 5;
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            layout.RowStyles.Add(new RowStyle());
            layout.RowStyles.Add(new RowStyle());
            layout.RowStyles.Add(new RowStyle());
            layout.RowStyles.Add(new RowStyle());
            layout.Size = new Size(440, 169);
            layout.TabIndex = 9;
            // 
            // MenuItemDlg
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.Black;
            ClientSize = new Size(449, 230);
            ControlBox = false;
            Controls.Add(layout);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MinimizeBox = false;
            Name = "MenuItemDlg";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Menu Item";
            FormClosing += MenuItemDlg_FormClosing;
            ((System.ComponentModel.ISupportInitialize)itemIcon).EndInit();
            layout.ResumeLayout(false);
            layout.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button cancelButton;
        private Button okButton;
        private Label label1;
        private ComboBox itemType;
        private TextBox pathInput;
        private Button browse;
        private TextBox nameInput;
        private Label label2;
        private Label pathLabel;
        private Label argsLabel;
        private TextBox argsInput;
        private Label label3;
        private TextBox iconInput;
        private Button iconBrowseBtn;
        private PictureBox itemIcon;
        private TableLayoutPanel layout;
    }
}