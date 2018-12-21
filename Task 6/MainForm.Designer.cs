namespace Task_6
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddLineButton = new System.Windows.Forms.Button();
            this.AddCurveButton = new System.Windows.Forms.Button();
            this.WorkPanel = new System.Windows.Forms.Panel();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.AddSymbolButton = new System.Windows.Forms.Button();
            this.AddContourButton = new System.Windows.Forms.Button();
            this.SYmbolList = new System.Windows.Forms.ListBox();
            this.SymbolTextBox = new System.Windows.Forms.TextBox();
            this.ContourList = new System.Windows.Forms.ListBox();
            this.AllixCheckBox = new System.Windows.Forms.CheckBox();
            this.AllSymbolCheckBox = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.CoordTextBox = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddLineButton
            // 
            this.AddLineButton.Location = new System.Drawing.Point(772, 396);
            this.AddLineButton.Name = "AddLineButton";
            this.AddLineButton.Size = new System.Drawing.Size(80, 45);
            this.AddLineButton.TabIndex = 0;
            this.AddLineButton.Text = "Line";
            this.AddLineButton.UseVisualStyleBackColor = true;
            this.AddLineButton.Click += new System.EventHandler(this.AddLineButton_Click);
            // 
            // AddCurveButton
            // 
            this.AddCurveButton.Location = new System.Drawing.Point(881, 396);
            this.AddCurveButton.Name = "AddCurveButton";
            this.AddCurveButton.Size = new System.Drawing.Size(80, 45);
            this.AddCurveButton.TabIndex = 1;
            this.AddCurveButton.Text = "Bezier";
            this.AddCurveButton.UseVisualStyleBackColor = true;
            this.AddCurveButton.Click += new System.EventHandler(this.AddCurveButton_Click);
            // 
            // WorkPanel
            // 
            this.WorkPanel.BackColor = System.Drawing.Color.Azure;
            this.WorkPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.WorkPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.WorkPanel.Location = new System.Drawing.Point(167, 69);
            this.WorkPanel.Name = "WorkPanel";
            this.WorkPanel.Size = new System.Drawing.Size(500, 500);
            this.WorkPanel.TabIndex = 2;
            this.WorkPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.WorkPanel_Paint);
            this.WorkPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WorkPanel_MouseDown);
            this.WorkPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WorkPanel_MouseMove);
            this.WorkPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WorkPanel_MouseUp);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(772, 459);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(80, 45);
            this.DeleteButton.TabIndex = 3;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // AddSymbolButton
            // 
            this.AddSymbolButton.Location = new System.Drawing.Point(772, 222);
            this.AddSymbolButton.Name = "AddSymbolButton";
            this.AddSymbolButton.Size = new System.Drawing.Size(120, 40);
            this.AddSymbolButton.TabIndex = 4;
            this.AddSymbolButton.Text = "Add symbol";
            this.AddSymbolButton.UseVisualStyleBackColor = true;
            this.AddSymbolButton.Click += new System.EventHandler(this.AddSymbolButton_Click);
            // 
            // AddContourButton
            // 
            this.AddContourButton.Location = new System.Drawing.Point(928, 222);
            this.AddContourButton.Name = "AddContourButton";
            this.AddContourButton.Size = new System.Drawing.Size(120, 40);
            this.AddContourButton.TabIndex = 5;
            this.AddContourButton.Text = "Add contour";
            this.AddContourButton.UseVisualStyleBackColor = true;
            this.AddContourButton.Click += new System.EventHandler(this.AddContourButton_Click);
            // 
            // SYmbolList
            // 
            this.SYmbolList.FormattingEnabled = true;
            this.SYmbolList.ItemHeight = 16;
            this.SYmbolList.Location = new System.Drawing.Point(772, 69);
            this.SYmbolList.Name = "SYmbolList";
            this.SYmbolList.Size = new System.Drawing.Size(120, 132);
            this.SYmbolList.TabIndex = 6;
            this.SYmbolList.SelectedIndexChanged += new System.EventHandler(this.SYmbolList_SelectedIndexChanged);
            // 
            // SymbolTextBox
            // 
            this.SymbolTextBox.Location = new System.Drawing.Point(772, 269);
            this.SymbolTextBox.MaxLength = 1;
            this.SymbolTextBox.Name = "SymbolTextBox";
            this.SymbolTextBox.Size = new System.Drawing.Size(120, 22);
            this.SymbolTextBox.TabIndex = 7;
            this.SymbolTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ContourList
            // 
            this.ContourList.FormattingEnabled = true;
            this.ContourList.ItemHeight = 16;
            this.ContourList.Location = new System.Drawing.Point(928, 69);
            this.ContourList.Name = "ContourList";
            this.ContourList.Size = new System.Drawing.Size(120, 132);
            this.ContourList.TabIndex = 8;
            this.ContourList.SelectedIndexChanged += new System.EventHandler(this.ContourList_SelectedIndexChanged);
            // 
            // AllixCheckBox
            // 
            this.AllixCheckBox.AutoSize = true;
            this.AllixCheckBox.Checked = true;
            this.AllixCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AllixCheckBox.Location = new System.Drawing.Point(881, 456);
            this.AllixCheckBox.Name = "AllixCheckBox";
            this.AllixCheckBox.Size = new System.Drawing.Size(143, 21);
            this.AllixCheckBox.TabIndex = 10;
            this.AllixCheckBox.Text = "Auxillary elements";
            this.AllixCheckBox.UseVisualStyleBackColor = true;
            this.AllixCheckBox.CheckedChanged += new System.EventHandler(this.AllixCheckBox_CheckedChanged);
            // 
            // AllSymbolCheckBox
            // 
            this.AllSymbolCheckBox.AutoSize = true;
            this.AllSymbolCheckBox.Location = new System.Drawing.Point(881, 483);
            this.AllSymbolCheckBox.Name = "AllSymbolCheckBox";
            this.AllSymbolCheckBox.Size = new System.Drawing.Size(93, 21);
            this.AllSymbolCheckBox.TabIndex = 11;
            this.AllSymbolCheckBox.Text = "All symbol";
            this.AllSymbolCheckBox.UseVisualStyleBackColor = true;
            this.AllSymbolCheckBox.CheckedChanged += new System.EventHandler(this.AllSymbolCheckBox_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1136, 28);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFontToolStripMenuItem,
            this.saveFontToolStripMenuItem,
            this.loadFontToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newFontToolStripMenuItem
            // 
            this.newFontToolStripMenuItem.Name = "newFontToolStripMenuItem";
            this.newFontToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.newFontToolStripMenuItem.Text = "New Font";
            this.newFontToolStripMenuItem.Click += new System.EventHandler(this.newFontToolStripMenuItem_Click);
            // 
            // saveFontToolStripMenuItem
            // 
            this.saveFontToolStripMenuItem.Name = "saveFontToolStripMenuItem";
            this.saveFontToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.saveFontToolStripMenuItem.Text = "Save Font";
            this.saveFontToolStripMenuItem.Click += new System.EventHandler(this.saveFontToolStripMenuItem_Click);
            // 
            // loadFontToolStripMenuItem
            // 
            this.loadFontToolStripMenuItem.Name = "loadFontToolStripMenuItem";
            this.loadFontToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.loadFontToolStripMenuItem.Text = "Load Font";
            this.loadFontToolStripMenuItem.Click += new System.EventHandler(this.loadFontToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(45, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(948, 318);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // CoordTextBox
            // 
            this.CoordTextBox.AutoSize = true;
            this.CoordTextBox.Checked = true;
            this.CoordTextBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CoordTextBox.Location = new System.Drawing.Point(881, 511);
            this.CoordTextBox.Name = "CoordTextBox";
            this.CoordTextBox.Size = new System.Drawing.Size(106, 21);
            this.CoordTextBox.TabIndex = 14;
            this.CoordTextBox.Text = "Coordinates";
            this.CoordTextBox.UseVisualStyleBackColor = true;
            this.CoordTextBox.CheckedChanged += new System.EventHandler(this.CoordTextBox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 647);
            this.Controls.Add(this.CoordTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AllSymbolCheckBox);
            this.Controls.Add(this.AllixCheckBox);
            this.Controls.Add(this.ContourList);
            this.Controls.Add(this.SymbolTextBox);
            this.Controls.Add(this.SYmbolList);
            this.Controls.Add(this.AddContourButton);
            this.Controls.Add(this.AddSymbolButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.WorkPanel);
            this.Controls.Add(this.AddCurveButton);
            this.Controls.Add(this.AddLineButton);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "MyFont";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddLineButton;
        private System.Windows.Forms.Button AddCurveButton;
        private System.Windows.Forms.Panel WorkPanel;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button AddSymbolButton;
        private System.Windows.Forms.Button AddContourButton;
        private System.Windows.Forms.ListBox SYmbolList;
        private System.Windows.Forms.TextBox SymbolTextBox;
        private System.Windows.Forms.ListBox ContourList;
        private System.Windows.Forms.CheckBox AllixCheckBox;
        private System.Windows.Forms.CheckBox AllSymbolCheckBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox CoordTextBox;
    }
}

