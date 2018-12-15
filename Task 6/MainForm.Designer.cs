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
            this.SuspendLayout();
            // 
            // AddLineButton
            // 
            this.AddLineButton.Location = new System.Drawing.Point(787, 202);
            this.AddLineButton.Name = "AddLineButton";
            this.AddLineButton.Size = new System.Drawing.Size(80, 45);
            this.AddLineButton.TabIndex = 0;
            this.AddLineButton.Text = "Line";
            this.AddLineButton.UseVisualStyleBackColor = true;
            this.AddLineButton.Click += new System.EventHandler(this.AddLineButton_Click);
            // 
            // AddCurveButton
            // 
            this.AddCurveButton.Location = new System.Drawing.Point(900, 202);
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
            this.WorkPanel.Location = new System.Drawing.Point(90, 69);
            this.WorkPanel.Name = "WorkPanel";
            this.WorkPanel.Size = new System.Drawing.Size(631, 512);
            this.WorkPanel.TabIndex = 2;
            this.WorkPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.WorkPanel_Paint);
            this.WorkPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WorkPanel_MouseDown);
            this.WorkPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WorkPanel_MouseMove);
            this.WorkPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WorkPanel_MouseUp);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(787, 294);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(80, 45);
            this.DeleteButton.TabIndex = 3;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 647);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.WorkPanel);
            this.Controls.Add(this.AddCurveButton);
            this.Controls.Add(this.AddLineButton);
            this.Name = "MainForm";
            this.Text = "MyFont";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddLineButton;
        private System.Windows.Forms.Button AddCurveButton;
        private System.Windows.Forms.Panel WorkPanel;
        private System.Windows.Forms.Button DeleteButton;
    }
}

