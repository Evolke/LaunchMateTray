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
            SuspendLayout();
            // 
            // cancelButton
            // 
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.Location = new Point(375, 163);
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
            okButton.Location = new Point(293, 163);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.TabIndex = 7;
            okButton.Text = "&OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 20);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 3;
            label1.Text = "Type";
            // 
            // itemType
            // 
            itemType.BackColor = Color.Black;
            itemType.DropDownStyle = ComboBoxStyle.DropDownList;
            itemType.FlatStyle = FlatStyle.Flat;
            itemType.ForeColor = Color.White;
            itemType.FormattingEnabled = true;
            itemType.Items.AddRange(new object[] { "Application", "Group" });
            itemType.Location = new Point(94, 17);
            itemType.Name = "itemType";
            itemType.Size = new Size(121, 23);
            itemType.TabIndex = 1;
            itemType.SelectedIndexChanged += itemType_SelectedIndexChanged;
            // 
            // pathInput
            // 
            pathInput.BackColor = Color.Black;
            pathInput.BorderStyle = BorderStyle.FixedSingle;
            pathInput.ForeColor = Color.White;
            pathInput.Location = new Point(94, 84);
            pathInput.Name = "pathInput";
            pathInput.Size = new Size(311, 23);
            pathInput.TabIndex = 3;
            pathInput.TextChanged += pathInput_TextChanged;
            // 
            // browse
            // 
            browse.FlatStyle = FlatStyle.Flat;
            browse.Location = new Point(413, 84);
            browse.Name = "browse";
            browse.Size = new Size(39, 23);
            browse.TabIndex = 4;
            browse.Text = "...";
            browse.UseVisualStyleBackColor = true;
            browse.Click += browse_Click;
            // 
            // nameInput
            // 
            nameInput.BackColor = Color.Black;
            nameInput.BorderStyle = BorderStyle.FixedSingle;
            nameInput.ForeColor = Color.White;
            nameInput.Location = new Point(94, 49);
            nameInput.Name = "nameInput";
            nameInput.Size = new Size(311, 23);
            nameInput.TabIndex = 2;
            nameInput.TextChanged += nameInput_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 52);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 3;
            label2.Text = "Name*";
            label2.TextAlign = ContentAlignment.TopRight;
            // 
            // pathLabel
            // 
            pathLabel.AutoSize = true;
            pathLabel.Location = new Point(50, 86);
            pathLabel.Name = "pathLabel";
            pathLabel.Size = new Size(36, 15);
            pathLabel.TabIndex = 3;
            pathLabel.Text = "Path*";
            pathLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // argsLabel
            // 
            argsLabel.AutoSize = true;
            argsLabel.Location = new Point(15, 122);
            argsLabel.Name = "argsLabel";
            argsLabel.Size = new Size(66, 15);
            argsLabel.TabIndex = 3;
            argsLabel.Text = "Arguments";
            // 
            // argsInput
            // 
            argsInput.BackColor = Color.Black;
            argsInput.BorderStyle = BorderStyle.FixedSingle;
            argsInput.ForeColor = Color.White;
            argsInput.Location = new Point(94, 119);
            argsInput.Name = "argsInput";
            argsInput.Size = new Size(311, 23);
            argsInput.TabIndex = 5;
            // 
            // MenuItemDlg
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(462, 205);
            ControlBox = false;
            Controls.Add(browse);
            Controls.Add(nameInput);
            Controls.Add(argsInput);
            Controls.Add(pathInput);
            Controls.Add(argsLabel);
            Controls.Add(itemType);
            Controls.Add(pathLabel);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            ForeColor = Color.White;
            MinimizeBox = false;
            Name = "MenuItemDlg";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Menu Item";
            FormClosing += MenuItemDlg_FormClosing;
            ResumeLayout(false);
            PerformLayout();
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
    }
}