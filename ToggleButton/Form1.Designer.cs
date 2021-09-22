namespace WindowsFormsApp1
{
    partial class Form1
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
            this.toggleButton1 = new ToggleButtons.ToggleButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.toggleButton2 = new ToggleButtons.ToggleButton();
            this.SuspendLayout();
            // 
            // toggleButton1
            // 
            this.toggleButton1.BackBorderOffColor = System.Drawing.Color.Gray;
            this.toggleButton1.BackBorderOnColor = System.Drawing.Color.Gray;
            this.toggleButton1.BackBorderWidth = 1;
            this.toggleButton1.BackColor = System.Drawing.Color.White;
            this.toggleButton1.BackOffColor = System.Drawing.Color.White;
            this.toggleButton1.BackOnColor = System.Drawing.Color.White;
            this.toggleButton1.BorderRadius = 8;
            this.toggleButton1.Checked = false;
            this.toggleButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toggleButton1.Font = new System.Drawing.Font("Verdana", 9F);
            this.toggleButton1.Gap = 4;
            this.toggleButton1.Location = new System.Drawing.Point(101, 111);
            this.toggleButton1.Name = "toggleButton1";
            this.toggleButton1.Size = new System.Drawing.Size(45, 25);
            this.toggleButton1.TabIndex = 0;
            this.toggleButton1.Text = "toggleButton1";
            this.toggleButton1.TogglerBorderOffColor = System.Drawing.Color.Red;
            this.toggleButton1.TogglerBorderOnColor = System.Drawing.Color.LimeGreen;
            this.toggleButton1.TogglerBorderWidth = 1;
            this.toggleButton1.TogglerOffColor = System.Drawing.Color.White;
            this.toggleButton1.TogglerOnColor = System.Drawing.Color.LimeGreen;
            this.toggleButton1.Click += new System.EventHandler(this.toggleButton1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(93, 159);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(68, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "checked";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // toggleButton2
            // 
            this.toggleButton2.BackBorderOffColor = System.Drawing.Color.Transparent;
            this.toggleButton2.BackBorderOnColor = System.Drawing.Color.Transparent;
            this.toggleButton2.BackBorderWidth = 1;
            this.toggleButton2.BackColor = System.Drawing.Color.White;
            this.toggleButton2.BackOffColor = System.Drawing.Color.White;
            this.toggleButton2.BackOnColor = System.Drawing.SystemColors.Highlight;
            this.toggleButton2.BorderRadius = 20;
            this.toggleButton2.Checked = false;
            this.toggleButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toggleButton2.Font = new System.Drawing.Font("Verdana", 9F);
            this.toggleButton2.Gap = 3;
            this.toggleButton2.Location = new System.Drawing.Point(104, 66);
            this.toggleButton2.Name = "toggleButton2";
            this.toggleButton2.Size = new System.Drawing.Size(40, 25);
            this.toggleButton2.TabIndex = 2;
            this.toggleButton2.Text = "toggleButton2";
            this.toggleButton2.TogglerBorderOffColor = System.Drawing.SystemColors.Highlight;
            this.toggleButton2.TogglerBorderOnColor = System.Drawing.Color.White;
            this.toggleButton2.TogglerBorderWidth = 2;
            this.toggleButton2.TogglerOffColor = System.Drawing.Color.White;
            this.toggleButton2.TogglerOnColor = System.Drawing.Color.White;
            this.toggleButton2.Click += new System.EventHandler(this.toggleButton2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 248);
            this.Controls.Add(this.toggleButton2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.toggleButton1);
            this.Name = "Form1";
            this.Text = "ToggleButtonDemo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToggleButtons.ToggleButton toggleButton1;
        private System.Windows.Forms.CheckBox checkBox1;
        private ToggleButtons.ToggleButton toggleButton2;
    }
}

